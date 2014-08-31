using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    public class AzureStore<T> :
        IUserStore<T>,
        IUserClaimStore<T>,
        IUserLoginStore<T>,
        IUserRoleStore<T>,
        IUserPasswordStore<T>,
        IUserEmailStore<T> where T : AzureUser , new ()
    {
        public AzureStore(string connectionString)
        {
            this._connectionString = connectionString;
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            // CreateAsync the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // CreateAsync the table if it doesn't exist.
            UserTable = tableClient.GetTableReference("users");
            UserTable.CreateIfNotExists();

            LoginTable = tableClient.GetTableReference("logins");
            LoginTable.CreateIfNotExists();

            ClaimsTable = tableClient.GetTableReference("claims");
            ClaimsTable.CreateIfNotExists();

            UserIndexTable = tableClient.GetTableReference("userIndexItems");
            UserIndexTable.CreateIfNotExists();

            LoginProviderKeyIndexTable = tableClient.GetTableReference("loginProviderKeyIndex");
            LoginProviderKeyIndexTable.CreateIfNotExists();

            UserEmailIndexTable = tableClient.GetTableReference("userEmailIndex");
            UserEmailIndexTable.CreateIfNotExists();

            RolesTable = tableClient.GetTableReference("roles");
            RolesTable.CreateIfNotExists();

            BatchOperation = new TableBatchOperation();
        }

        private readonly string _connectionString;

        public TableBatchOperation BatchOperation { get; set; }
        public CloudTable UserTable { get; set; }
        public CloudTable LoginTable { get; set; }
        public CloudTable ClaimsTable { get; set; }
        public CloudTable UserIndexTable { get; set; }
        public CloudTable LoginProviderKeyIndexTable { get; set; }
        public CloudTable UserEmailIndexTable { get; set; }

        public CloudTable RolesTable { get; set; }

        internal Func<IEnumerable<AzureLogin>> LazyLoginEvaluator { get; set; }

        public void Dispose()
        {
        }

        public async Task<IList<Claim>> GetClaimsAsync(T user)
        {
            if (user == null) throw new ArgumentNullException();

            List<Claim> claims = new List<Claim>();
            string partitionKeyQuery = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id);
            TableQuery<AzureClaim> query = new TableQuery<AzureClaim>().Where(partitionKeyQuery);
            TableQuerySegment<AzureClaim> querySegment = null;

            while (querySegment == null || querySegment.ContinuationToken != null)
            {
                querySegment = await ClaimsTable.ExecuteQuerySegmentedAsync(query, querySegment != null ? querySegment.ContinuationToken : null);
                claims.AddRange(querySegment.Results.Select(x => new Claim(x.ClaimType, x.ClaimValue)));
            }

            return claims;
        }

        public async Task AddClaimAsync(T user, System.Security.Claims.Claim claim)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (claim == null) throw new ArgumentNullException("claim");
            AzureClaim tableUserClaim = new AzureClaim(user.Id, claim.Type, claim.Value);
            TableOperation operation = TableOperation.Insert(tableUserClaim);
            await ClaimsTable.ExecuteAsync(operation);
        }

        public async Task RemoveClaimAsync(T user, System.Security.Claims.Claim claim)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (claim == null) throw new ArgumentNullException("claim");
            AzureClaim tableUserClaim = new AzureClaim(user.Id, claim.Type, claim.Value);
            TableOperation operation = TableOperation.Delete(tableUserClaim);
            await ClaimsTable.ExecuteAsync(operation);
        }

        public async Task UpdateAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");
            TableOperation op = TableOperation.Replace(user);
            await UserTable.ExecuteAsync(op);
        }

        public async Task CreateAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");

            AzureUserIdIndex indexItem = new AzureUserIdIndex(user.UserName, user.Id);
            TableOperation indexOperation = TableOperation.Insert(indexItem);

            try
            {
                await UserIndexTable.ExecuteAsync(indexOperation);
            }
            catch (StorageException ex)
            {
                if (ex.RequestInformation.HttpStatusCode == 409)
                {
                    throw new DuplicateUsernameException();
                }
                throw;
            }

            if (!String.IsNullOrWhiteSpace(user.Email))
            {
                AzureUserEmailIndex emailIndexItem = new AzureUserEmailIndex(user.Email.Base64Encode(), user.Id);
                TableOperation emailIndexOperation = TableOperation.Insert(emailIndexItem);
                try
                {
                    await UserEmailIndexTable.ExecuteAsync(emailIndexOperation);
                }
                catch (StorageException ex)
                {
                    try
                    {
                        TableOperation deleteOperation = TableOperation.Delete(indexItem);
                        UserIndexTable.ExecuteAsync(deleteOperation).Wait();
                    }
                    catch (Exception)
                    {
                        // if we can't delete the index item throw out the exception below
                    }


                    if (ex.RequestInformation.HttpStatusCode == 409)
                    {
                        throw new DuplicateEmailException();
                    }
                    throw;
                }
            }

            try
            {
                TableOperation operation = TableOperation.InsertOrReplace(user);
                await UserTable.ExecuteAsync(operation);

                if (user.Logins.Any())
                {
                    TableBatchOperation batch = new TableBatchOperation();
                    List<AzureUserLoginProviderKeyIndex> loginIndexItems = new List<AzureUserLoginProviderKeyIndex>();
                    foreach (AzureLogin login in user.Logins)
                    {
                        login.UserId = user.Id;
                        batch.InsertOrReplace(login);

                        AzureUserLoginProviderKeyIndex loginIndexItem = new AzureUserLoginProviderKeyIndex(user.Id, login.ProviderKey, login.LoginProvider);
                        loginIndexItems.Add(loginIndexItem);
                    }
                    await LoginTable.ExecuteBatchAsync(batch);
                    // can't batch the index items as different primary keys
                    foreach (AzureUserLoginProviderKeyIndex loginIndexItem in loginIndexItems)
                    {
                        await LoginProviderKeyIndexTable.ExecuteAsync(TableOperation.InsertOrReplace(loginIndexItem));
                    }
                }
            }
            catch (Exception)
            {
                // attempt to delete the index item - needs work
                TableOperation deleteOperation = TableOperation.Delete(indexItem);
                UserIndexTable.ExecuteAsync(deleteOperation).Wait();
                throw;
            }
        }

        public Task<T> FindByIdAsync(string userId)
        {
            //if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            //TableOperation op = TableOperation.Retrieve<AzureUser>(Constants.IdentityPartitionKey, userId);
            //var result = UserTable.Execute(op);
            //return Task.FromResult<AzureUser>(result.Result as AzureUser);
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            return Task.Factory.StartNew(() =>
            {
                TableQuery<T> query =
                    new TableQuery<T>().Where(
                        TableQuery.GenerateFilterCondition("PartitionKey",
                            QueryComparisons.Equal, userId)).Take(1);
                IEnumerable<T> results = UserTable.ExecuteQuery(query);
                T result = results.SingleOrDefault();
                if (result != null)
                {
                    result.LazyLoginEvaluator = () =>
                    {
                        Task<IList<UserLoginInfo>> loginInfoTask = GetLoginsAsync(result);
                        loginInfoTask.Wait();
                        IList<UserLoginInfo> loginInfo = loginInfoTask.Result;
                        return loginInfo.Select(x => new AzureLogin(result.Id, x));
                    };
                    result.LazyClaimsEvaluator = () =>
                    {
                        Task<IList<Claim>> claimTask = GetClaimsAsync(result);
                        claimTask.Wait();
                        IList<Claim> loginInfo = claimTask.Result;
                        return loginInfo.Select(x => new AzureClaim(result.Id, x.Type, x.Value));
                    };
                    result.LazyRolesEvaluator = () =>
                    {
                        Task<IList<string>> roleTask = GetRolesAsync(result);
                        roleTask.Wait();
                        IList<string> roles = roleTask.Result;
                        return roles.Select(x => new AzureRole(result.Id, x));
                    };
                }

                return result;
            });
        }

        public Task<T> FindByNameAsync(string userName)
        {
            if (String.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException("userName");
            TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("UserName", QueryComparisons.Equal, userName));
            return Task.FromResult(UserTable.ExecuteQuery(query).FirstOrDefault());
        }

        public async Task AddLoginAsync(T user, UserLoginInfo login)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (login == null) throw new ArgumentNullException("login");

            TableOperation op = TableOperation.Insert(new AzureLogin(user.Id, login));
            await UserTable.ExecuteAsync(op);
        }

        public async Task RemoveLoginAsync(T user, UserLoginInfo login)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (login == null) throw new ArgumentNullException("login");

            var al = Find(login);
            if (al != null)
            {
                TableOperation op = TableOperation.Delete(al);
                await UserTable.ExecuteAsync(op);
            }
            await Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");

            TableQuery<AzureLogin> query = new TableQuery<AzureLogin>()
                .Where(TableQuery.GenerateFilterCondition("UserId", QueryComparisons.Equal, user.Id))
                .Select(new string[] { "LoginProvider", "ProviderKey" });
            var results = UserTable.ExecuteQuery(query);
            IList<UserLoginInfo> logins = new List<UserLoginInfo>();
            foreach (var al in results)
            {
                logins.Add(new UserLoginInfo(al.LoginProvider, al.ProviderKey));
            }
            return Task.FromResult(logins);
        }

        private AzureLogin Find(UserLoginInfo login)
        {
            TableQuery<AzureLogin> query = new TableQuery<AzureLogin>()
                .Where(TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("LoginProvider", QueryComparisons.Equal, login.LoginProvider),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("ProviderKey", QueryComparisons.Equal, login.ProviderKey)))
                .Select(new string[] { "UserId" });
            return UserTable.ExecuteQuery(query).FirstOrDefault();
        }

        public async Task<T> FindAsync(UserLoginInfo login)
        {
            if (login == null) throw new ArgumentNullException("login");

            var al = Find(login);
            if (al != null)
            {
                return await FindByIdAsync(al.UserId);
            }

            return await Task.FromResult<T>(null);
        }

        public async Task AddToRoleAsync(T user, string role)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(role)) throw new ArgumentNullException("role");
            AzureRole tableUserRole = new AzureRole(user.Id, role);
            TableOperation operation = TableOperation.Insert(tableUserRole);
            await RolesTable.ExecuteAsync(operation);
        }

        public async Task RemoveFromRoleAsync(T user, string role)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(role)) throw new ArgumentNullException("role");
            AzureRole tableUserRole = new AzureRole(user.Id, role);
            TableOperation operation = TableOperation.Delete(tableUserRole);
            await RolesTable.ExecuteAsync(operation);
        }

        public async Task<IList<string>> GetRolesAsync(T user)
        {
            if (user == null) throw new ArgumentNullException();

            List<string> claims = new List<string>();
            string partitionKeyQuery = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id);
            TableQuery<AzureRole> query = new TableQuery<AzureRole>().Where(partitionKeyQuery);
            TableQuerySegment<AzureRole> querySegment = null;

            while (querySegment == null || querySegment.ContinuationToken != null)
            {
                querySegment = await RolesTable.ExecuteQuerySegmentedAsync(query, querySegment != null ? querySegment.ContinuationToken : null);
                claims.AddRange(querySegment.Results.Select(x => x.Name));
            }

            return claims;
        }

        public Task<bool> IsInRoleAsync(T user, string role)
        {
            return Task.FromResult(false);
        }

        public async Task DeleteAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");
            TableOperation operation = TableOperation.Delete(user);
            await UserTable.ExecuteAsync(operation);
        }

        public Task<string> GetPasswordHashAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetPasswordHashAsync(T user, string passwordHash)
        {
            if (user == null) throw new ArgumentNullException("user");
            // If you add and remove a password from a user (only way to do a non-authenticated reset)
            // then this will get set to null
            //if (String.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentNullException("passwordHash");

            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetEmailAsync(T user, string email)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("email");

            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(T user)
        {
            if (user == null) throw new ArgumentNullException("user");
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(T user, bool confirmed)
        {
            if (user == null) throw new ArgumentNullException("user");

            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public async Task<T> FindByEmailAsync(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) return null;

            var retrieveIndexOp = TableOperation.Retrieve<AzureUserEmailIndex>(email.Base64Encode(), "");
            var indexResult = await UserEmailIndexTable.ExecuteAsync(retrieveIndexOp);
            if (indexResult.Result == null) return null;
            var user = (AzureUserEmailIndex)indexResult.Result;
            return await FindByIdAsync(user.UserId);
        }
    }
}
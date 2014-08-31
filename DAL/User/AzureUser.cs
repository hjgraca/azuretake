using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    public class AzureUser : TableEntity, IUser, IUserData
    {
        public AzureUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public AzureUser(string userName): this()
        {
            UserName = userName;
        }

        public string Id
        {
            get { return _id; }
            set
            {
                this.PartitionKey = value;
                this.RowKey = value;
                _id = value;
            }
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool EmailConfirmed { get; set; }

        [IgnoreProperty]
        internal Func<IEnumerable<AzureRole>> LazyRolesEvaluator { get; set; }

        private List<AzureRole> _roles;
        [IgnoreProperty]
        public ICollection<AzureRole> Roles
        {
            get
            {
                if (_roles == null)
                {
                    if (LazyRolesEvaluator != null)
                    {
                        _roles = new List<AzureRole>(LazyRolesEvaluator());
                    }
                    else
                    {
                        _roles = new List<AzureRole>();
                    }
                }
                return _roles;
            }
        }

        [IgnoreProperty]
        internal Func<IEnumerable<AzureClaim>> LazyClaimsEvaluator { get; set; }

        private List<AzureClaim> _claims;
        [IgnoreProperty]
        public ICollection<AzureClaim> Claims
        {
            get
            {
                if (_claims == null)
                {
                    if (LazyClaimsEvaluator != null)
                    {
                        _claims = new List<AzureClaim>(LazyClaimsEvaluator());
                    }
                    else
                    {
                        _claims = new List<AzureClaim>();
                    }
                }
                return _claims;
            }
        }

        [IgnoreProperty]
        internal Func<IEnumerable<AzureLogin>> LazyLoginEvaluator { get; set; }

        private List<AzureLogin> _logins;
        private string _id;

        [IgnoreProperty]
        public ICollection<AzureLogin> Logins
        {
            get
            {
                if (_logins == null)
                {
                    if (LazyLoginEvaluator != null)
                    {
                        _logins = new List<AzureLogin>(LazyLoginEvaluator());
                    }
                    else
                    {
                        _logins = new List<AzureLogin>();
                    }
                }
                return _logins;
            }
        }

        public int GoodOrders { get; set; }
        public int BadOrders { get; set; }
        public int TotalOrders { get; set; }
        public int TearmsAndConditionsVersion { get; set; }
        public DateTime LastLogin { get; set; }
        public int Points { get; set; }
        public string Referral { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool NewsLetter { get; set; }
        public DateTime Created { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}
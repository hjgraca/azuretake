using System;
using Microsoft.AspNet.Identity;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    public class AzureLogin : TableEntity
    {
        public AzureLogin()
        {
            PartitionKey = Constants.IdentityPartitionKey;
            RowKey = Guid.NewGuid().ToString();
        }

        public AzureLogin(string ownerId, UserLoginInfo info)
            : this()
        {
            UserId = ownerId;
            LoginProvider = info.LoginProvider;
            ProviderKey = info.ProviderKey;
        }

        public string UserId { get; set; }
        public string ProviderKey { get; set; }
        public string LoginProvider { get; set; }
    }
}
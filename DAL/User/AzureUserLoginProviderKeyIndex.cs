using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Extensions;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    class AzureUserLoginProviderKeyIndex: TableEntity
    {
        public AzureUserLoginProviderKeyIndex(string userId, string loginProviderKey, string loginProvider)
        {
            PartitionKey = String.Format("{0}_{1}", loginProvider, loginProviderKey.Base64Encode());
            RowKey = "";
            UserId = userId;
        }
        
        // Add a parameterless constructor to resolve issue in TableUserStore.cs FindAsync
        public AzureUserLoginProviderKeyIndex() { }

        public string GetLoginProvider()
        {
            return PartitionKey.Substring(0, PartitionKey.IndexOf('_')-1);
        }

        public string GetLoginProviderKey()
        {
            return PartitionKey.Substring(PartitionKey.IndexOf('_')).Base64Decode();
        }

        public string UserId { get; set; }
    }
}

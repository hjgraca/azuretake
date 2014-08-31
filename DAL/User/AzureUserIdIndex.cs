using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    public class AzureUserIdIndex: TableEntity
    {
        public AzureUserIdIndex()
        {
            
        }

        public AzureUserIdIndex(string userName, string userId)
        {
            PartitionKey = userName;
            RowKey = userName;
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}

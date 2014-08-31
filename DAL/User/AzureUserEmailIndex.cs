using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    class AzureUserEmailIndex: TableEntity
    {
        public AzureUserEmailIndex()
        {
            
        }

        public AzureUserEmailIndex(string base64EncodedEmail, string userId)
        {
            PartitionKey = base64EncodedEmail;
            RowKey = "";
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}

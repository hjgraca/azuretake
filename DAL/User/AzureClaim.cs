using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    public class AzureClaim : TableEntity
    {
        public AzureClaim()
        {
            PartitionKey = UserId;
            RowKey = ClaimType;
        }
        public AzureClaim(string userId, string claimType, string claimValue):
            this()
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}

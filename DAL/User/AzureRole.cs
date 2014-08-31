using System;
using Microsoft.AspNet.Identity;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.User
{
    public class AzureRole : TableEntity, IRole
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public AzureRole()
        {
            PartitionKey = UserId;
            RowKey = Name;
        }

        public AzureRole(string userId, string name):
            this()
        {
            Id = Guid.NewGuid().ToString();
            UserId = userId;
            Name = name;
        }

        public string UserId { get; set; }
    }
}

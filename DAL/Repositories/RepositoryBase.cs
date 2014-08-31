using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly CloudTable _table;

        protected RepositoryBase(string table)
        {
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(table);
            _table.CreateIfNotExists();
        }
    }
}
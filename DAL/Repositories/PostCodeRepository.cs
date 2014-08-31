using System;
using System.Diagnostics;
using DAL.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.Repositories
{
    public class PostCodeRepository : RepositoryBase
    {
        public PostCodeRepository()
            : base("postcodes")
        {
        }

        public void Insert(PostCodeEntity entity)
        {
            try
            {
                var operation = TableOperation.Insert(entity);
                var result = _table.Execute(operation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

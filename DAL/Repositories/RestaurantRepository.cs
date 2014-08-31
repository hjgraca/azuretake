using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DAL.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.Queryable;

namespace DAL.Repositories
{
    public class RestaurantRepository : RepositoryBase
    {
        public RestaurantRepository()
            : base("restaurant")
        {
        }

        public void Insert(RestaurantEntity restaurant)
        {
            try
            {
                var operation = TableOperation.Insert(restaurant);
                var result = _table.Execute(operation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        public IEnumerable<RestaurantEntity> GetAll()
        {
            var result = _table.CreateQuery<RestaurantEntity>().AsTableQuery<RestaurantEntity>().Execute();

            return result;
        }

        public RestaurantEntity Get()
        {
            var query = new TableQuery<RestaurantEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", 
                QueryComparisons.Equal,
                "NW6"));

            return _table.ExecuteQuery(query).FirstOrDefault();
        }

        public IEnumerable<RestaurantEntity> GetByPostCode(string postCode)
        {
            var query = new TableQuery<RestaurantEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal,
                postCode.ToUpper()));

            return _table.ExecuteQuery(query);
        }
    }
}

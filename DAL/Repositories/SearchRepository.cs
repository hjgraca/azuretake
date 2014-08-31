using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.Repositories
{
    public class SearchRepository : RepositoryBase
    {
        public SearchRepository() : 
            base("search")
        {
        }

        public void InsertRestaurant(string postCode, RestaurantEntity entity)
        {
            try
            {
                var operation = TableOperation.Insert(new SearchEntity
                {
                    PartitionKey = postCode,
                    Category = entity.FoodType,
                    RestaurantAddress = entity.Address,
                    RestaurantLogo = entity.LogoUrl,
                    RowKey = entity.RowKey,
                    Rating = entity.FakeRating,
                    NumberOfVotes = entity.FakeNumVotes
                });

                _table.Execute(operation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public IEnumerable<SearchEntity> Search(string postCode)
        {
            var query = new TableQuery<SearchEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal,
                postCode));

            return _table.ExecuteQuery(query);
        }
    }
}

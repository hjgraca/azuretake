using System.Collections.Generic;

namespace MigrationDB.Entities
{
    public class FoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
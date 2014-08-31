using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDB.Entities
{
    public class RestaurantEntity : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<PostCode> PostCodes { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<DeliveryArea> DeliveryAreas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }


    }
}

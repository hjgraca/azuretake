using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDB.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public MenuType MenuType { get; set; }
        public string Description { get; set; }
        public bool IsCollection { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsRequired { get; set; }
    }

    public class DeliveryArea
    {
        public int Id { get; set; }
        public Decimal DeliveryCostAboveThreshold { get; set; }
        public Decimal DeliveryCostBelowThreshold { get; set; }
        public Decimal DeliveryThresholdOrderAmount { get; set; }
        public Decimal DeliveryTurningPoint { get; set; }
        public PostCode PostCode { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Offer { get; set; }

        public string Description { get; set; }

        public ICollection<Menu> Menus { get; set; }
        public Category Category { get; set; }

        public ICollection<Accessory> Accessories { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Product> MealParts { get; set; }

        public ProductType ProductType { get; set; }

        public ICollection<Accessory> Options { get; set; }
    }

    public enum MenuType
    {
        Delivery = 1,
        Collection = 2
    }

    [Flags]
    public enum ProductType
    {
        None = 0,
        Spicy = 1 << 1,
        Vegetarian = 1 << 2,
        Nuts = 1 << 3
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Offer { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}

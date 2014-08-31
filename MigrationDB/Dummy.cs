using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDB.Dummy
{

    public class Rootobject
    {
        public int restaurantId { get; set; }
        public string seoName { get; set; }
        public string title { get; set; }
        public string keywords { get; set; }
        public Area[] areas { get; set; }
        public Menu[] menus { get; set; }
    }

    public class Area
    {
        public float DeliveryCostAboveThreshold { get; set; }
        public float DeliveryCostBelowThreshold { get; set; }
        public float DeliveryThresholdOrderAmount { get; set; }
        public float DeliveryTurningPoint { get; set; }
        public string PostCode { get; set; }
    }

    public class Menu
    {
        public Category[] Categories { get; set; }
        public bool IsCollection { get; set; }
        public string MenuDescription { get; set; }
        public int MenuCardId { get; set; }
        public bool IsCollectionOnly { get; set; }
    }

    public class Category
    {
        public Menuitem[] MenuItems { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Offer { get; set; }
    }

    public class Menuitem
    {
        public string Name { get; set; }
        public string MenuNumber { get; set; }
        public Product[] Products { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Synonym { get; set; }
        public int ProductTypeId { get; set; }
        public bool RequireOtherProducts { get; set; }
        public string MenuNumber { get; set; }
        public object IsTips { get; set; }
        public int Offer { get; set; }
        public Optionalaccessory[] OptionalAccessories { get; set; }
        public Requiredaccessory[] RequiredAccessories { get; set; }
        public Mealpart[] MealParts { get; set; }
        public Tag[] Tags { get; set; }
        public bool HasMealParts { get; set; }
    }

    public class Optionalaccessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int GroupId { get; set; }
        public int Productid { get; set; }
    }

    public class Requiredaccessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int GroupId { get; set; }
        public int Productid { get; set; }
    }

    public class Mealpart
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Synonym { get; set; }
        public int[] GroupIds { get; set; }
        public Optionalaccessory1[] OptionalAccessories { get; set; }
        public Requiredaccessory1[] RequiredAccessories { get; set; }
    }

    public class Optionalaccessory1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int GroupId { get; set; }
        public int Productid { get; set; }
    }

    public class Requiredaccessory1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int GroupId { get; set; }
        public int Productid { get; set; }
    }

    public class Tag
    {
        public string Value { get; set; }
    }

}

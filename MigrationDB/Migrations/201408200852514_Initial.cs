namespace MigrationDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        Line3 = c.String(),
                        PostCode = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account = c.String(),
                        SortCode = c.String(),
                        AccountName = c.String(),
                        ConnectionFee = c.Decimal(precision: 18, scale: 2),
                        InvoiceEmail = c.String(),
                        Iban = c.String(),
                        LegalName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        Owner = c.String(),
                        ContactName = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsOffline = c.Boolean(nullable: false),
                        Joined = c.DateTime(nullable: false),
                        IsBusy = c.Boolean(nullable: false),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        LogoUrl = c.String(),
                        DaysOpen = c.Int(nullable: false),
                        OpenHours = c.String(),
                        OfflineMessage = c.String(),
                        Number = c.String(),
                        Rating = c.Double(nullable: false),
                        Votes = c.Int(nullable: false),
                        GeoLocation = c.String(),
                        FakeId = c.String(),
                        DeliversTo = c.String(),
                        ContactPhone = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        SaleFee = c.Int(nullable: false),
                        FakeNumVotes = c.Int(nullable: false),
                        FakeRating = c.Double(nullable: false),
                        PostCode2 = c.String(),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.PostCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CityName = c.String(maxLength: 500),
                        Synonyms = c.String(maxLength: 500),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantFoodTypes",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        FoodType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.FoodType_Id })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .ForeignKey("dbo.FoodTypes", t => t.FoodType_Id, cascadeDelete: true)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.FoodType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostCodes", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.RestaurantFoodTypes", "FoodType_Id", "dbo.FoodTypes");
            DropForeignKey("dbo.RestaurantFoodTypes", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Contacts", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.Addresses", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.RestaurantFoodTypes", new[] { "FoodType_Id" });
            DropIndex("dbo.RestaurantFoodTypes", new[] { "Restaurant_Id" });
            DropIndex("dbo.PostCodes", new[] { "Region_Id" });
            DropIndex("dbo.Restaurants", new[] { "Bank_Id" });
            DropIndex("dbo.Contacts", new[] { "Restaurant_Id" });
            DropIndex("dbo.Addresses", new[] { "Restaurant_Id" });
            DropTable("dbo.RestaurantFoodTypes");
            DropTable("dbo.Regions");
            DropTable("dbo.PostCodes");
            DropTable("dbo.Restaurants");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.Banks");
            DropTable("dbo.Addresses");
        }
    }
}

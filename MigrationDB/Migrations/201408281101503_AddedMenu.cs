namespace MigrationDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Offer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOverride = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Offer = c.Boolean(nullable: false),
                        DescriptionOverride = c.String(),
                        ProductConfig = c.Int(nullable: false),
                        Category_Id = c.Int(),
                        Synonym_Id = c.Int(),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Synonyms", t => t.Synonym_Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Synonym_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Synonyms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSpicy = c.Boolean(nullable: false),
                        IsVeg = c.Boolean(nullable: false),
                        ContainsNuts = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryCostAboveThreshold = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryCostBelowThreshold = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryThresholdOrderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryTurningPoint = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PostCode_Id = c.Int(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostCodes", t => t.PostCode_Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.PostCode_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MenuType = c.Int(nullable: false),
                        Description = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            AddColumn("dbo.Restaurants", "SeoName", c => c.String());
            AddColumn("dbo.Restaurants", "PageTitle", c => c.String());
            AddColumn("dbo.Restaurants", "PageKeywords", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Products", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.DeliveryAreas", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.DeliveryAreas", "PostCode_Id", "dbo.PostCodes");
            DropForeignKey("dbo.Products", "Synonym_Id", "dbo.Synonyms");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Menus", new[] { "Restaurant_Id" });
            DropIndex("dbo.DeliveryAreas", new[] { "Restaurant_Id" });
            DropIndex("dbo.DeliveryAreas", new[] { "PostCode_Id" });
            DropIndex("dbo.Products", new[] { "Menu_Id" });
            DropIndex("dbo.Products", new[] { "Synonym_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Restaurants", "PageKeywords");
            DropColumn("dbo.Restaurants", "PageTitle");
            DropColumn("dbo.Restaurants", "SeoName");
            DropTable("dbo.Menus");
            DropTable("dbo.DeliveryAreas");
            DropTable("dbo.Synonyms");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Accessories");
        }
    }
}

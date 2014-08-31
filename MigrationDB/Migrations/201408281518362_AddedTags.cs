namespace MigrationDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuProducts", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.MenuProducts", new[] { "Menu_Id" });
            DropIndex("dbo.MenuProducts", new[] { "Product_Id" });
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Product_Id = c.Int(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Restaurant_Id);
            
            AddColumn("dbo.Accessories", "IsRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.Accessories", "Product_Id", c => c.Int());
            AddColumn("dbo.Products", "Menu_Id", c => c.Int());
            AddColumn("dbo.Products", "Menu_Id1", c => c.Int());
            AddColumn("dbo.Menus", "Product_Id", c => c.Int());
            CreateIndex("dbo.Accessories", "Product_Id");
            CreateIndex("dbo.Products", "Menu_Id");
            CreateIndex("dbo.Products", "Menu_Id1");
            CreateIndex("dbo.Menus", "Product_Id");
            AddForeignKey("dbo.Accessories", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "Menu_Id", "dbo.Menus", "Id");
            AddForeignKey("dbo.Products", "Menu_Id1", "dbo.Menus", "Id");
            AddForeignKey("dbo.Menus", "Product_Id", "dbo.Products", "Id");
            DropTable("dbo.MenuProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuProducts",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Product_Id });
            
            DropForeignKey("dbo.Tags", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Tags", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Menus", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Menu_Id1", "dbo.Menus");
            DropForeignKey("dbo.Products", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Accessories", "Product_Id", "dbo.Products");
            DropIndex("dbo.Tags", new[] { "Restaurant_Id" });
            DropIndex("dbo.Tags", new[] { "Product_Id" });
            DropIndex("dbo.Menus", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Menu_Id1" });
            DropIndex("dbo.Products", new[] { "Menu_Id" });
            DropIndex("dbo.Accessories", new[] { "Product_Id" });
            DropColumn("dbo.Menus", "Product_Id");
            DropColumn("dbo.Products", "Menu_Id1");
            DropColumn("dbo.Products", "Menu_Id");
            DropColumn("dbo.Accessories", "Product_Id");
            DropColumn("dbo.Accessories", "IsRequired");
            DropTable("dbo.Tags");
            CreateIndex("dbo.MenuProducts", "Product_Id");
            CreateIndex("dbo.MenuProducts", "Menu_Id");
            AddForeignKey("dbo.MenuProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuProducts", "Menu_Id", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}

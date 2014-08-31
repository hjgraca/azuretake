namespace MigrationDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSynonym : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Products", "Menu_Id1", "dbo.Menus");
            DropForeignKey("dbo.Menus", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Synonym_Id", "dbo.Synonyms");
            DropIndex("dbo.Products", new[] { "Menu_Id" });
            DropIndex("dbo.Products", new[] { "Menu_Id1" });
            DropIndex("dbo.Products", new[] { "Synonym_Id" });
            DropIndex("dbo.Menus", new[] { "Product_Id" });
            CreateTable(
                "dbo.MenuProducts",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Product_Id })
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Products", "Synonym", c => c.String());
            AddColumn("dbo.Products", "ProductType", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Product_Id", c => c.Int());
            AddColumn("dbo.Menus", "IsCollection", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "Product_Id");
            AddForeignKey("dbo.Products", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Products", "Menu_Id");
            DropColumn("dbo.Products", "Menu_Id1");
            DropColumn("dbo.Products", "Synonym_Id");
            DropColumn("dbo.Menus", "Product_Id");
            DropTable("dbo.Synonyms");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Menus", "Product_Id", c => c.Int());
            AddColumn("dbo.Products", "Synonym_Id", c => c.Int());
            AddColumn("dbo.Products", "Menu_Id1", c => c.Int());
            AddColumn("dbo.Products", "Menu_Id", c => c.Int());
            DropForeignKey("dbo.MenuProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.MenuProducts", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Products", "Product_Id", "dbo.Products");
            DropIndex("dbo.MenuProducts", new[] { "Product_Id" });
            DropIndex("dbo.MenuProducts", new[] { "Menu_Id" });
            DropIndex("dbo.Products", new[] { "Product_Id" });
            DropColumn("dbo.Menus", "IsCollection");
            DropColumn("dbo.Products", "Product_Id");
            DropColumn("dbo.Products", "ProductType");
            DropColumn("dbo.Products", "Synonym");
            DropTable("dbo.MenuProducts");
            CreateIndex("dbo.Menus", "Product_Id");
            CreateIndex("dbo.Products", "Synonym_Id");
            CreateIndex("dbo.Products", "Menu_Id1");
            CreateIndex("dbo.Products", "Menu_Id");
            AddForeignKey("dbo.Products", "Synonym_Id", "dbo.Synonyms", "Id");
            AddForeignKey("dbo.Menus", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "Menu_Id1", "dbo.Menus", "Id");
            AddForeignKey("dbo.Products", "Menu_Id", "dbo.Menus", "Id");
        }
    }
}

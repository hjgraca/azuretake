namespace MigrationDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMenu1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Products", new[] { "Menu_Id" });
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
            
            DropColumn("dbo.Products", "Menu_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Menu_Id", c => c.Int());
            DropForeignKey("dbo.MenuProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.MenuProducts", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.MenuProducts", new[] { "Product_Id" });
            DropIndex("dbo.MenuProducts", new[] { "Menu_Id" });
            DropTable("dbo.MenuProducts");
            CreateIndex("dbo.Products", "Menu_Id");
            AddForeignKey("dbo.Products", "Menu_Id", "dbo.Menus", "Id");
        }
    }
}

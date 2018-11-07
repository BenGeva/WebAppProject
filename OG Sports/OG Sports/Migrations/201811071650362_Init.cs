namespace OG_Sports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => new { t.UserId, t.Email })
                .Index(t => new { t.UserId, t.Email });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        IsAdmin = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.Email });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Details = c.String(),
                        PicPath = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VideoPath = c.String(),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductsPerOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsPerOrders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductsPerOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", new[] { "UserId", "Email" }, "dbo.Users");
            DropIndex("dbo.ProductsPerOrders", new[] { "ProductId" });
            DropIndex("dbo.ProductsPerOrders", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId", "Email" });
            DropTable("dbo.ProductsPerOrders");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}

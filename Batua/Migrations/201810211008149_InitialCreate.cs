namespace Batua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                {
                    CartID = c.Int(nullable: false, identity: true),
                    ProductID = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    TotalAmount = c.Single(nullable: false),
                    UserID = c.Int(),
                    PurchaseDate = c.DateTime(nullable: true)
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Single(nullable: false),
                        GST = c.Single(nullable: false),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Cart", "UserID_UserID", "dbo.User");
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropIndex("dbo.Cart", new[] { "UserID_UserID" });
            DropTable("dbo.Products");
            DropTable("dbo.Category");
            DropTable("dbo.User");
            DropTable("dbo.Cart");
        }
    }
}

namespace Batua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cart", "PurchaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}

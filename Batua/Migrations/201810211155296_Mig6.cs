namespace Batua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cart", "TotalAmount", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "TotalAmount", c => c.Single(nullable: false));
        }
    }
}

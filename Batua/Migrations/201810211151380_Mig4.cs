namespace Batua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Email", c => c.String());
            DropColumn("dbo.User", "Eamil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Eamil", c => c.String());
            DropColumn("dbo.User", "Email");
        }
    }
}

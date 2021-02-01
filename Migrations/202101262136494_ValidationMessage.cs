namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Name", c => c.String());
        }
    }
}

namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToTicket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Name", c => c.String());
        }
    }
}

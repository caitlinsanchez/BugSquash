namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Description", c => c.String());
            AddColumn("dbo.Tickets", "TicketStatus", c => c.String());
            DropColumn("dbo.Tickets", "IsCompleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "IsCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tickets", "TicketStatus");
            DropColumn("dbo.Tickets", "Description");
        }
    }
}

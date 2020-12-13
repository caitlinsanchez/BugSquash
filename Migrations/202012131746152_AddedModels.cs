namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "TicketStatus");
            DropColumn("dbo.Tickets", "TicketTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "TicketTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "TicketStatus", c => c.String());
        }
    }
}

namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "TicketStatus_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "TicketStatus_Id");
            AddForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus");
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id" });
            DropColumn("dbo.Tickets", "TicketStatus_Id");
            DropTable("dbo.TicketStatus");
        }
    }
}

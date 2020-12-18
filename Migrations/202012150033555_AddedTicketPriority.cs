namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketPriority : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketPriorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "TicketPriority_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "TicketPriority_Id");
            AddForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities");
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id" });
            DropColumn("dbo.Tickets", "TicketPriority_Id");
            DropTable("dbo.TicketPriorities");
        }
    }
}

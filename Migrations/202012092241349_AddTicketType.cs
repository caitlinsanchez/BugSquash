namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "TicketTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "TicketType_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "TicketType_Id");
            AddForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes");
            DropIndex("dbo.Tickets", new[] { "TicketType_Id" });
            DropColumn("dbo.Tickets", "TicketType_Id");
            DropColumn("dbo.Tickets", "TicketTypeId");
            DropTable("dbo.TicketTypes");
        }
    }
}

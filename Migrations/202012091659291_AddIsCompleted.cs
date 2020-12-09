namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCompleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "IsCompleted");
        }
    }
}

namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelBacking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Name", c => c.String(maxLength: 255));
        }
    }
}

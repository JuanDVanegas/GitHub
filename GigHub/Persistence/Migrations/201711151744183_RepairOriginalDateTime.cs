namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairOriginalDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OrigianalDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OrigianalDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OriginalDateTime");
        }
    }
}

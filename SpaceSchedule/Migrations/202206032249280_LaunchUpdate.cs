namespace SpaceSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaunchUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Launches", "LaunchName", c => c.String());
            AddColumn("dbo.Launches", "LaunchInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Launches", "LaunchInfo");
            DropColumn("dbo.Launches", "LaunchName");
        }
    }
}

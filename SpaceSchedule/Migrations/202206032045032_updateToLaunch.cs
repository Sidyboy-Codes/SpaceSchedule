namespace SpaceSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateToLaunch : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Launches", "LaunchTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Launches", "LaunchTime", c => c.DateTime(nullable: false));
        }
    }
}

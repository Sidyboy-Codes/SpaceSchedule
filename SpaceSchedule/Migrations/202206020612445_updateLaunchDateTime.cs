namespace SpaceSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLaunchDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Launches", "LaunchDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Launches", "LaunchTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Launches", "LaunchTime");
            DropColumn("dbo.Launches", "LaunchDate");
        }
    }
}

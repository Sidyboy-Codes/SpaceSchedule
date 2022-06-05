namespace SpaceSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Launch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Launches",
                c => new
                    {
                        LaunchId = c.Int(nullable: false, identity: true),
                        RocketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LaunchId)
                .ForeignKey("dbo.Rockets", t => t.RocketID, cascadeDelete: true)
                .Index(t => t.RocketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Launches", "RocketID", "dbo.Rockets");
            DropIndex("dbo.Launches", new[] { "RocketID" });
            DropTable("dbo.Launches");
        }
    }
}

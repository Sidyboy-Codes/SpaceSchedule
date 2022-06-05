namespace SpaceSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rockets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rockets",
                c => new
                    {
                        RocketID = c.Int(nullable: false, identity: true),
                        RocketName = c.String(),
                        RocketInfo = c.String(),
                        SpaceAgencyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RocketID)
                .ForeignKey("dbo.SpaceAgencies", t => t.SpaceAgencyID, cascadeDelete: true)
                .Index(t => t.SpaceAgencyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rockets", "SpaceAgencyID", "dbo.SpaceAgencies");
            DropIndex("dbo.Rockets", new[] { "SpaceAgencyID" });
            DropTable("dbo.Rockets");
        }
    }
}

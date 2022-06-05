namespace SpaceSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpaceAgencies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpaceAgencies",
                c => new
                    {
                        SpaceAgencyID = c.Int(nullable: false, identity: true),
                        SpaceAgencyName = c.String(),
                        SpaceAgencyInfo = c.String(),
                    })
                .PrimaryKey(t => t.SpaceAgencyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpaceAgencies");
        }
    }
}

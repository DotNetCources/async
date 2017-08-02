namespace BinaryWeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RequestTown = c.String(),
                        RequestDate = c.String(),
                        RequestDays = c.Int(nullable: false),
                        RequestAvgTemp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        TownId = c.Int(nullable: false, identity: true),
                        TownName = c.String(),
                    })
                .PrimaryKey(t => t.TownId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Towns");
            DropTable("dbo.Requests");
        }
    }
}

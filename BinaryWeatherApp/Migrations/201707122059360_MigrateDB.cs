namespace BinaryWeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "RequestTemp", c => c.Double(nullable: false));
            AddColumn("dbo.Requests", "RequestImg", c => c.String());
            DropColumn("dbo.Requests", "RequestAvgTemp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "RequestAvgTemp", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "RequestImg");
            DropColumn("dbo.Requests", "RequestTemp");
        }
    }
}

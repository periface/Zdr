namespace Zdr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitiesAndZones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MapZones", "City_Id", c => c.Int());
            CreateIndex("dbo.MapZones", "City_Id");
            AddForeignKey("dbo.MapZones", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapZones", "City_Id", "dbo.Cities");
            DropIndex("dbo.MapZones", new[] { "City_Id" });
            DropColumn("dbo.MapZones", "City_Id");
        }
    }
}

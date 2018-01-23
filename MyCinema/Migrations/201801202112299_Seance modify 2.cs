namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seancemodify2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seance", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seance", "Date", c => c.DateTime(nullable: false));
        }
    }
}

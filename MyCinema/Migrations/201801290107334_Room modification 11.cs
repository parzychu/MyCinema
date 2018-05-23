namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roommodification11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Room", name: "CinemaId", newName: "Cinema_Id");
            RenameIndex(table: "dbo.Room", name: "IX_CinemaId", newName: "IX_Cinema_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Room", name: "IX_Cinema_Id", newName: "IX_CinemaId");
            RenameColumn(table: "dbo.Room", name: "Cinema_Id", newName: "CinemaId");
        }
    }
}

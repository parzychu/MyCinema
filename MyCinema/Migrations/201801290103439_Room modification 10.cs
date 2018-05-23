namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roommodification10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seat", "RoomId", "dbo.Room");
            AddForeignKey("dbo.Seat", "RoomId", "dbo.Room", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seat", "RoomId", "dbo.Room");
            AddForeignKey("dbo.Seat", "RoomId", "dbo.Room", "Id");
        }
    }
}

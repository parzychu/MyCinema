namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roommodification3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seance", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Seat", "RoomId", "dbo.Room");
            DropPrimaryKey("dbo.Room");
            AlterColumn("dbo.Room", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Room", "Id");
            AddForeignKey("dbo.Seance", "Room_Id", "dbo.Room", "Id");
            AddForeignKey("dbo.Seat", "RoomId", "dbo.Room", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seat", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Seance", "Room_Id", "dbo.Room");
            DropPrimaryKey("dbo.Room");
            AlterColumn("dbo.Room", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Room", "Id");
            AddForeignKey("dbo.Seat", "RoomId", "dbo.Room", "Id");
            AddForeignKey("dbo.Seance", "Room_Id", "dbo.Room", "Id");
        }
    }
}

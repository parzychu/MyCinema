namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seance", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Seance", "RoomId", "dbo.Room");
            DropIndex("dbo.Seance", new[] { "MovieId" });
            DropIndex("dbo.Seance", new[] { "RoomId" });
            RenameColumn(table: "dbo.Seance", name: "MovieId", newName: "Movie_Id");
            RenameColumn(table: "dbo.Seance", name: "RoomId", newName: "Room_Id");
            AlterColumn("dbo.Seance", "Movie_Id", c => c.Int());
            AlterColumn("dbo.Seance", "Room_Id", c => c.Int());
            CreateIndex("dbo.Seance", "Movie_Id");
            CreateIndex("dbo.Seance", "Room_Id");
            AddForeignKey("dbo.Seance", "Movie_Id", "dbo.Movie", "Id");
            AddForeignKey("dbo.Seance", "Room_Id", "dbo.Room", "Id");
            DropColumn("dbo.Seance", "CinemaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seance", "CinemaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seance", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Seance", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.Seance", new[] { "Room_Id" });
            DropIndex("dbo.Seance", new[] { "Movie_Id" });
            AlterColumn("dbo.Seance", "Room_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Seance", "Movie_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Seance", name: "Room_Id", newName: "RoomId");
            RenameColumn(table: "dbo.Seance", name: "Movie_Id", newName: "MovieId");
            CreateIndex("dbo.Seance", "RoomId");
            CreateIndex("dbo.Seance", "MovieId");
            AddForeignKey("dbo.Seance", "RoomId", "dbo.Room", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Seance", "MovieId", "dbo.Movie", "Id", cascadeDelete: true);
        }
    }
}

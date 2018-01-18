namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seance", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.Seance", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Seance", name: "Movie_Id", newName: "MovieId");
            AlterColumn("dbo.Seance", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seance", "MovieId");
            AddForeignKey("dbo.Seance", "MovieId", "dbo.Movie", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seance", "MovieId", "dbo.Movie");
            DropIndex("dbo.Seance", new[] { "MovieId" });
            AlterColumn("dbo.Seance", "MovieId", c => c.Int());
            RenameColumn(table: "dbo.Seance", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Seance", "Movie_Id");
            AddForeignKey("dbo.Seance", "Movie_Id", "dbo.Movie", "Id");
        }
    }
}

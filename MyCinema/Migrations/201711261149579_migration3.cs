namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seance", "Id", "dbo.Cinema");
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance");
            DropIndex("dbo.Seance", new[] { "Id" });
            DropIndex("dbo.Seance", new[] { "Movie_Id" });
            DropPrimaryKey("dbo.Seance");
            AddColumn("dbo.Cinema", "Seance_Id", c => c.Int());
            AlterColumn("dbo.Seance", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Seance", "Movie_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Seance", "Id");
            CreateIndex("dbo.Cinema", "Seance_Id");
            CreateIndex("dbo.Seance", "Movie_Id");
            AddForeignKey("dbo.Cinema", "Seance_Id", "dbo.Seance", "Id");
            AddForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.Cinema", "Seance_Id", "dbo.Seance");
            DropIndex("dbo.Seance", new[] { "Movie_Id" });
            DropIndex("dbo.Cinema", new[] { "Seance_Id" });
            DropPrimaryKey("dbo.Seance");
            AlterColumn("dbo.Seance", "Movie_Id", c => c.Int());
            AlterColumn("dbo.Seance", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Cinema", "Seance_Id");
            AddPrimaryKey("dbo.Seance", "Id");
            CreateIndex("dbo.Seance", "Movie_Id");
            CreateIndex("dbo.Seance", "Id");
            AddForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Seance", "Id", "dbo.Cinema", "Id");
        }
    }
}

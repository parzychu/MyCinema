namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seancemodify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.SeatSeances", "Seance_Id", "dbo.Seance");
            DropPrimaryKey("dbo.Seance");
            AlterColumn("dbo.Seance", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Seance", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Seance", "Time", c => c.String());
            AddPrimaryKey("dbo.Seance", "Id");
            AddForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeatSeances", "Seance_Id", "dbo.Seance", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeatSeances", "Seance_Id", "dbo.Seance");
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropPrimaryKey("dbo.Seance");
            AlterColumn("dbo.Seance", "Time", c => c.String(nullable: false));
            AlterColumn("dbo.Seance", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Seance", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Seance", "Id");
            AddForeignKey("dbo.SeatSeances", "Seance_Id", "dbo.Seance", "Id");
            AddForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
        }
    }
}

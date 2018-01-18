namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance");
            DropPrimaryKey("dbo.Seance");
            AlterColumn("dbo.Seance", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Seance", "Id");
            AddForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropPrimaryKey("dbo.Seance");
            AlterColumn("dbo.Seance", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Seance", "Id");
            AddForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
        }
    }
}

namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeatSeances", "SeatId", "dbo.Seat");
            DropForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance");
            DropIndex("dbo.SeatSeances", new[] { "SeatId" });
            DropIndex("dbo.SeatSeances", new[] { "SeanceId" });
            RenameColumn(table: "dbo.SeatSeances", name: "SeatId", newName: "Seat_Id");
            RenameColumn(table: "dbo.SeatSeances", name: "SeanceId", newName: "Seance_Id");
            DropPrimaryKey("dbo.SeatSeances");
            AddColumn("dbo.SeatSeances", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SeatSeances", "Seat_Id", c => c.Int());
            AlterColumn("dbo.SeatSeances", "Seance_Id", c => c.Int());
            AddPrimaryKey("dbo.SeatSeances", "Id");
            CreateIndex("dbo.SeatSeances", "Seance_Id");
            CreateIndex("dbo.SeatSeances", "Seat_Id");
            AddForeignKey("dbo.SeatSeances", "Seat_Id", "dbo.Seat", "Id");
            AddForeignKey("dbo.SeatSeances", "Seance_Id", "dbo.Seance", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeatSeances", "Seance_Id", "dbo.Seance");
            DropForeignKey("dbo.SeatSeances", "Seat_Id", "dbo.Seat");
            DropIndex("dbo.SeatSeances", new[] { "Seat_Id" });
            DropIndex("dbo.SeatSeances", new[] { "Seance_Id" });
            DropPrimaryKey("dbo.SeatSeances");
            AlterColumn("dbo.SeatSeances", "Seance_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SeatSeances", "Seat_Id", c => c.Int(nullable: false));
            DropColumn("dbo.SeatSeances", "Id");
            AddPrimaryKey("dbo.SeatSeances", new[] { "SeatId", "SeanceId" });
            RenameColumn(table: "dbo.SeatSeances", name: "Seance_Id", newName: "SeanceId");
            RenameColumn(table: "dbo.SeatSeances", name: "Seat_Id", newName: "SeatId");
            CreateIndex("dbo.SeatSeances", "SeanceId");
            CreateIndex("dbo.SeatSeances", "SeatId");
            AddForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeatSeances", "SeatId", "dbo.Seat", "Id", cascadeDelete: true);
        }
    }
}

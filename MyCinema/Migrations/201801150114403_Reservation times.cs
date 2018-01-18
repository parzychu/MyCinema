namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservationtimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeatSeances", "PreReserved", c => c.Boolean(nullable: false));
            AddColumn("dbo.SeatSeances", "PreReservationTime", c => c.DateTime());
            AlterColumn("dbo.Reservation", "CreatedTime", c => c.DateTime());
            AlterColumn("dbo.Reservation", "ConfirmedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservation", "ConfirmedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservation", "CreatedTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.SeatSeances", "PreReservationTime");
            DropColumn("dbo.SeatSeances", "PreReserved");
        }
    }
}

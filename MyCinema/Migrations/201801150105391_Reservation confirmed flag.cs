namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservationconfirmedflag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "IsConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "IsConfirmed");
        }
    }
}

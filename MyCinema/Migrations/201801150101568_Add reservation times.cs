namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addreservationtimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservation", "ConfirmedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "ConfirmedTime");
            DropColumn("dbo.Reservation", "CreatedTime");
        }
    }
}

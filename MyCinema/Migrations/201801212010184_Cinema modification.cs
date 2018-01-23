namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cinemamodification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cinema", "RoomCount", c => c.Int(nullable: false));
            AddColumn("dbo.Cinema", "City", c => c.String());
            AddColumn("dbo.Cinema", "PictureUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cinema", "PictureUrl");
            DropColumn("dbo.Cinema", "City");
            DropColumn("dbo.Cinema", "RoomCount");
        }
    }
}

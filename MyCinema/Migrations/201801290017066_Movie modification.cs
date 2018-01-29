namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviemodification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "PictureUrl", c => c.String());
            AddColumn("dbo.Movie", "Description", c => c.String());
            AddColumn("dbo.Movie", "Genre", c => c.String());
            AddColumn("dbo.Movie", "ProductionCountry", c => c.String());
            AlterColumn("dbo.Movie", "Title", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Movie", "DirectorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "DirectorName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movie", "Title", c => c.String(nullable: false, maxLength: 220, unicode: false));
            DropColumn("dbo.Movie", "ProductionCountry");
            DropColumn("dbo.Movie", "Genre");
            DropColumn("dbo.Movie", "Description");
            DropColumn("dbo.Movie", "PictureUrl");
        }
    }
}

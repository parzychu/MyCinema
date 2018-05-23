namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roommodification8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Room", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Room", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

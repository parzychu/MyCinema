namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cinema", "Seance_Id", "dbo.Seance");
            DropIndex("dbo.Cinema", new[] { "Seance_Id" });
            AddColumn("dbo.Seance", "Cinema_Id", c => c.Int());
            CreateIndex("dbo.Seance", "Cinema_Id");
            AddForeignKey("dbo.Seance", "Cinema_Id", "dbo.Cinema", "Id");
            DropColumn("dbo.Cinema", "Seance_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cinema", "Seance_Id", c => c.Int());
            DropForeignKey("dbo.Seance", "Cinema_Id", "dbo.Cinema");
            DropIndex("dbo.Seance", new[] { "Cinema_Id" });
            DropColumn("dbo.Seance", "Cinema_Id");
            CreateIndex("dbo.Cinema", "Seance_Id");
            AddForeignKey("dbo.Cinema", "Seance_Id", "dbo.Seance", "Id");
        }
    }
}

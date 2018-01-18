namespace MyCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 50),
                        Telephone = c.String(nullable: false, maxLength: 20),
                        Details = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CinemaId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        RowCount = c.Int(nullable: false),
                        ColumnCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinema", t => t.CinemaId)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Seat",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.SeatSeances",
                c => new
                    {
                        SeatId = c.Int(nullable: false),
                        SeanceId = c.Int(nullable: false),
                        IsAvaliable = c.Boolean(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        Reservations_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.SeatId, t.SeanceId })
                .ForeignKey("dbo.Reservation", t => t.Reservations_Id)
                .ForeignKey("dbo.Seance", t => t.SeanceId, cascadeDelete: true)
                .ForeignKey("dbo.Seat", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.SeatId)
                .Index(t => t.SeanceId)
                .Index(t => t.Reservations_Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SeanceId = c.Int(nullable: false),
                        Test = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seance", t => t.SeanceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SeanceId);
            
            CreateTable(
                "dbo.Seance",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Time = c.String(nullable: false),
                        CinemaId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Cinema", t => t.Id)
                .ForeignKey("dbo.Movie", t => t.Movie_Id)
                .Index(t => t.Id)
                .Index(t => t.RoomId)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 220, unicode: false),
                        Release = c.DateTime(nullable: false, storeType: "date"),
                        DirectorName = c.String(nullable: false, maxLength: 50),
                        RunningTime = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Seance", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.Seance", "Id", "dbo.Cinema");
            DropForeignKey("dbo.Room", "CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.Seat", "RoomId", "dbo.Room");
            DropForeignKey("dbo.SeatSeances", "SeatId", "dbo.Seat");
            DropForeignKey("dbo.SeatSeances", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.SeatSeances", "Reservations_Id", "dbo.Reservation");
            DropForeignKey("dbo.Reservation", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservation", "SeanceId", "dbo.Seance");
            DropForeignKey("dbo.Seance", "RoomId", "dbo.Room");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Seance", new[] { "Movie_Id" });
            DropIndex("dbo.Seance", new[] { "RoomId" });
            DropIndex("dbo.Seance", new[] { "Id" });
            DropIndex("dbo.Reservation", new[] { "SeanceId" });
            DropIndex("dbo.Reservation", new[] { "UserId" });
            DropIndex("dbo.SeatSeances", new[] { "Reservations_Id" });
            DropIndex("dbo.SeatSeances", new[] { "SeanceId" });
            DropIndex("dbo.SeatSeances", new[] { "SeatId" });
            DropIndex("dbo.Seat", new[] { "RoomId" });
            DropIndex("dbo.Room", new[] { "CinemaId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Movie");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Seance");
            DropTable("dbo.Reservation");
            DropTable("dbo.SeatSeances");
            DropTable("dbo.Seat");
            DropTable("dbo.Room");
            DropTable("dbo.Cinema");
        }
    }
}

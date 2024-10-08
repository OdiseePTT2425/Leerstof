namespace WithoutDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Merk = c.String(nullable: false, maxLength: 50),
                        Reeks = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(nullable: false, maxLength: 200),
                        Achternaam = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCars",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Car_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Car_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCars", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.UserCars", "User_Id", "dbo.Users");
            DropIndex("dbo.UserCars", new[] { "Car_Id" });
            DropIndex("dbo.UserCars", new[] { "User_Id" });
            DropTable("dbo.UserCars");
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}

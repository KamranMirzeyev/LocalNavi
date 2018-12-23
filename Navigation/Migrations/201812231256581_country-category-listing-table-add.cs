namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countrycategorylistingtableadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keyword = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Website = c.String(),
                        Address = c.String(),
                        TemporaryAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        CountryId = c.String(),
                        ZipCode = c.String(),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        OwnerName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        WebsiteCompany = c.String(),
                        OwnerDesignation = c.String(),
                        Company = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        GooglePlus = c.String(),
                        Linkedin = c.String(),
                        Description = c.String(),
                        Internet = c.Boolean(nullable: false),
                        BikeParking = c.Boolean(nullable: false),
                        Smoking = c.Boolean(nullable: false),
                        StreetParking = c.Boolean(nullable: false),
                        CreditCart = c.Boolean(nullable: false),
                        AlarmSistem = c.Boolean(nullable: false),
                        DepanneurBuild = c.Boolean(nullable: false),
                        Janitor = c.Boolean(nullable: false),
                        SecurityCamera = c.Boolean(nullable: false),
                        DoorAttendant = c.Boolean(nullable: false),
                        LaundryRoom = c.Boolean(nullable: false),
                        AttachedgGarage = c.Boolean(nullable: false),
                        Elevator = c.Boolean(nullable: false),
                        WheelchairAccessible = c.Boolean(nullable: false),
                        HeatingAndHotWater = c.Boolean(nullable: false),
                        WdOpenTime = c.DateTime(nullable: false),
                        WdCloseTime = c.DateTime(nullable: false),
                        WeOpenTime = c.DateTime(nullable: false),
                        WeCloseTime = c.DateTime(nullable: false),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Listings", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Listings", new[] { "Country_Id" });
            DropIndex("dbo.Listings", new[] { "CategoryId" });
            DropTable("dbo.Listings");
            DropTable("dbo.Countries");
            DropTable("dbo.Categories");
        }
    }
}

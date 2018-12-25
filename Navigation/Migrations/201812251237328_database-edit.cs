namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseedit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Listings", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Listings", new[] { "Country_Id" });
            CreateTable(
                "dbo.CategoryServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ListingId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rating = c.Byte(nullable: false),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ListingId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                        Like = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.ListPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListId = c.Int(nullable: false),
                        Photo = c.String(),
                        Listing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.Listing_Id)
                .Index(t => t.Listing_Id);
            
            CreateTable(
                "dbo.WorkHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        WeekNo = c.Int(nullable: false),
                        OpenHour = c.DateTime(nullable: false),
                        CloseHour = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
            AddColumn("dbo.Listings", "Slogan", c => c.String());
            AddColumn("dbo.Listings", "CityId", c => c.String());
            AddColumn("dbo.Listings", "UserId", c => c.String());
            AddColumn("dbo.Listings", "City_Id", c => c.Int());
            AddColumn("dbo.Listings", "User_Id", c => c.Int());
            AlterColumn("dbo.Listings", "Lat", c => c.String());
            AlterColumn("dbo.Listings", "Lng", c => c.String());
            AlterColumn("dbo.Listings", "Description", c => c.String(storeType: "ntext"));
            CreateIndex("dbo.Listings", "City_Id");
            CreateIndex("dbo.Listings", "User_Id");
            AddForeignKey("dbo.Listings", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Listings", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Listings", "Keyword");
            DropColumn("dbo.Listings", "TemporaryAddress");
            DropColumn("dbo.Listings", "City");
            DropColumn("dbo.Listings", "State");
            DropColumn("dbo.Listings", "CountryId");
            DropColumn("dbo.Listings", "ZipCode");
            DropColumn("dbo.Listings", "OwnerName");
            DropColumn("dbo.Listings", "Email");
            DropColumn("dbo.Listings", "WebsiteCompany");
            DropColumn("dbo.Listings", "OwnerDesignation");
            DropColumn("dbo.Listings", "Company");
            DropColumn("dbo.Listings", "Facebook");
            DropColumn("dbo.Listings", "Twitter");
            DropColumn("dbo.Listings", "GooglePlus");
            DropColumn("dbo.Listings", "Linkedin");
            DropColumn("dbo.Listings", "Internet");
            DropColumn("dbo.Listings", "BikeParking");
            DropColumn("dbo.Listings", "Smoking");
            DropColumn("dbo.Listings", "StreetParking");
            DropColumn("dbo.Listings", "CreditCart");
            DropColumn("dbo.Listings", "AlarmSistem");
            DropColumn("dbo.Listings", "DepanneurBuild");
            DropColumn("dbo.Listings", "Janitor");
            DropColumn("dbo.Listings", "SecurityCamera");
            DropColumn("dbo.Listings", "DoorAttendant");
            DropColumn("dbo.Listings", "LaundryRoom");
            DropColumn("dbo.Listings", "AttachedgGarage");
            DropColumn("dbo.Listings", "Elevator");
            DropColumn("dbo.Listings", "WheelchairAccessible");
            DropColumn("dbo.Listings", "HeatingAndHotWater");
            DropColumn("dbo.Listings", "WdOpenTime");
            DropColumn("dbo.Listings", "WdCloseTime");
            DropColumn("dbo.Listings", "WeOpenTime");
            DropColumn("dbo.Listings", "WeCloseTime");
            DropColumn("dbo.Listings", "Country_Id");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Listings", "Country_Id", c => c.Int());
            AddColumn("dbo.Listings", "WeCloseTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Listings", "WeOpenTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Listings", "WdCloseTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Listings", "WdOpenTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Listings", "HeatingAndHotWater", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "WheelchairAccessible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "Elevator", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "AttachedgGarage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "LaundryRoom", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "DoorAttendant", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "SecurityCamera", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "Janitor", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "DepanneurBuild", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "AlarmSistem", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "CreditCart", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "StreetParking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "Smoking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "BikeParking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "Internet", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listings", "Linkedin", c => c.String());
            AddColumn("dbo.Listings", "GooglePlus", c => c.String());
            AddColumn("dbo.Listings", "Twitter", c => c.String());
            AddColumn("dbo.Listings", "Facebook", c => c.String());
            AddColumn("dbo.Listings", "Company", c => c.String());
            AddColumn("dbo.Listings", "OwnerDesignation", c => c.String());
            AddColumn("dbo.Listings", "WebsiteCompany", c => c.String());
            AddColumn("dbo.Listings", "Email", c => c.String());
            AddColumn("dbo.Listings", "OwnerName", c => c.String());
            AddColumn("dbo.Listings", "ZipCode", c => c.String());
            AddColumn("dbo.Listings", "CountryId", c => c.String());
            AddColumn("dbo.Listings", "State", c => c.String());
            AddColumn("dbo.Listings", "City", c => c.String());
            AddColumn("dbo.Listings", "TemporaryAddress", c => c.String());
            AddColumn("dbo.Listings", "Keyword", c => c.String());
            DropForeignKey("dbo.ListServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.WorkHours", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.ListServices", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.ListPhotoes", "Listing_Id", "dbo.Listings");
            DropForeignKey("dbo.Reactions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Listings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reactions", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.CommentPhotoes", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Listings", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.CategoryServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.CategoryServices", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WorkHours", new[] { "ListingId" });
            DropIndex("dbo.ListPhotoes", new[] { "Listing_Id" });
            DropIndex("dbo.Reactions", new[] { "CommentId" });
            DropIndex("dbo.Reactions", new[] { "UserId" });
            DropIndex("dbo.CommentPhotoes", new[] { "CommentId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ListingId" });
            DropIndex("dbo.Listings", new[] { "User_Id" });
            DropIndex("dbo.Listings", new[] { "City_Id" });
            DropIndex("dbo.ListServices", new[] { "ServiceId" });
            DropIndex("dbo.ListServices", new[] { "ListingId" });
            DropIndex("dbo.CategoryServices", new[] { "ServiceId" });
            DropIndex("dbo.CategoryServices", new[] { "CategoryId" });
            AlterColumn("dbo.Listings", "Description", c => c.String());
            AlterColumn("dbo.Listings", "Lng", c => c.Double(nullable: false));
            AlterColumn("dbo.Listings", "Lat", c => c.Double(nullable: false));
            DropColumn("dbo.Listings", "User_Id");
            DropColumn("dbo.Listings", "City_Id");
            DropColumn("dbo.Listings", "UserId");
            DropColumn("dbo.Listings", "CityId");
            DropColumn("dbo.Listings", "Slogan");
            DropTable("dbo.WorkHours");
            DropTable("dbo.ListPhotoes");
            DropTable("dbo.Reactions");
            DropTable("dbo.CommentPhotoes");
            DropTable("dbo.Comments");
            DropTable("dbo.Cities");
            DropTable("dbo.ListServices");
            DropTable("dbo.Services");
            DropTable("dbo.CategoryServices");
            CreateIndex("dbo.Listings", "Country_Id");
            AddForeignKey("dbo.Listings", "Country_Id", "dbo.Countries", "Id");
        }
    }
}

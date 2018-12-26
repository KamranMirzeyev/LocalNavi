namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Listings", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Listings", "User_Id", "dbo.Users");
            DropIndex("dbo.Listings", new[] { "City_Id" });
            DropIndex("dbo.Listings", new[] { "User_Id" });
            DropColumn("dbo.Listings", "CityId");
            DropColumn("dbo.Listings", "UserId");
            RenameColumn(table: "dbo.Listings", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Listings", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Listings", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Listings", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Listings", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Listings", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Listings", "CityId");
            CreateIndex("dbo.Listings", "UserId");
            AddForeignKey("dbo.Listings", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Listings", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Listings", "CityId", "dbo.Cities");
            DropIndex("dbo.Listings", new[] { "UserId" });
            DropIndex("dbo.Listings", new[] { "CityId" });
            AlterColumn("dbo.Listings", "UserId", c => c.Int());
            AlterColumn("dbo.Listings", "CityId", c => c.Int());
            AlterColumn("dbo.Listings", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "CityId", c => c.String());
            RenameColumn(table: "dbo.Listings", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Listings", name: "CityId", newName: "City_Id");
            AddColumn("dbo.Listings", "UserId", c => c.String(nullable: false));
            AddColumn("dbo.Listings", "CityId", c => c.String());
            CreateIndex("dbo.Listings", "User_Id");
            CreateIndex("dbo.Listings", "City_Id");
            AddForeignKey("dbo.Listings", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Listings", "City_Id", "dbo.Cities", "Id");
        }
    }
}

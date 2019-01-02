namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phototable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        PlacePhoto = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "ListingId", "dbo.Listings");
            DropIndex("dbo.Photos", new[] { "ListingId" });
            DropTable("dbo.Photos");
        }
    }
}

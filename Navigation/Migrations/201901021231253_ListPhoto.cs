namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListPhoto : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListPhotoes", "Listing_Id", "dbo.Listings");
            DropIndex("dbo.ListPhotoes", new[] { "Listing_Id" });
            DropTable("dbo.ListPhotoes");
        }
    }
}

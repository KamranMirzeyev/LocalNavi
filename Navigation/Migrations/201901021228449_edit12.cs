namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListPhotoes", "Listing_Id", "dbo.Listings");
            DropIndex("dbo.ListPhotoes", new[] { "Listing_Id" });
            DropTable("dbo.ListPhotoes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ListPhotoes", "Listing_Id");
            AddForeignKey("dbo.ListPhotoes", "Listing_Id", "dbo.Listings", "Id");
        }
    }
}

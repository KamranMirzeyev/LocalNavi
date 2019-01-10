namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finish1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Listings", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "Description", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Listings", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "Lat", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "Lng", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listings", "Lng", c => c.String());
            AlterColumn("dbo.Listings", "Lat", c => c.String());
            AlterColumn("dbo.Listings", "Phone", c => c.String());
            AlterColumn("dbo.Listings", "Address", c => c.String());
            AlterColumn("dbo.Listings", "Description", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Listings", "Website", c => c.String());
            AlterColumn("dbo.Listings", "Title", c => c.String());
        }
    }
}

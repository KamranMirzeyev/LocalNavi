namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listingedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "Facebook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listings", "Facebook");
        }
    }
}

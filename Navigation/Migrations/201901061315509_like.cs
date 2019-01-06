namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class like : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reactions", "Like", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reactions", "Like", c => c.Boolean(nullable: false));
        }
    }
}

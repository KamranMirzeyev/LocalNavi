namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weekno : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkHours", "WeekNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkHours", "WeekNo", c => c.Int(nullable: false));
        }
    }
}

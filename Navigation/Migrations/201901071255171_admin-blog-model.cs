namespace Navigation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminblogmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Orderby = c.Int(nullable: false),
                        BigPhoto = c.String(),
                        SmallPhoto = c.String(),
                        Title = c.String(nullable: false, maxLength: 250),
                        CreateAt = c.DateTime(nullable: false),
                        BlogType = c.String(nullable: false, maxLength: 50),
                        Info = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
        }
    }
}

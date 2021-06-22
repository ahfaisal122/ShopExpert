namespace ShopEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.PageInfoes",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        PageOwnerName = c.String(),
                        OwnerAddress = c.String(),
                        OwnersNumber = c.String(),
                        Description = c.String(),
                        PageFbLink = c.String(),
                        PageWebsite = c.String(),
                        Preference = c.Binary(),
                        Delivery = c.String(),
                        Picture = c.Binary(),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.PageInfoCats",
                c => new
                    {
                        PageInfo_PageId = c.String(nullable: false, maxLength: 128),
                        Cat_CategoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PageInfo_PageId, t.Cat_CategoryId })
                .ForeignKey("dbo.PageInfoes", t => t.PageInfo_PageId, cascadeDelete: true)
                .ForeignKey("dbo.Cats", t => t.Cat_CategoryId, cascadeDelete: true)
                .Index(t => t.PageInfo_PageId)
                .Index(t => t.Cat_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageInfoCats", "Cat_CategoryId", "dbo.Cats");
            DropForeignKey("dbo.PageInfoCats", "PageInfo_PageId", "dbo.PageInfoes");
            DropIndex("dbo.PageInfoCats", new[] { "Cat_CategoryId" });
            DropIndex("dbo.PageInfoCats", new[] { "PageInfo_PageId" });
            DropTable("dbo.PageInfoCats");
            DropTable("dbo.PageInfoes");
            DropTable("dbo.Cats");
        }
    }
}

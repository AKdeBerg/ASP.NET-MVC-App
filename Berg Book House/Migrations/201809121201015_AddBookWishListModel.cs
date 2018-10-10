namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookWishListModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishListBooks",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        CategoryId = c.Byte(nullable: false),
                        BookCover = c.Binary(),
                        Purpose = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishListBooks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WishListBooks", new[] { "CategoryId" });
            DropTable("dbo.WishListBooks");
        }
    }
}

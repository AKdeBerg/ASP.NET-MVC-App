namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAuthorFromForeignKeyToNormalColumnBookTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            AddColumn("dbo.Books", "Author", c => c.String());
            DropColumn("dbo.Books", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorId", c => c.Byte(nullable: false));
            DropColumn("dbo.Books", "Author");
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}

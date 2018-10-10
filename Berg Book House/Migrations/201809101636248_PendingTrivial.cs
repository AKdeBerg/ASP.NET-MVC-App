namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingTrivial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Authors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.AuthorId);
            
        }
    }
}

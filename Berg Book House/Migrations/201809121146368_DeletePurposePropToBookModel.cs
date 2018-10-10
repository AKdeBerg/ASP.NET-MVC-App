namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePurposePropToBookModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Purpose");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Purpose", c => c.String());
        }
    }
}

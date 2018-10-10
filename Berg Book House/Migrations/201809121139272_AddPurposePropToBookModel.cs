namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurposePropToBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Purpose", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Purpose");
        }
    }
}

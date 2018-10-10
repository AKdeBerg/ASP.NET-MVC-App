namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotaionToStringTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}

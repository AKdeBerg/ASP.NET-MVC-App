namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreventIdFromAutoAssigning : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "BookId", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "BookId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "BookId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Books", "BookId");
        }
    }
}

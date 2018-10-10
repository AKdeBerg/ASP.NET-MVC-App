namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCoverPhotoInBookTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CoverPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "CoverPhoto");
        }
    }
}

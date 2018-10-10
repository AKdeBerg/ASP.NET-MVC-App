namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDataAnnotationToId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.WishListBooks");
            AlterColumn("dbo.WishListBooks", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.WishListBooks", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.WishListBooks");
            AlterColumn("dbo.WishListBooks", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.WishListBooks", "Id");
        }
    }
}

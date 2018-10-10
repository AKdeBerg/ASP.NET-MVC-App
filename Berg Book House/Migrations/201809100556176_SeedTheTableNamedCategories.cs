namespace Berg_Book_House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTheTableNamedCategories : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Categories (CategoryId, Name) Values (1, 'Non-Fiction')");
            Sql("Insert Into Categories (CategoryId, Name) Values (2, 'Business')");
            Sql("Insert Into Categories (CategoryId, Name) Values (3, 'Science')");
            Sql("Insert Into Categories (CategoryId, Name) Values (4, 'Language')");
            Sql("Insert Into Categories (CategoryId, Name) Values (5, 'Fiction')");
            Sql("Insert Into Categories (CategoryId, Name) Values (6, 'Manga')");
            Sql("Insert Into Categories (CategoryId, Name) Values (7, 'Programming')");
            Sql("Insert Into Categories (CategoryId, Name) Values (8, 'Math')");
            Sql("Insert Into Categories (CategoryId, Name) Values (9, 'Psychology')");
            Sql("Insert Into Categories (CategoryId, Name) Values (10, 'Leadership')");
            Sql("Insert Into Categories (CategoryId, Name) Values (11, 'Writting')");
            Sql("Insert Into Categories (CategoryId, Name) Values (12, 'Biography')");
        }
        
        public override void Down()
        {
        }
    }
}

namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAvailableToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "IsAvailable");
        }
    }
}

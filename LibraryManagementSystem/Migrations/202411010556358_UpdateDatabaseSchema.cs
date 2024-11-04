namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BorrowBooks", name: "User_UserId", newName: "UserId");
            RenameIndex(table: "dbo.BorrowBooks", name: "IX_User_UserId", newName: "IX_UserId");
            AddColumn("dbo.BorrowBooks", "BorrowDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BorrowBooks", "BorrowDate");
            RenameIndex(table: "dbo.BorrowBooks", name: "IX_UserId", newName: "IX_User_UserId");
            RenameColumn(table: "dbo.BorrowBooks", name: "UserId", newName: "User_UserId");
        }
    }
}

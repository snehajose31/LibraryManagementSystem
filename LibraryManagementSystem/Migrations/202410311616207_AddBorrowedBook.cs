namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBorrowedBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowedBooks",
                c => new
                    {
                        BorrowedBookId = c.Int(nullable: false, identity: true),
                        DateBorrowed = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        IsReturned = c.Boolean(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowedBookId)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Book_BookId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowedBooks", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.BorrowedBooks", "Book_BookId", "dbo.Books");
            DropIndex("dbo.BorrowedBooks", new[] { "User_UserId" });
            DropIndex("dbo.BorrowedBooks", new[] { "Book_BookId" });
            DropTable("dbo.BorrowedBooks");
        }
    }
}

namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBorrowBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowBooks",
                c => new
                    {
                        BorrowedBookId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        DateBorrowed = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        IsReturned = c.Boolean(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowedBookId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowBooks", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.BorrowBooks", "BookId", "dbo.Books");
            DropIndex("dbo.BorrowBooks", new[] { "User_UserId" });
            DropIndex("dbo.BorrowBooks", new[] { "BookId" });
            DropTable("dbo.BorrowBooks");
        }
    }
}

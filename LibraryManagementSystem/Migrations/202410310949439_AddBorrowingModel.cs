namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBorrowingModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Books", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrowings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Borrowings", "BookId", "dbo.Books");
            DropIndex("dbo.Borrowings", new[] { "UserId" });
            DropIndex("dbo.Borrowings", new[] { "BookId" });
            DropColumn("dbo.Books", "Id");
            DropTable("dbo.Borrowings");
        }
    }
}

namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBorrowBookk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowBookks",
                c => new
                    {
                        BorrowId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowBookks", "UserId", "dbo.Users");
            DropForeignKey("dbo.BorrowBookks", "BookId", "dbo.Books");
            DropIndex("dbo.BorrowBookks", new[] { "BookId" });
            DropIndex("dbo.BorrowBookks", new[] { "UserId" });
            DropTable("dbo.BorrowBookks");
        }
    }
}

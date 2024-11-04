using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class LibraryContext : DbContext
    {
        internal object books;

        public LibraryContext() : base("LibraryConnectionString") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookIssue> BookIssues { get; set; }

        public DbSet<Borrowing> Borrowings { get; set; }

        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        public DbSet<BorrowBook> BorrowBooks { get; set; }

        public DbSet<BorrowBookk> BorrowBookks { get; set; }


        public DbSet<Borrows> Borrows { get; set; }
        public DbSet<bor> bors { get; set; }
        
    }
}
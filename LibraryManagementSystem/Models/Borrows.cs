using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Borrows
    {
        [Key]
        public int BorrowId { get; set; } // Change from BorrowedBookId to BorrowId

        public int UserId { get; set; } // Foreign key for User

        public int BookId { get; set; } // Foreign key for Book

        public DateTime BorrowedDate { get; set; } // Date when the book was borrowed

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
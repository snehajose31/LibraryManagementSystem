using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BorrowBookk
    {
        [Key]
        public int BorrowId { get; set; }

        // Foreign key for User (who is borrowing the book)
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Foreign key for Book (book being borrowed)
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        // Date when the book was borrowed
        [Required]
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        // Status to track if the book is returned
        public bool IsReturned { get; set; } = false;
    }
}
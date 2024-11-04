using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BorrowBook
    {
        [Key]
        public int BorrowedBookId { get; set; }

        // Foreign key for Book
        [ForeignKey("Book")]
        public int BookId { get; set; }

        // Navigation property for User
        [Required]
        public virtual User User { get; set; }

        // Navigation property for Book
        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public DateTime DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }

        public bool IsReturned { get; set; }
        public int UserId { get; internal set; }
        public DateTime BorrowDate { get; internal set; }
    }

}
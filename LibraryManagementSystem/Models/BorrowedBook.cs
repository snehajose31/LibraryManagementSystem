using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowedBookId { get; set; }

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
    }
}

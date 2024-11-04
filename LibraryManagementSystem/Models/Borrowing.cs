using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; } // Assuming you have a User model
        public DateTime BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; } // Navigation property
        public virtual User User { get; set; } // Navigation property (if you have a User model)
    }
}
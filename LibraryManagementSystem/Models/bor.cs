using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class bor
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public int UserId { get; set; } // Foreign Key to User

        [Required]
        public int BookId { get; set; } // Foreign Key to Book

        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        // Additional properties can be added as needed
    }
}

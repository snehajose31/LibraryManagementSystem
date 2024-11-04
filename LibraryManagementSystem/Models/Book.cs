using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; } // To track availability

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property for Category
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int Id { get; internal set; }
    }
}

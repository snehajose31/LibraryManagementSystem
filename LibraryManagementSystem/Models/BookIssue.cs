using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BookIssue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book is required.")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "User is required.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Issue Date is required.")]
        [Display(Name = "Issue Date")]
        public DateTime IssueDate { get; set; }
        [Required(ErrorMessage = "Due Date is required.")]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        // Navigation properties
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
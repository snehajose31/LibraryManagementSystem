using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        // Mock repository for borrowed books (replace with your actual database context in production)
        private static List<Book> _borrowedBooks = new List<Book>();

        // Mock database context (replace with your actual database context in production)
        private readonly LibraryContext _context;

        public BooksController()
        {
            _context = new LibraryContext();
        }

        // Action to handle borrowing a book
        [HttpPost]
        public ActionResult Borrow(int id)
        {
            var book = _context.Books.Find(id); // Retrieve book by ID from the database
            if (book != null && !_borrowedBooks.Any(b => b.Id == book.Id))
            {
                _borrowedBooks.Add(book); // Add book to the borrowed list if not already borrowed
            }
            return Json(new { success = true });
        }

        // Action to display the borrowed books for the user
        public ActionResult BorrowedBooks()
        {
            return View(_borrowedBooks); // Pass the borrowed books to the view
        }
    }
}

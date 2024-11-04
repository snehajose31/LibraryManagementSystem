using LibraryManagementSystem.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: User/UserDashboard
        public ActionResult UserDashboard()
        {
            var books = db.Books.Include("Category").ToList(); // Fetch books and include category data
            return View(books); // Pass the books list to the view
        }

        // GET: User/AddBorrowBook
        public ActionResult AddBorrowBook()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
            ViewBag.Books = new SelectList(db.Books.ToList(), "BookId", "Title"); // Now showing all books, not just available
            return View();
        }

        // POST: User/AddBorrowBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBorrowBook(BorrowBook borrowBook, int BookId)
        {
            // Get the current user ID (assuming user is authenticated)
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                // Handle the case where the user is not authenticated
                ModelState.AddModelError("", "You must be logged in to borrow a book.");
                // Re-populate dropdowns
                ViewBag.Categories = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
                ViewBag.Books = new SelectList(db.Books.ToList(), "BookId", "Title");
                return View(borrowBook);
            }

            if (ModelState.IsValid)
            {
                // Set properties
                borrowBook.BookId = BookId;
                borrowBook.DateBorrowed = DateTime.Now;
                borrowBook.IsReturned = false;

                // Assuming User is a navigation property and you have a method to get the user by ID
                borrowBook.User = db.Users.Find(userId); // Make sure to handle potential null here

                // Add to database
                db.BorrowBooks.Add(borrowBook);

                // Update the book's availability
                var book = db.Books.Find(BookId);
                if (book != null)
                {
                    book.IsAvailable = false;
                }

                db.SaveChanges();
                return RedirectToAction("UserDashboard"); // Redirect to user dashboard after success
            }

            // If model state is invalid, re-populate dropdowns
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
            ViewBag.Books = new SelectList(db.Books.ToList(), "BookId", "Title"); // Show all books on error
            return View(borrowBook);
        }

    }
}

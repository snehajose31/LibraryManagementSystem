using System;
using System.Linq;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BorController : Controller
    {
        private readonly LibraryContext _context;

        public BorController()
        {
            _context = new LibraryContext();
        }

        // GET: Bor
        public ActionResult Index()
        {
            var borrowedBooks = _context.bors.ToList(); // Fetch all borrowed books
            return View(borrowedBooks);
        }

        // GET: Bor/Create
        public ActionResult Create()
        {
            // Assuming you have a DbSet<Book> in your LibraryContext
            var books = _context.Books.ToList(); // Fetch all books
            ViewBag.BookList = new SelectList(books, "Id", "Title"); // Create SelectList for dropdown
            return View();
        }

        // POST: Bor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bor newBor)
        {
            if (ModelState.IsValid)
            {
                newBor.BorrowDate = DateTime.Now; // Set the borrow date to now
                _context.bors.Add(newBor); // Add the new borrow record
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("Index");
            }
            return View(newBor);
        }

        // You can add more actions (Edit, Delete, etc.) as needed
    }
}

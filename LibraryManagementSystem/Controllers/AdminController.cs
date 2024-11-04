using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Admin/ManageUsers
        public ActionResult ManageUsers()
        {
            var users = db.Users.ToList(); // Fetch all users from the database
            return View(users); // Pass the list of users to the view
        }

        // POST: Admin/ActivateUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                user.IsActive = true; // Set user to active
                db.SaveChanges();
            }
            return RedirectToAction("ManageUsers"); // Redirect after activation
        }

        // POST: Admin/DeactivateUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivateUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                user.IsActive = false; // Set user to inactive
                db.SaveChanges();
            }
            return RedirectToAction("ManageUsers"); // Redirect after deactivation
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult ManageCategories()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        // GET: Admin/AddCategory
        public ActionResult AddCategory()
        {
            return View();
        }

        // POST: Admin/AddCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("ManageCategories");
            }
            return View(category);
        }

        // Optional: Delete Category
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("ManageCategories");
        }


        ////////////////////////////////////////////////////////////
        public ActionResult ManageBooks()
        {
            var books = db.Books.Include(b => b.Category).ToList();
            return View(books);
        }

        // GET: Admin/AddBook
        public ActionResult AddBook()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Admin/AddBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("ManageBooks");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Admin/EditBook/{id}
        public ActionResult EditBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // POST: Admin/EditBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageBooks");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Admin/DeleteBook/{id}
        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("ManageBooks");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BorrowBook(int bookId)
        {
            Debug.WriteLine("BorrowBook action called.");

            var userId = Session["UserId"] as int?;
            if (userId == null)
            {
                return Json(new { success = false, message = "User is not logged in." });
            }

            var book = db.Books.Find(bookId);
            if (book == null)
            {
                return Json(new { success = false, message = "Book not found." });
            }

            Debug.WriteLine($"Book found: {book.Title}, IsAvailable: {book.IsAvailable}");

            if (!book.IsAvailable)
            {
                return Json(new { success = false, message = "Book is not available." });
            }

            var borrow = new Borrows
            {
                UserId = userId.Value, // Assuming UserId is an int
                BookId = bookId,
                BorrowedDate = DateTime.Now
            };

            db.Borrows.Add(borrow);
            book.IsAvailable = false;

            try
            {
                db.SaveChanges(); // Attempt to save to the database
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving to database: {ex.Message}");
                return Json(new { success = false, message = "Error saving to database." });
            }

            return Json(new { success = true });
        }





    }
}

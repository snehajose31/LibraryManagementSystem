using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;

                if (user.Role == "Admin")
                    return RedirectToAction("AdminDashboard");
                else
                    return RedirectToAction("UserDashboard");
            }
            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: Account/AdminDashboard
        public ActionResult AdminDashboard()
        {
            if (Session["Role"]?.ToString() == "Admin")
                return View();
            return RedirectToAction("Login");
        }

        // GET: Account/UserDashboard
        public ActionResult UserDashboard()
        {
            if (Session["Role"]?.ToString() == "User")
                return View();
            return RedirectToAction("Login");
        }

        public ActionResult Profile()
        {
            // Assuming "Username" is stored in Session upon login
            var username = Session["Username"] as string;

            // Fetch user details based on username
            if (!string.IsNullOrEmpty(username))
            {
                // Example: Retrieve user info from the database (assuming a database context `db`)
                using (var db = new LibraryContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == username);
                    if (user != null)
                    {
                        return View(user); // Pass user details to the view
                    }
                }
            }

            // Redirect to login if user is not found or session expired
            return RedirectToAction("Login", "Account");
        }
    }
}
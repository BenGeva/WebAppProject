using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OG_Sports.Controllers
{
    public class UserController : Controller
    {
        ModelContext db = new ModelContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email, Password, FirstName, LastName")] User usr)
        {
            if (ModelState.IsValid)
            {
                // Check if there is already user with this email in the database
                if (db.Users.FirstOrDefault(x => x.Email.Equals(usr.Email, StringComparison.OrdinalIgnoreCase)) != null)
                {
                    ViewBag.errorMsg = "דואר אלקטרוני זה כבר נמצא בשימוש!";
                    return View();
                }
                else
                {
                    usr.IsAdmin = false;
                    db.Users.Add(usr);
                    db.SaveChanges();
                    return RedirectToAction("Manage", "User");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get the user by the id
            User user = db.Users.Find(userId);

            if (user == null)
            {
                ViewBag.errorMsg = "המשתמש אינו קיים במערכת, אנא רענן את העמוד";
                return View("Manage");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email, Password, IsAdmin, FirstName, LastName")] User usr)
        {
            if (ModelState.IsValid)
            {
                // Set the changes to the db
                //db.Entry(usr).State = EntityState.Modified;
                User usrToUpdate = db.Users.SingleOrDefault(x => x.Email == usr.Email);

                if (usrToUpdate != null)
                {
                    usrToUpdate.FirstName = usr.FirstName;
                    usrToUpdate.LastName = usr.LastName;
                    usrToUpdate.Password = usr.Password;
                    db.SaveChanges();

                    if (((User)HttpContext.Session["user"]).Email == usr.Email)
                    {
                        HttpContext.Session["user"] = usrToUpdate;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(usr);
        }

        [HttpGet]
        public ActionResult Delete(int? userId)
        {
            // Get the user by the id and remove it from the database
            User usrToDelete = db.Users.Find(userId);

            if (usrToDelete == null)
            {
                ViewBag.errorMsg = "המשתמש אינו קיים במערכת, אנא רענן את העמוד";
                return View("Manage");
            }

            db.Users.Remove(usrToDelete);
            db.SaveChanges();

            // Redirect to manage user page
            return RedirectToAction("Manage", "User");
        }

        public ActionResult Manage()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult SiteStats()
        {
            return View(db.ProductsCategories.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            User usr = db.Users.Where(x =>
                x.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                x.Password.Equals(password)).SingleOrDefault();

            if (usr != null)
            {
                HttpContext.Session["user"] = usr;
                //System.Web.HttpContext.Current.Session["user"] = usr;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.logErrMsg = "שם משתמש או סיסמה שגויים!\nבדוק אם מקש ה-Capslock פעיל, הסיסמה היא cAse sEnSitIvE ;)";
                return View(usr);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Email, Password, FirstName, LastName")] User usr)
        {
            // Check wether all fields are valid
            if (ModelState.IsValid)
            {
                // Check if the user is already exists in the database
                if (db.Users.FirstOrDefault(x=> x.Email.Equals(usr.Email, StringComparison.OrdinalIgnoreCase)) != null)
                {
                    ViewBag.regErrMsg = "דואר אלקטרוני זה כבר נמצא בשימוש! אנא נסה להתחבר";
                }
                else
                {
                    usr.IsAdmin = false;
                    db.Users.Add(usr);
                    db.SaveChanges();
                    if (HttpContext.Session["user"] == null)
                    {
                        HttpContext.Session["user"] = usr;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View("Login");
        }
    }
}
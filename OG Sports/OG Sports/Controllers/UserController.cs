using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email, Password, FirstName, LastName")] User usr)
        {
            if (ModelState.IsValid)
            {
                usr.UserId = db.Users.Max(x => x.UserId) + 1;
                usr.IsAdmin = false;
                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
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
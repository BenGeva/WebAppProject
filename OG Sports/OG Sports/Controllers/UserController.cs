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

        [HttpGet]
        public ActionResult Create(User usr)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index", "HomeController");
            }

            return View();
        }
    }
}
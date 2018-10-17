using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OG_Sports.Controllers
{
    public class HomeController : Controller
    {
        ModelContext db = new ModelContext();

        public ActionResult Index()
        {
            //User usr = new User();
            //usr.UserId = 1;
            //db.Users.Add(usr);
            //db.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "OGSports - קצת עלינו";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
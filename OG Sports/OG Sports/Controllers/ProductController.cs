using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OG_Sports.Controllers
{
    public class ProductController : Controller
    {
        ModelContext db = new ModelContext();

        // GET: Product
        public ActionResult Index()
        {

            return View();
        }
    }
}
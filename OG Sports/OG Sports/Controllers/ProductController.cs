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

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpPost]
        public ActionResult AddProduct([Bind(Include = "ProductCategory, ProductName, Details, PicPath, Price")] Product product)
        {
            // Check wether all fields are valid
            if (ModelState.IsValid)
            {
                // Because the user only enters the pic name and we need to update the path
                product.PicPath = "~/Content/Images/" + product.PicPath + ".jpg";

                db.Products.Add(product);
                db.SaveChanges();
            }

            return View();
        }
    }    
}
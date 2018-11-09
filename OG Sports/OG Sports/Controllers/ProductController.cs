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

        [HttpGet]
        public ActionResult GroupByCategory()
        {
            return View(db.Products.GroupBy((x) => x.ProductCategoryID));
        }

        [HttpPost]
        public ActionResult FilterProducts()
        {
            string strProductPriceInput = Request["ProductPriceInput"];
            string[] arr = strProductPriceInput.Split('-');
            int minVal = int.Parse(arr[0].Split('$')[1]);
            int maxVal = int.Parse(arr[1].Split('$')[1]);

            string strProductName = Request["ProductName"];
            int nProductCategory = int.Parse(Request["ProductCategory"]);

            return View("Index", db.Products.Where((x) => (x.Price <= maxVal && x.Price >= minVal) && 
                                                          (x.ProductName.Contains(strProductName)) && 
                                                          (nProductCategory != -1 ? x.ProductCategoryID == nProductCategory : true)).ToList());
        }
    }    
}
using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName, Details, PicPath, Price")] Product prd)
        {
            if (ModelState.IsValid)
            {
                // Get the selected category
                int categoryID;
                int.TryParse(Request["categoryID"], out categoryID);
                ProductCategory category = db.ProductsCategories.SingleOrDefault(x => x.ProductCategoryID == categoryID);

                prd.ProductCategoryID = category.ProductCategoryID;
                prd.ProductCategory = category;
                prd.PicPath = "/Content/Images/" + prd.PicPath + ".jpg";
                db.Products.Add(prd);
                db.SaveChanges();
                return RedirectToAction("Manage", "Product");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Manage()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get the user by the id
            Product product = db.Products.Find(productId);

            if (product == null)
            {
                ViewBag.errorMsg = "המוצר אינו קיים במערכת, אנא רענן את העמוד";
                return View("Manage");
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId, ProductName, Details, PicPath, Price")] Product prd)
        {
            if (ModelState.IsValid)
            {
                Product prdToUpdate = db.Products.SingleOrDefault(x => x.ProductId == prd.ProductId);

                if (prdToUpdate != null)
                {
                    // Get the selected category
                    int categoryID;
                    int.TryParse(Request["categoryID"], out categoryID);
                    ProductCategory category = db.ProductsCategories.SingleOrDefault(x => x.ProductCategoryID == categoryID);

                    prdToUpdate.ProductCategoryID = category.ProductCategoryID;
                    prdToUpdate.ProductCategory = category;
                    prdToUpdate.ProductName = prd.ProductName;
                    prdToUpdate.Details = prd.Details;
                    prdToUpdate.PicPath = "/Content/Images/" + prd.PicPath + ".jpg";
                    prdToUpdate.Price = prd.Price;
                    db.SaveChanges();
                }

                return RedirectToAction("Manage");
            }

            return View(prd);
        }

        [HttpGet]
        public ActionResult Delete(int? productId)
        {
            // Get the user by the id and remove it from the database
            Product prdToDelete = db.Products.Find(productId);

            if (prdToDelete == null)
            {
                ViewBag.errorMsg = "המוצר אינו קיים במערכת, אנא רענן את העמוד";
                return View("Manage");
            }

            db.Products.Remove(prdToDelete);
            db.SaveChanges();

            // Redirect to manage user page
            return RedirectToAction("Manage", "Product");
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
    }    
}
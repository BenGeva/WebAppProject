using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OG_Sports.Controllers
{
    public class ProductCategoryController : Controller
    {
        ModelContext db = new ModelContext();

        // GET: ProductCategory
        public ActionResult Index()
        {
            return View(db.ProductsCategories.ToList());
        }

        [HttpGet]
        public string GetDataForPie()
        {
            string toReturn = "[";

            foreach (var currCat in db.ProductsCategories.ToList())
            {
                toReturn += "{ \"label\" : " + "\"" + currCat.Name + "\"" + ", \"value\" : " + "\"" + currCat.Products.ToList().Count + "\"" + " }, ";
            }

            toReturn = toReturn.Substring(0, toReturn.Length - 2) + "]";

            return (toReturn);
        }

        [HttpGet]
        public string GetDataForBar()
        {
            //TODO: Implement select from orders

            return "[{ \"name\": \"סקי\", \"value\": \"3\"}, { \"name\": \"כדורגל\", \"value\": \"1\" }, { \"name\": \"כדורסל\", \"value\": \"2\"}, { \"name\": \"הוקי\", \"value\": \"7\" }]";
        }
    }
}
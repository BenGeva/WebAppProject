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
            string toReturn = "[";

            List<Product> boughtP = ( from prd in db.Products
                                       join perord in db.ProductsPerOrder 
                                       on prd.ProductId equals perord.ProductId
                                       join ord in db.Orders
                                       on perord.OrderId equals ord.OrderId
                                       where ord.isOpen == false select prd ).ToList();

            Dictionary<string, int> countDic = new Dictionary<string, int>
            {
                { "סקי", 0 },
                { "הוקי", 0 },
                { "כדורסל", 0 },
                { "כדורגל", 0 },
                { "כללי", 0 }
            };

            foreach (var p in boughtP)
            {
                countDic[p.ProductName]++;
            }

            foreach (var currKeyValue in countDic)
            {
                toReturn += "{ \"name\" : " + "\"" + currKeyValue.Key + "\"" + ", \"value\" : " + "\"" + currKeyValue.Value + "\"" + " }, ";
            }

            toReturn = toReturn.Substring(0, toReturn.Length - 2) + "]";

            return toReturn;
        }
    }
}
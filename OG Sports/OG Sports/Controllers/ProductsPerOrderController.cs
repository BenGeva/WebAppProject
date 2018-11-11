using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OG_Sports.Controllers
{
    public class ProductsPerOrderController : Controller
    {
        ModelContext db = new ModelContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? productId)
        {
            // Get the connected user
            User usrConnected = (User)HttpContext.Session["user"];

            // Get the user by the id and remove it from the database
            Product product = db.Products.Find(productId);
            Order order = null;
            ProductsPerOrder prdPerOrd = null;

            if (usrConnected != null)
            {
                order = db.Orders.SingleOrDefault(x => x.UserId == usrConnected.UserId && x.isOpen == true);
            }

            if (product != null && order != null)
            {
                prdPerOrd = db.ProductsPerOrder.FirstOrDefault(x => x.OrderId == order.OrderId && x.ProductId == product.ProductId);
            }

            if (prdPerOrd == null)
            {
                ViewBag.errorMsg = "המוצר אינו קיים בהזמנה, אנא רענן את העמוד";
            }
            else
            {
                db.ProductsPerOrder.Remove(prdPerOrd);
                db.SaveChanges();
            }

            // Redirect to Cart page
            return RedirectToAction("Index", "Order");
        }
    }
}
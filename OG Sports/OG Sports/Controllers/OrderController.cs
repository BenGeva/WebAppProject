using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OG_Sports.Controllers
{
    public class OrderController : Controller
    {
        ModelContext db = new ModelContext();

        [HttpGet]
        public ActionResult Index()
        {
            // Get the connected user
            User usrConnected = (User)HttpContext.Session["user"];

            if (usrConnected != null)
            {
                // Check if this user has already an open order
                Order ord = db.Orders.SingleOrDefault(x => x.UserId == usrConnected.UserId && x.isOpen == true);
                if (ord != null)
                {
                    List<ProductsPerOrder> prdPerOrd = db.ProductsPerOrder.Where(x => x.OrderId == ord.OrderId).ToList();
                    List<Product> products = new List<Product>();
                    foreach (ProductsPerOrder curr in prdPerOrd)
                    {
                        products.Add(db.Products.Single(x => x.ProductId == curr.ProductId));
                    }

                    List<Product> res = (from prd in db.Products
                                         join perOrd in db.ProductsPerOrder
                                         on prd.ProductId equals perOrd.ProductId
                                         where perOrd.OrderId == ord.OrderId
                                         select prd).ToList();

                    ViewBag.Products = products;
                    return View(ord);
                }
            }

            ViewBag.Products = new List<Product>();
            return View();
        }

        [HttpGet]
        public ActionResult Pay()
        {
            // Get the connected user
            User usrConnected = (User)HttpContext.Session["user"];
            Order order = null;
            ViewBag.payMsg = "אירעה שגיאה, ההזמנה עליה ניסיתי לשלם אינה קיימת!";

            if (usrConnected != null)
            {
                order = db.Orders.SingleOrDefault(x => x.UserId == usrConnected.UserId && x.isOpen == true);
            }

            if (order != null)
            {
                order.isOpen = false;
                db.SaveChanges();
                ViewBag.payMsg = "התשלום בוצע בהצלחה";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Manage()
        {
            User usrConnected = (User)HttpContext.Session["user"];

            if (usrConnected != null)
            {
                return View(db.Orders.Where(x => x.UserId == usrConnected.UserId).ToList());
            }

            return View();
        }

        [HttpPost]
        public ActionResult FilterOrders()
        {
            User usrConnected = (User)HttpContext.Session["user"];

            if (usrConnected != null)
            {
                bool isOpen = bool.Parse(Request["isOpen"]);
                return View("Manage", db.Orders.Where(x => x.UserId == usrConnected.UserId && x.isOpen == isOpen).ToList());
            }

            return View("Manage");
        }

        [HttpGet]
        public ActionResult AddProduct(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get the product by the id
            Product product = db.Products.Find(productId);

            if (product == null)
            {
                ViewBag.errorMsg = "המוצר אינו קיים במערכת, אנא רענן את העמוד";
                return View("~/Views/Product/Index.cshtml");
            }
            else
            {
                Order ord = null;
                bool isNewOrder = false;

                // Get the connected user
                User usrConnected = (User)HttpContext.Session["user"];

                if (usrConnected != null)
                {
                    // Check if this user has already an open order
                    ord = db.Orders.SingleOrDefault(x => x.UserId == usrConnected.UserId && x.isOpen == true);
                    User usrToAttach = db.Users.SingleOrDefault(x => x.UserId == usrConnected.UserId);
                    // If the user doesn't have any open order than create new one
                    if (ord == null)
                    {
                        isNewOrder = true;
                        ord = new Order()
                        {
                            isOpen = true,
                            UserId = usrToAttach.UserId,
                            User = usrToAttach,
                        };  
                    }

                    // Add the product to the order
                    ProductsPerOrder prdPerOrd = new ProductsPerOrder()
                    {
                        OrderId = ord.OrderId,
                        Order = ord,
                        ProductId = product.ProductId,
                        Product = product
                    };
                    db.ProductsPerOrder.Add(prdPerOrd);

                    if (isNewOrder)
                    {
                        db.Orders.Add(ord);
                    }
                    
                    db.SaveChanges();

                    return View();
                }
                else
                {
                    return View("~/Views/User/Login.cshtml");
                }
            }
        }
    }
}
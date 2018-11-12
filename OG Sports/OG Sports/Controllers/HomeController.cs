using Accord.MachineLearning;
using OG_Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accord.MachineLearning;

namespace OG_Sports.Controllers
{
    public class HomeController : Controller
    {
        ModelContext db = new ModelContext();

        public ActionResult Index()
        {
            User usrCon = (User)HttpContext.Session["user"];

            if (usrCon != null)
            {


                Accord.Math.Random.Generator.Seed = 0;

                List<Product> boughtP = (from prd in db.Products
                                         join perord in db.ProductsPerOrder
                                         on prd.ProductId equals perord.ProductId
                                         join ord in db.Orders
                                         on perord.OrderId equals ord.OrderId
                                         join usr in db.Users
                                         on ord.UserId equals usr.UserId
                                         where ord.isOpen == false && usr.UserId == usrCon.UserId
                                         select prd).ToList();

                if (boughtP.Count <= 5)
                {
                    return View(db.Products.ToList());
                }

                Dictionary<double, double> countDic = new Dictionary<double, double>
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 4, 0 },
                    { 5, 0 }
                };

                foreach (var p in boughtP)
                {
                    countDic[p.ProductCategory.ProductCategoryID]++;
                }


                // Declare some observations
                double[][] observations = new double[boughtP.Count][];

                for (int j = 0; j < boughtP.Count; j++)
                {
                    observations[j] = new double[2];
                }

                int i = 0, k = 0;
                foreach (var item in countDic)
                {
                    for (int j = 0; j < countDic[i + 1]; j++)
                    {
                        observations[j + k][0] = item.Key;
                        observations[j + k][1] = item.Value;
                    }
                    k = (int)countDic[i + 1] + k;
                    i++;
                }

                // Create a new K-Means algorithm with 3 clusters 
                KMeans kmeans = new KMeans(5);

                // Compute the algorithm, retrieving an integer array
                //  containing the labels for each of the observations
                KMeansClusterCollection clusters = kmeans.Learn(observations);

                // As a result, the first two observations should belong to the
                //  same cluster (thus having the same label). The same should
                //  happen to the next four observations and to the last three.
                //int[] labels = clusters.Decide(/*observations);*/
                int chosenCatId = (int)clusters.Clusters.SingleOrDefault(y => y.Proportion == clusters.Clusters.Max(x => x.Proportion)).Centroid[0];

                return View(db.Products.Where(x => x.ProductCategoryID == chosenCatId).ToList());
            }

            return View("~/Views/User/Login.cshtml");
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
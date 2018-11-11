using OG_Sports.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class InitData : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Name = "סקי",
                    VideoPath = ""
                },
                new ProductCategory()
                {
                    Name = "כדורסל",
                    VideoPath = ""
                },
                new ProductCategory()
                {
                    Name = "כדורגל",
                    VideoPath = ""
                },
                new ProductCategory()
                {
                    Name = "הוקי",
                    VideoPath = ""
                },
            };

            productCategories.ForEach((x) => context.ProductsCategories.Add(x));

            new List<Product>() {
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "תיק מקצועי עם 8 תאים נפרדים",
                    ProductName = "תיק סקי 2V",
                    PicPath = "/Content/Images/SkiBag.jpg",
                    Price = 339,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "קסדת סקי משהו מטורףףףף",
                    ProductName = "קסדת סקי",
                    PicPath = "/Content/Images/SkiHelmet.jpg",
                    Price = 209,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "מגפיים טיל",
                    ProductName = "נעלי סקי HX5",
                    PicPath = "/Content/Images/SkiBoots.jpg",
                    Price = 349,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    ProductName = "משקפי סקי s30",
                    PicPath = "/Content/Images/SkiGoggles.jpg",
                    Details = "גוגלס לפנים!! תרתי משמע!!11",
                    Price = 89,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "תיק גדול ונוח לשימוש רב פעמי בסקי בואל טורנס",
                    ProductName = "תיק סקי",
                    PicPath = "/Content/Images/SkiBag2.jpg",
                    Price = 809,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "כפפות משובחות לחורף קר במיוחד",
                    ProductName = "כפפות סקי",
                    PicPath = "/Content/Images/SkiGloves.jpg",
                    Price = 19,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "כדור מקצועי של חברת ספאלדינג היודעים באיכות מוצריהם",
                    ProductName = "כדורסל",
                    PicPath = "/Content/Images/Basketball.jpg",
                    Price = 21,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "נעליים מקוריות של השחקן קיירי אירווינג האלוף",
                    ProductName = "נעליי כדורסל",
                    PicPath = "/Content/Images/BasketballShoes.jpg",
                    Price = 1109,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "נעליים להחלקה מיטבית",
                    ProductName = "נעלי הוקי VB10",
                    PicPath = "/Content/Images/HockeyShoes.jpg",
                    Price = 449,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "מקל לחבטה עדינה אך עוצמתית",
                    ProductName = "מקל הוקי TY8",
                    PicPath = "/Content/Images/HockeySticks.jpg",
                    Price = 119,
                },
                new Product()
                {
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורגל"),
                    Details = "הכדרו הרשמי של ליגת האלופות. עכשיו בבלעדיות ב OG Sports",
                    ProductName = "כדורגל",
                    PicPath = "/Content/Images/Football.jpg",
                    Price = 59,
                }
            }.ForEach((x) => context.Products.Add(x));


            base.Seed(context);
        }
    }
}
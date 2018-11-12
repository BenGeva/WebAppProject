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
                },
                new ProductCategory()
                {
                    Name = "כדורסל",
                },
                new ProductCategory()
                {
                    Name = "כדורגל",
                },
                new ProductCategory()
                {
                    Name = "הוקי",
                },
                new ProductCategory()
                {
                    Name = "כללי",
                },
            };

            productCategories.ForEach((x) => context.ProductsCategories.Add(x));

            List<Product> products = new List<Product>() {
                new Product()
                {
                    ProductId = 1,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "תיק מקצועי עם 8 תאים נפרדים",
                    ProductName = "תיק סקי 2V",
                    PicPath = "/Content/Images/SkiBag.jpg",
                    Price = 339,
                },
                new Product()
                {
                    ProductId = 12,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "של היפופטם טוב ואיכותי",
                    ProductName = "מעיל סקי מעור",
                    PicPath = "/Content/Images/SkiJacket1.jpg",
                    Price = 560,
                },
                new Product()
                {
                    ProductId = 13,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "יותר זול מההוא למעלה",
                    ProductName = "מעיל סקי טוב",
                    PicPath = "/Content/Images/SkiJacket2.jpg",
                    Price = 540,
                },
                new Product()
                {
                    ProductId = 14,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "מכנסיים איכותיים פרוותיים פרווהים",
                    ProductName = "טרמיות טובות",
                    PicPath = "/Content/Images/ThermalPants.jpg",
                    Price = 339,
                },
                new Product()
                {
                    ProductId = 2,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "קסדת סקי משהו מטורףףףף",
                    ProductName = "קסדת סקי",
                    PicPath = "/Content/Images/SkiHelmet.jpg",
                    Price = 209,
                },
                new Product()
                {
                    ProductId = 3,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "מגפיים טיל",
                    ProductName = "נעלי סקי HX5",
                    PicPath = "/Content/Images/SkiBoots.jpg",
                    Price = 349,
                },
                new Product()
                {
                    ProductId = 4,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    ProductName = "משקפי סקי s30",
                    PicPath = "/Content/Images/SkiGoggles.jpg",
                    Details = "גוגלס לפנים!! תרתי משמע!!11",
                    Price = 89,
                },
                new Product()
                {
                    ProductId = 5,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "תיק גדול ונוח לשימוש רב פעמי בסקי בואל טורנס",
                    ProductName = "תיק סקי",
                    PicPath = "/Content/Images/SkiBag2.jpg",
                    Price = 809,
                },
                new Product()
                {
                    ProductId = 6,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "סקי"),
                    Details = "כפפות משובחות לחורף קר במיוחד",
                    ProductName = "כפפות סקי",
                    PicPath = "/Content/Images/SkiGloves.jpg",
                    Price = 19,
                },
                new Product()
                {
                    ProductId = 7,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "כדור מקצועי של חברת ספאלדינג היודעים באיכות מוצריהם",
                    ProductName = "כדורסל",
                    PicPath = "/Content/Images/Basketball.jpg",
                    Price = 21,
                },
                new Product()
                {
                    ProductId = 8,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "נעליים מקוריות של השחקן קיירי אירווינג האלוף",
                    ProductName = "נעליי כדורסל",
                    PicPath = "/Content/Images/BasketballShoes.jpg",
                    Price = 1109,
                },
                new Product()
                {
                    ProductId = 15,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "מכנסיים אחרי משחק של קווין דוראנט",
                    ProductName = "מכנסי כדורסל",
                    PicPath = "/Content/Images/BasketPants.jpg",
                    Price = 1209,
                },
                new Product()
                {
                    ProductId = 16,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "רשת סל מקצועית לא נקרעת",
                    ProductName = "רשת כדורסל",
                    PicPath = "/Content/Images/Net.jpg",
                    Price = 29,
                },
                new Product()
                {
                    ProductId = 17,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "סל שניתן לתלות בקלות רק פטיש ומסמר",
                    ProductName = "סל לגינה",
                    PicPath = "/Content/Images/Basket.jpg",
                    Price = 301,
                },
                new Product()
                {
                    ProductId = 18,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "שרוול טוב לחימום טוב",
                    ProductName = "שרוול ליד",
                    PicPath = "/Content/Images/HandSleeve.jpg",
                    Price = 26,
                },
                new Product()
                {
                    ProductId = 19,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "שרוול טוב לחימום טוב",
                    ProductName = "שרוול לרגל",
                    PicPath = "/Content/Images/LegSleeve.jpg",
                    Price = 15,
                },
                new Product()
                {
                    ProductId = 20,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורסל"),
                    Details = "מגן זיעה שלא ינזלו טיפות על העיניים",
                    ProductName = "מגן זיעה",
                    PicPath = "/Content/Images/BasketballShoes.jpg",
                    Price = 103,
                },
                new Product()
                {
                    ProductId = 9,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "נעליים להחלקה מיטבית",
                    ProductName = "נעלי הוקי VB10",
                    PicPath = "/Content/Images/HockeyShoes.jpg",
                    Price = 449,
                },
                new Product()
                {
                    ProductId = 10,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "מקל לחבטה עדינה אך עוצמתית",
                    ProductName = "מקל הוקי TY8",
                    PicPath = "/Content/Images/HockeySticks.jpg",
                    Price = 119,
                },
                new Product()
                {
                    ProductId = 21,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "המגן החשוב ביותר, שומר אותך בריא ופעיל",
                    ProductName = "מגן אגן ומפשעה",
                    PicPath = "/Content/Images/BallsShield.jpg",
                    Price = 119,
                },
                new Product()
                {
                    ProductId = 22,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "כידוע, שחקני הוקי רבים חוטפים כוויות קור.. לא עם הכפפות הללו",
                    ProductName = "כפפות הוקי ZX",
                    PicPath = "/Content/Images/HockeyGloves.jpg",
                    Price = 119,
                },
                new Product()
                {
                    ProductId = 23,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "קסדה איכותית, אך עדיין יתכנו תזוזות ראש בחבטות",
                    ProductName = "קסדת הוקי קלה",
                    PicPath = "/Content/Images/HockeyHelmet2.jpg",
                    Price = 119,
                },
                new Product()
                {
                    ProductId = 24,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "קסדה שמונעת תזוזת ראש בחבטה",
                    ProductName = "קסדת הוקי",
                    PicPath = "/Content/Images/HockeyHelmet.jpg",
                    Price = 119,
                },
                new Product()
                {
                    ProductId = 25,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "מגנים ששומרים היטב על המפרקים",
                    ProductName = "מגני מרפקים",
                    PicPath = "/Content/Images/ElbowPads.jpg",
                    Price = 323,
                },
                new Product()
                {
                    ProductId = 26,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "הוקי"),
                    Details = "מקל לחבטה עדינה אך עוצמתית",
                    ProductName = "כדור הוקי רחוב",
                    PicPath = "/Content/Images/HockeyBall.jpg",
                    Price = 56,
                },
                new Product()
                {
                    ProductId = 11,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כדורגל"),
                    Details = "הכדרו הרשמי של ליגת האלופות. עכשיו בבלעדיות ב OG Sports",
                    ProductName = "כדורגל",
                    PicPath = "/Content/Images/Football.jpg",
                    Price = 59,
                },
                new Product()
                {
                    ProductId = 27,
                    ProductCategory = productCategories.FirstOrDefault((x) => x.Name == "כללי"),
                    Details = "המוצר הבלתי ייאמן, שמצלם את הבלתי יאומן",
                    ProductName = "גו פרו",
                    PicPath = "/Content/Images/GoPro.jpg",
                    Price = 777,
                }
            };

            products.ForEach((x) => context.Products.Add(x));

            List<User> users = new List<User>() {
                new User()
                {
                    Email = "ohadelal3@gmail.com",
                    Password = "123456",
                    IsAdmin = true,
                    FirstName = "אוהד",
                    LastName = "אל על",
                },
                new User()
                {
                    Email = "beng@gmail.com",
                    Password = "123456",
                    IsAdmin = false,
                    FirstName = "בן",
                    LastName = "גבע",
                }
            };

            users.ForEach((x) => context.Users.Add(x));

            List<Order> orders = new List<Order>(){
                new Order
                {
                    OrderId = 1,
                    isOpen = true,
                    UserId = 1,
                    User = users.FirstOrDefault((x) => x.Email == "ohadelal3@gmail.com"),
                },
                new Order
                {
                    OrderId = 2,
                    isOpen = false,
                    UserId = 1,
                    User = users.FirstOrDefault((x) => x.Email == "ohadelal3@gmail.com"),
                },
                new Order
                {
                    OrderId = 3,
                    isOpen = false,
                    UserId = 1,
                    User = users.FirstOrDefault((x) => x.Email == "ohadelal3@gmail.com"),
                },
                new Order
                {
                    OrderId = 4,
                    isOpen = true,
                    UserId = 2,
                    User = users.FirstOrDefault((x) => x.Email == "beng@gmail.com"),
                },
                new Order
                {
                    OrderId = 5,
                    isOpen = false,
                    UserId = 2,
                    User = users.FirstOrDefault((x) => x.Email == "beng@gmail.com"),
                }
            };

            orders.ForEach((x) => context.Orders.Add(x));

            new List<ProductsPerOrder>()
            {
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 6,
                    Product = products.FirstOrDefault((x) => x.ProductId == 6),
                },
                new ProductsPerOrder
                {
                    OrderId = 3,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 3),
                    ProductId = 6,
                    Product = products.FirstOrDefault((x) => x.ProductId == 6),
                },
                new ProductsPerOrder
                {
                    OrderId = 3,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 3),
                    ProductId = 2,
                    Product = products.FirstOrDefault((x) => x.ProductId == 2),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 4,
                    Product = products.FirstOrDefault((x) => x.ProductId == 4),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 10,
                    Product = products.FirstOrDefault((x) => x.ProductId == 10),
                },
                new ProductsPerOrder
                {
                    OrderId = 4,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 4),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 4,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 4),
                    ProductId = 8,
                    Product = products.FirstOrDefault((x) => x.ProductId == 8),
                },
                new ProductsPerOrder
                {
                    OrderId = 1,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 1),
                    ProductId = 8,
                    Product = products.FirstOrDefault((x) => x.ProductId == 8),
                },
                new ProductsPerOrder
                {
                    OrderId = 3,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 3),
                    ProductId = 11,
                    Product = products.FirstOrDefault((x) => x.ProductId == 11),
                },
                new ProductsPerOrder
                {
                    OrderId = 1,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 1),
                    ProductId = 12,
                    Product = products.FirstOrDefault((x) => x.ProductId == 27),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 12,
                    Product = products.FirstOrDefault((x) => x.ProductId == 27),
                },
                new ProductsPerOrder
                {
                    OrderId = 3,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 3),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 9,
                    Product = products.FirstOrDefault((x) => x.ProductId == 9),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 5,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 5),
                    ProductId = 7,
                    Product = products.FirstOrDefault((x) => x.ProductId == 7),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                },
                new ProductsPerOrder
                {
                    OrderId = 2,
                    Order = orders.FirstOrDefault((x) => x.OrderId == 2),
                    ProductId = 1,
                    Product = products.FirstOrDefault((x) => x.ProductId == 1),
                }
            }.ForEach((x) => context.ProductsPerOrder.Add(x));

            base.Seed(context);
        }
    }
}
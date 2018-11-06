using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class Product
    {  
        public int ProductId { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public string PicPath { get; set; }
        public int Price { get; set; }
    }
}
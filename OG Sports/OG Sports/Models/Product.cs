using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class Product
    {  
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "קטגוריה")] 
        [ForeignKey("ProductCategory")]
        public int ProductCategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        [Required]
        [Display(Name = "שם מוצר")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "תיאור")]
        public string Details { get; set; }

        [Required]
        [Display(Name = "שם תמונה")]
        public string PicPath { get; set; }

        [Required]
        [Display(Name = "מחיר")]
        public int Price { get; set; }
    }
}
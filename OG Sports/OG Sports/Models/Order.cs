using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public bool isOpen { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ab { get; set; }
    }
}
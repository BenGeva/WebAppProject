using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class User
    {
        public int UserId { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "אנא הזן דואר אלקטרוני!")]
        [Display(Name = "דואר אלקטרוני")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "סיסמה חייבת להכיל לפחות 6 תווים!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "אנא הזן סיסמה!")]
        [Display(Name = "סיסמה")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
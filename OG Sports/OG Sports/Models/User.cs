﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
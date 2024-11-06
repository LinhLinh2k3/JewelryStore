using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class cart
    {
        public List<cartItems> items { get; set; } = new List<cartItems>();
    }
}
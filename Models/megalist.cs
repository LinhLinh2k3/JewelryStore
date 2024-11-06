using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class megalist
    {
        private DatabaseEntities db = new DatabaseEntities();

        public List<categories> categoryList { get { return db.categories.ToList(); } }
        public List<materials> materialList { get { return db.materials.ToList(); } }
        public List<products> totalproductList { get { return db.products.ToList(); } }
        public List<products> productList { get; set; }
        public cart cart { get { return cart; } }
        public users user { get; set; }
        public products product { get; set; }

        public static int loggedInUser { get; set; }

        public int cartItmCount()
        {
            return db.cartItems.Where(i => i.cartID == loggedInUser).Count();
        }
    }
} 
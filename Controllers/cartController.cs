using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class cartController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        private void LoadCartFromDatabase(cart cart)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            if (Session["userID"] != null)
            {
                var dbCartItems = db.cartItems.Where(item => item.cartID == userID).ToList();

                foreach (var dbCartItem in dbCartItems)
                {
                    var sessionCartItem = cart.items.FirstOrDefault(item => item.prodID == dbCartItem.prodID);
                    if (sessionCartItem == null)
                    {
                        // Add the item to the session cart if not already present
                        cart.items.Add(new cartItems { cartID = userID, prodID = dbCartItem.prodID, quantity = dbCartItem.quantity, products = dbCartItem.products });
                    }
                }
            }
        }

        private void AddToDatabaseCart(string productId, int quantity)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            if (Session["userID"] != null)
            {
                var dbCartItem = db.cartItems.FirstOrDefault(item => item.cartID == userID && item.prodID == productId);

                if (dbCartItem == null)
                {
                    //Add information about that product following by its ID
                    products p = db.products.FirstOrDefault(item => item.prodID == productId);

                    // Add new item to the database cart
                    db.cartItems.Add(new cartItems { cartID = userID, prodID = productId, quantity = quantity, products = p });
                }

                // Save changes to the database
                db.SaveChanges();

                //Update total price
                ViewBag.TotalPrice = getTotalPrice();
            }
        }

        private void UpdateDatabaseCart(string productId, int quantity)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            if (Session["userID"] != null)
            {
                var dbCartItem = db.cartItems.FirstOrDefault(item => item.cartID == userID && item.prodID == productId);

                if (dbCartItem != null)
                {
                    // Update quantity if the product is already in the database cart
                    dbCartItem.quantity += quantity;

                    // Update to session cart
                    updateSessionCart(productId, quantity);
                }

                // Save changes to the database
                db.SaveChanges();

                // Update total price
                ViewBag.TotalPrice = getTotalPrice();
            }
        }

        private void RemoveCartItem(string productId)
        {
            cart cart = getCart();
            int userID = Convert.ToInt32(Session["userID"]);
            var dbCartItem = db.cartItems.FirstOrDefault(item => item.cartID == userID && item.prodID == productId);

            if (dbCartItem != null)
            {
                db.cartItems.Remove(dbCartItem);
                db.SaveChanges();

                var removeItem = cart.items.SingleOrDefault(i => i.prodID == productId);
                cart.items.Remove(removeItem);
            }
        }

        private void saveCart(cart cart)
        {
            Session["cart"] = cart;
            Session["cartItmCount"] = Convert.ToInt32(Session["cartItmCount"]) + 1;
        }

        private void updateSessionCart(string productId, int quantity)
        {
            cart cart = getCart();
            cartItems sessionCartItem = cart.items.Single(i => i.prodID == productId);
            sessionCartItem.quantity += quantity;
            saveCart(cart);
        }

        private decimal getTotalPrice()
        {
            decimal totalPrice = 0;
            cart cart = getCart();

            if (cart != null)
            {
                foreach (var item in cart.items)
                {
                    totalPrice += item.products.prodPrice * item.quantity;
                }
            }

            return totalPrice;
        }

        // GET: cart
        public ActionResult index()
        {
            if (Session["id"] != null)
            {
                ViewBag.TotalPrice = getTotalPrice();
                cart cart = getCart();
                return View(cart);
            }
            return RedirectToAction("NotFound", "error");
        }

        public ActionResult addToCart(string productId, int quantity = 1)
        {
            if (Session["id"] != null)
            {
                cart cart = getCart();
                AddToDatabaseCart(productId, quantity);
                saveCart(cart);
                return RedirectToRoute("shop");
            }
            return RedirectToAction("NotFound", "error");
        }

        public ActionResult updateCart(string productId, int quantity)
        {
            if (Session["id"] != null)
            {
                UpdateDatabaseCart(productId, quantity);
                return RedirectToAction("index");
            }
            return RedirectToAction("NotFound", "error");
        }

        public ActionResult removeFromCart(string productId)
        {
            if (Session["id"] != null)
            {
                RemoveCartItem(productId);
                cart cart = getCart();
                saveCart(cart);

                return RedirectToAction("index");
            }
            return RedirectToAction("NotFound", "error");
        }

        //get cart
        public cart getCart()
        {
            cart cart = Session["cart"] as cart;
            if (cart == null)
            {
                cart = new cart();
                Session["cart"] = cart;
            }
            LoadCartFromDatabase(cart);
            return cart;
        }
    }
}
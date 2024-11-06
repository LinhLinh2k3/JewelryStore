using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class adminController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: admin/dashboard
        public ActionResult index()
        {
            if (Session["admId"] == null)
            {
                return RedirectToAction("login");
            }
            return View(new megalist() { user = db.users.Find(Session["userID"]) });
        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string userAccount, string userPassword)
        {
            if (ModelState.IsValid)
            {
                users user = null;
                switch (IdentifyInput(userAccount))
                {
                    case "Email":
                        user = db.users.FirstOrDefault(u => u.userEmail.Equals(userAccount));
                        break;
                    case "Phone Number":
                        user = db.users.FirstOrDefault(u => u.userPhone.Equals(userAccount));
                        break;
                    case "Username":
                        user = db.users.FirstOrDefault(u => u.username.Equals(userAccount));
                        break;
                    default:
                        ViewBag.ToastType = "Error";
                        ViewBag.ToastMsg = "Undentify account!";
                        return View();
                }

                if (user != null && user.roleID == 1)
                {
                    if (Crypto.VerifyHashedPassword(user.userPassword, userPassword))
                    {
                        Session["admId"] = Guid.NewGuid().ToString();
                        Session["userID"] = user.userID;
                        Session["userfullname"] = user.userFullName;

                        return RedirectToAction("index");
                    }
                    else
                    {
                        ViewBag.ToastType = "Error";
                        ViewBag.ToastMsg = "Wrong password!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ToastType = "Error";
                    ViewBag.ToastMsg = "You don't have permission!";
                    return View();
                }
            }
            return null;
        }

        [HttpGet]
        public ActionResult logout()
        {
            if (Session["admId"] != null)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Contents.Clear();
                Session.RemoveAll();
                Session.Abandon();

                return RedirectToAction("index");
            }
            else
            {
                return View("~/Views/Layouts/error.cshtml");
            }
        }

        public string IdentifyInput(string input)
        {
            // Regex for email
            var emailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            // Regex for phone number (simplified)
            //var phoneRegex = new Regex(@"^\d{12}$");
            var phoneRegex = new Regex(@"^\+\d{1,3}\s?\(?\d{1,3}\)?[\s.-]?\d{1,4}[\s.-]?\d{1,9}$");

            if (emailRegex.IsMatch(input))
            {
                // Check if email exists in the database
                users user = db.users.FirstOrDefault(u => u.userEmail == input);
                return user != null ? "Email" : "Unknown";
            }
            else if (phoneRegex.IsMatch(input))
            {
                // Check if phone number exists in the database
                users user = db.users.FirstOrDefault(u => u.userPhone == input);
                return user != null ? "Phone Number" : "Unknown";
            }
            else
            {
                // Check if username exists in the database
                users user = db.users.FirstOrDefault(u => u.username == input);
                return user != null ? "Username" : "Unknown";
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

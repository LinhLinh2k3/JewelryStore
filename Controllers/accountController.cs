using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class accountController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        [HttpGet]
        public ActionResult register()
        {
            if (Session["id"] == null)
            {
                return View();
            }
            return RedirectToAction("index", "page");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult register(HttpPostedFileBase userAvatar, users user)
        {
            if (ModelState.IsValid)
            {
                var check = db.users.FirstOrDefault(u => u.userEmail == user.userEmail || u.userPhone == user.userPhone || u.username == user.username);
                if (check == null)
                {
                    user.userPassword = Crypto.HashPassword(user.userPassword);
                    if (userAvatar != null && userAvatar.ContentLength > 0) //Kiểm tra ở View, người dùng có thêm ảnh hay chưa?
                    {
                        if (userAvatar.ContentLength > 10 * 1024 * 1024) //Nếu kích thước của ảnh lớn hơn 10mb (1024B = 1KB)
                        {
                            ViewBag.ToastType = "Error"; //Toast báo lỗi
                            ViewBag.ToastMsg = "Image to big"; //Toast báo lỗi
                            ModelState.AddModelError("file", "File size must be less than 10MB."); //Báo lỗi ở View
                            return View(); //Giữ nguyên màn hình lỗi
                        }

                        var testPath = Path.Combine(Server.MapPath("~/Images/profile/"), user.username); //Đường dẫn thư mục profile
                        if (System.IO.File.Exists(testPath)) //Ktr ảnh đã tồn tại trước đó với tên ảnh là username
                        {
                            System.IO.File.Delete(testPath); //Nếu có, xóa ảnh đó đi
                        }

                        var extension = Path.GetExtension(userAvatar.FileName); //Đuôi ảnh (.jpg, .png, .....)
                        var path = Path.Combine(Server.MapPath("~/Images/profile/"), user.username + extension); //Đường dẫn thư mục profile với ảnh tên là username và đuôi ảnh người dùng up ở View
                        userAvatar.SaveAs(path); //Lưu lại hình tại đường dẫn đó
                        user.userAvatar = user.username + extension; //Truyền vào DB
                    }
                    else
                    {
                        user.userAvatar = null; //Truyền vào DB
                    }

                    db.Configuration.ValidateOnSaveEnabled = false;
                    user.roleID = 0;
                    db.users.Add(user);
                    db.SaveChanges();

                    megalist.loggedInUser = Convert.ToInt32(Session["userID"]);

                    ViewBag.ToastType = "Success";
                    ViewBag.ToastMsg = "Account created!";
                    return RedirectToAction("login");
                }
                else
                {
                    ViewBag.ToastType = "Error";
                    ViewBag.ToastMsg = "Account existed!";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            if (Session["id"] == null)
            {
                return View();
            }
            return RedirectToAction("index", "page");
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

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.userPassword, userPassword))
                    {
                        Session["id"] = Guid.NewGuid().ToString();
                        Session["userID"] = user.userID;
                        Session["userfullname"] = user.userFullName;
                        megalist.loggedInUser = Convert.ToInt32(Session["userID"]);

                        return RedirectToAction("index", "page");
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
                    ViewBag.ToastMsg = "Account not existed!";
                    return View();
                }
            }
            return null;
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Contents.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "page");
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
    }
}
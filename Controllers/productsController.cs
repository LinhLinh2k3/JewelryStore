using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class productsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: shop
        public ActionResult shop(int page = 0)
        {
            const int pageSize = 9;
            var count = db.products.Count();
            List<products> data = null;

            if (page >= 0)
            {
                data = db.products.OrderBy(p => p.prodID).Skip(page * pageSize).Take(pageSize).ToList();
            }
            else
            {
                page = 0;
            }

            int maxpage = (count / pageSize) - (count % pageSize == 0 ? 1 : 0);
            ViewBag.MaxPage = maxpage;

            if (page < 0)
            {
                page = 0;
            }
            else if (page > maxpage)
            {
                page = maxpage;
            }
            ViewBag.Page = page;

            return View(new megalist() { productList = data });
        }

        // GET: product/details/5
        public ActionResult show(string link)
        {
            if (link == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.FirstOrDefault(p => p.prodLink == link);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }


        // GET: products/Index
        public ActionResult index()
        {
            return View(new megalist() { user = db.users.Find(Session["userID"]) });
        }

        public ActionResult details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products product = db.products.FirstOrDefault(p => p.prodID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(new megalist() { user = db.users.Find(Session["userID"]), product = product });
        }

        // GET: products/Create
        public ActionResult create()
        {
            ViewBag.catID = new SelectList(db.categories, "catID", "catName");
            ViewBag.matID = new SelectList(db.materials, "matID", "matName");
            return View();
        }

        // POST: product/create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create([Bind(Include = "prodID,prodName,prodPrice,prodDesc,prodAmount,prodLink,prodRevImg,prodImg1,prodImg2,prodImg3,prodImg4,catID,matID")] products products)
        {
            if (ModelState.IsValid)
            {
                products.prodID = products.prodID.TrimEnd();
                db.products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catID = new SelectList(db.categories, "catID", "catName", products.catID);
            ViewBag.matID = new SelectList(db.materials, "matID", "matName", products.matID);
            return View(products);
        }

        // GET: product/edit/5
        public ActionResult edit(string link)
        {
            if (link == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(link);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.catID = new SelectList(db.categories, "catID", "catName", products.catID);
            ViewBag.matID = new SelectList(db.materials, "matID", "matName", products.matID);
            return View(products);
        }

        // POST: product/edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit([Bind(Include = "prodID,prodName,prodPrice,prodDesc,prodAmount,prodLink,prodRevImg,prodImg1,prodImg2,prodImg3,prodImg4,catID,matID")] products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catID = new SelectList(db.categories, "catID", "catName", products.catID);
            ViewBag.matID = new SelectList(db.materials, "matID", "matName", products.matID);
            return View(products);
        }

        // GET: product/delete/5
        public ActionResult delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteConfirmed(string id)
        {
            products products = db.products.Find(id);
            db.products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
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

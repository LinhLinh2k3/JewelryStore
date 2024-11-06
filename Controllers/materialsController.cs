using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class materialsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // USER ZONE
        public ActionResult show(string link)
        {
            if (string.IsNullOrEmpty(link))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var products = db.products.Where(p => p.materials.matLink == link);
            if (products == null)
            {
                return HttpNotFound();
            }

            return View(new megalist() { productList = products.ToList() });
        }

        // ADMIN ZONE
        // GET: materials
        public ActionResult Index()
        {
            return View(new megalist() { user = db.users.Find(Session["userID"]) });
        }

        // GET: materials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matID,matName,matLink")] materials materials)
        {
            if (ModelState.IsValid)
            {
                db.materials.Add(materials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materials);
        }

        // GET: materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials materials = db.materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // POST: materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matID,matName,matLink")] materials materials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materials);
        }

        // GET: materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials materials = db.materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // POST: materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materials materials = db.materials.Find(id);
            db.materials.Remove(materials);
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

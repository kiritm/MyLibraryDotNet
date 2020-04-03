using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibraryDotNet472.Models;

namespace MyLibraryDotNet472.Context
{
    public class BCategoriesController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: BCategories
        public ActionResult Index()
        {
            return View(db.BCategories.ToList());
        }

        // GET: BCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCategory bCategory = db.BCategories.Find(id);
            if (bCategory == null)
            {
                return HttpNotFound();
            }
            return View(bCategory);
        }

        // GET: BCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BCategoryType")] BCategory bCategory)
        {
            if (ModelState.IsValid)
            {
                db.BCategories.Add(bCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bCategory);
        }

        // GET: BCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCategory bCategory = db.BCategories.Find(id);
            if (bCategory == null)
            {
                return HttpNotFound();
            }
            return View(bCategory);
        }

        // POST: BCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BCategoryType")] BCategory bCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bCategory);
        }

        // GET: BCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCategory bCategory = db.BCategories.Find(id);
            if (bCategory == null)
            {
                return HttpNotFound();
            }
            return View(bCategory);
        }

        // POST: BCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BCategory bCategory = db.BCategories.Find(id);
            db.BCategories.Remove(bCategory);
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

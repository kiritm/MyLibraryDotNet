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
    public class BFormatsController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: BFormats
        public ActionResult Index()
        {
            return View(db.BFormats.ToList());
        }

        // GET: BFormats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BFormat bFormat = db.BFormats.Find(id);
            if (bFormat == null)
            {
                return HttpNotFound();
            }
            return View(bFormat);
        }

        // GET: BFormats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BFormats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormatType")] BFormat bFormat)
        {
            if (ModelState.IsValid)
            {
                db.BFormats.Add(bFormat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bFormat);
        }

        // GET: BFormats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BFormat bFormat = db.BFormats.Find(id);
            if (bFormat == null)
            {
                return HttpNotFound();
            }
            return View(bFormat);
        }

        // POST: BFormats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormatType")] BFormat bFormat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bFormat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bFormat);
        }

        // GET: BFormats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BFormat bFormat = db.BFormats.Find(id);
            if (bFormat == null)
            {
                return HttpNotFound();
            }
            return View(bFormat);
        }

        // POST: BFormats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BFormat bFormat = db.BFormats.Find(id);
            db.BFormats.Remove(bFormat);
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

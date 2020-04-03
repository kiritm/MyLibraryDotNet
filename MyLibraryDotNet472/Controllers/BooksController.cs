using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibraryDotNet472.Context;
using MyLibraryDotNet472.Models;

namespace MyLibraryDotNet472.Controllers
{
    public class BooksController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.BCategory).Include(b => b.BFormat);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.BCategoryId = new SelectList(db.BCategories, "Id", "BCategoryType");
            ViewBag.BFormatId = new SelectList(db.BFormats, "Id", "FormatType");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookTitle,BookEdition,BookAuthor1,BookAuthor2,BookCategory,BookPurchasePrice,BookPublisher,BookISBN,BookStatus,BookStorage_Code,BookFormat,ReleaseDate,BFormatId,BCategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BCategoryId = new SelectList(db.BCategories, "Id", "BCategoryType", book.BCategoryId);
            ViewBag.BFormatId = new SelectList(db.BFormats, "Id", "FormatType", book.BFormatId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BCategoryId = new SelectList(db.BCategories, "Id", "BCategoryType", book.BCategoryId);
            ViewBag.BFormatId = new SelectList(db.BFormats, "Id", "FormatType", book.BFormatId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookTitle,BookEdition,BookAuthor1,BookAuthor2,BookCategory,BookPurchasePrice,BookPublisher,BookISBN,BookStatus,BookStorage_Code,BookFormat,ReleaseDate,BFormatId,BCategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BCategoryId = new SelectList(db.BCategories, "Id", "BCategoryType", book.BCategoryId);
            ViewBag.BFormatId = new SelectList(db.BFormats, "Id", "FormatType", book.BFormatId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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

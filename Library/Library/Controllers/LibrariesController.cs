using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{

    [Authorize]

    public class LibrariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Libraries
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
                return View("ManageLibraries", db.Libraries.ToList());
            else
                return View("Index", db.Libraries.ToList());
        }

        // GET: Libraries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library.Models.Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: Libraries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,libraryName,libraryAddress")] Models.Library library)
        {
            if (ModelState.IsValid)
            {
                db.Libraries.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(library);
        }

        // GET: Libraries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library.Models.Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,libraryName,libraryAddress")] Models.Library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(library);
        }

        // GET: Libraries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library.Models.Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Library.Models.Library library = db.Libraries.Find(id);
            db.Libraries.Remove(library);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.ViewModel;


namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            var infoBook = db.Books.Join(
                                        db.MembershipTypes,
                                        r => r.membershipType,
                                        m => m.ID,
                                        (r, m) => new InfoBookViewModel{
                                        genre = r.genre.genreName,
                                        book = r.bookName,
                                        ID = r.ID,
                                        dateAdded =r.dateAdded,
                                        releaseDate =r.releaseDate,
                                        author= r.author,
                                        summary = r.summary,
                                        membershipType =m.membershipType });

            if (User.IsInRole("Manager"))
                return View("Index",infoBook.ToList());
            else
                return View("ReadOnlyIndex", infoBook.ToList());  
        }

        // GET: Books/BooksByGenre/1
        public ActionResult BooksByGenre(int? genreID)
        {
            var books = db.Books.Include(m => m.genre);
            IEnumerable<Books> query = books;
            query = books.Where(m => m.genreID == genreID);

            var infoBook = query.Join(
                                        db.MembershipTypes,
                                        r => r.membershipType,
                                        m => m.ID,
                                        (r, m) => new InfoBookViewModel
                                        {
                                            genre = r.genre.genreName,
                                            book = r.bookName,
                                            ID = r.ID,
                                            dateAdded = r.dateAdded,
                                            releaseDate = r.releaseDate,
                                            author= r.author,
                                            summary = r.summary,
                                            membershipType = m.membershipType
                                        });
            if (User.IsInRole("Manager"))
                return View("Index", infoBook.ToList());
            else
                return View("ReadOnlyIndex", infoBook.ToList());

        }

        [HttpPost]
        public ActionResult Search(string genreID, string membershipTypeID, string date)
        {
            int queryParams = 0;
            int membershipCheck;
            int genreCheck;
            DateTime dateCheck;

            if (Int32.TryParse(membershipTypeID, out membershipCheck))
            {
                if (membershipCheck > 0)
                    queryParams += 1;
            }
            if (Int32.TryParse(genreID, out genreCheck))
            {
                if (genreCheck > 0)
                    queryParams += 2;
            }
            if (DateTime.TryParse(date, out dateCheck)){
                queryParams += 4;
            }

            var books = db.Books.Include(m => m.genre);
            IEnumerable<Books> query = books;

            switch (queryParams)
            {
                case 1:
                    query = books.Where(m => m.membershipType == membershipCheck);
                    break;
                case 2:
                    query = books.Where(m => m.genreID == genreCheck);
                    break;
                case 3:
                    query = books.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck);
                    break;
                case 4:
                    query = books.Where(m => m.releaseDate > dateCheck);
                    break;
                case 5:
                    query = books.Where(m => m.membershipType == membershipCheck && m.releaseDate > dateCheck);
                    break;
                case 6:
                    query = books.Where(m => m.genreID == genreCheck && m.releaseDate > dateCheck);
                    break;
                case 7:
                    query = books.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck && m.releaseDate > dateCheck);
                    break;
                default:
                    query = books;
                    break;
            }

            //var books = db.Books.Include(m => m.genre);
            //return View(books.ToList());
            var infoBook = query.Join(
                                        db.MembershipTypes,
                                        r => r.membershipType,
                                        m => m.ID,
                                        (r, m) => new InfoBookViewModel
                                        {
                                            genre = r.genre.genreName,
                                            book = r.bookName,
                                            ID = r.ID,
                                            dateAdded = r.dateAdded,
                                            releaseDate = r.releaseDate,
                                            author= r.author,
                                            summary = r.summary,
                                            membershipType = m.membershipType
                                        });
            if (User.IsInRole("Manager"))
                return View("Index", infoBook.ToList());
            else
                return View("ReadOnlyIndex", infoBook.ToList());
        }


        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }


        // GET: Books/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "ID,genreID,Name,dateAdded,releaseDate,author,summary, membershipType")] Books books)
        {

            if (ModelState.IsValid)
            {
                if (books.dateAdded < books.releaseDate || books.dateAdded > DateTime.Today || books.releaseDate > DateTime.Today )
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Books.Add(books);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID", books.genreID);
            return View(books);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID", books.genreID);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "ID,genreID,bookName,dateAdded,releaseDate,author,summary,membershipType")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID", books.genreID);
            return View(books);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
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

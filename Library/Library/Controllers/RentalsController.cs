using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using System.Data.Entity;
using System.Collections;
using Library.ViewModel;
using System.Data;

namespace Library.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rentals
        
        public ActionResult Index()
        {
            var user = User.Identity.Name;

            var rentals = db.Rentals.Where(m => m.rentalExpiration >= DateTime.Today);

            if (User.IsInRole("Manager"))
            {
                //IEnumerable<Rentals> groupByRentals = rentals.GroupBy(rentals,user);
                var rentalsGenre = rentals.Join(db.Books, r => r.rentalBook, m => m.bookName, (r,m) => new RentalViewModel {book = r.rentalBook, genre = m.genre.genreName, rentalUser = r.rentalUser , rentalExpiration = r.rentalExpiration});       
                return View("Index", rentalsGenre.ToList());
            }
            else
            {
                IEnumerable<Rentals> userRentals = rentals.Where(m => m.rentalUser == user);
                return View("ReadOnlyIndex", userRentals.ToList());
            }
        }
        public ActionResult IndexAll()
        {
            var user = User.Identity.Name;
            var rentals = db.Rentals;

            if (User.IsInRole("Manager"))
            {
                var rentalsGenre = rentals.Join(db.Books, r => r.rentalBook, m => m.bookName, (r, m) => new RentalViewModel { book = r.rentalBook, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
                return View("Index", rentalsGenre.ToList());
            }

            else { 
            IEnumerable<Rentals> userAllRentals = rentals.Where(m => m.rentalUser == user);
            return View("ReadOnlyIndex", userAllRentals.ToList());
            }

        }

        [Authorize (Roles = "Manager")]
        public ActionResult GroupBy1()
        {
            var rentals = db.Rentals;
            var rentalsGenre = rentals.Join(db.Books, r => r.rentalBook, m => m.bookName, (r, m) => new RentalViewModel { book = r.rentalBook, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
            
            return View("GroupByUser", rentalsGenre.ToList());
           
        }

        [Authorize(Roles = "Manager")]
        public ActionResult GroupBy2()
        {
            var rentals = db.Rentals;
            var rentalsGenre = rentals.Join(db.Books, r => r.rentalBook, m => m.bookName, (r, m) => new RentalViewModel { book = r.rentalBook, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
            
            return View("GroupByGenres", rentalsGenre.ToList());

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
            if (DateTime.TryParse(date, out dateCheck))
            {
                queryParams += 4;
            }

            var books = db.Books.Include(m => m.genre);
            IEnumerable<Books> booksQuery = books;
            var rentals = db.Rentals;
            IEnumerable<Rentals> rentalsQuery = rentals;

            switch (queryParams)
            {
                case 1:
                    booksQuery = books.Where(m => m.membershipType == membershipCheck);
                    break;
                case 2:
                    booksQuery = books.Where(m => m.genreID == genreCheck);
                    break;
                case 3:
                    booksQuery = books.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck);
                    break;
                case 4:
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                case 5:
                    booksQuery = books.Where(m => m.membershipType == membershipCheck);
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                case 6:
                    booksQuery = books.Where(m => m.genreID == genreCheck);
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                case 7:
                    booksQuery = books.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck);
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                default:
                    break;
            }

            var rentalsGenre = rentalsQuery.Join(booksQuery, r => r.rentalBook, m => m.bookName, (r, m) => new RentalViewModel { book = r.rentalBook, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
            return View("Index", rentalsGenre.ToList());
        }

        public ActionResult Rent(string book)
        {
            var user = User.Identity.Name;
            var rentals = db.Rentals;
            IEnumerable<Rentals> userRentals = rentals.Where(m => m.rentalUser == user && m.rentalExpiration>=DateTime.Today);
            var dupCheck = false;

            foreach(Rentals rental in userRentals)
            {
                if (rental.rentalBook == book)
                    dupCheck = true;               
            }
            if (dupCheck)
            {
             return RedirectToAction("Index");

            }

            else
            {
                var rental = new Rentals
                {
                    rentalUser = User.Identity.Name,
                    rentalExpiration = DateTime.Today.AddDays(3)                                       
                };

                rental.rentalBook = book;

                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Library.Models
{
    public class StatsController : Controller
    {
      
        private ApplicationDbContext db = new ApplicationDbContext();
       
          public ActionResult RentalsCount()
          {
              var rentals = db.Rentals;
              var rentalsGenre = rentals.Join(db.Books, r => r.rentalBook, m => m.bookName, (r, m) => new RentalViewModel { book = r.rentalBook, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration }).ToList();
            
              var pieGenreCollection = rentalsGenre.GroupBy(t => t.genre, (key, g) =>
            {
                var arr = new String[2];
                arr[0] = g.Count().ToString();
                arr[1] = key;

                return arr;
            }).ToArray();

            ViewBag.Title = "Rentals per Genre";
            ViewData["data"] = pieGenreCollection;


            return View("Stats", pieGenreCollection);

          }

        public ActionResult BooksCount()
        {
            var books = db.Books;
            var booksGenres = books.Join(db.Genres, r => r.genreID, m => m.ID, (r, m) => new InfoBookViewModel { book = r.bookName, genre = m.genreName }).ToList();

            var pieGenreCollection = booksGenres.GroupBy(t => t.genre, (key, g) =>
            {
                var arr = new string[2];
                arr[0] = g.Count().ToString();
                arr[1] = key;

                return arr;
            }).ToArray();

            ViewBag.Title = "Books Per Genre";
            ViewData["data"] = pieGenreCollection;


            return View("Stats", pieGenreCollection);

        }

        
    }
}
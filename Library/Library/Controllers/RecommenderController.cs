using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

using System.Web.Security;

using NReco.CF.Taste.Model;
using NReco.CF.Taste.Impl.Model.File;
using NReco.CF.Taste.Impl.Eval;
using NReco.CF.Taste.Eval;
using NReco.CF.Taste.Impl.Similarity;
using NReco.CF.Taste.Impl.Neighborhood;
using NReco.CF.Taste.Impl.Recommender;
using NReco.CF.Taste.Impl.Recommender.SVD;
using NReco.CF.Taste.Impl.Model;
using NReco.CF.Taste.Recommender;

using CsvHelper;
using Library.Models;

namespace Controllers
{

    public class RecommenderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        static IDataModel dataModel;

        public ActionResult GetRecommendedbooks()
        {
            var csv = new CsvReader(new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/books.csv")));
            var records = csv.GetRecords<BookRecord>().ToList();
            int favouriteGenre = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.genreID).SingleOrDefault();
            var userRentals = db.Rentals.Where(m => m.rentalUser == User.Identity.Name).Join(db.Books,
                                                                                                       r => r.rentalBook,
                                                                                                       m => m.bookName,
                                                                                                       (r, m) => new
                                                                                                       {
                                                                                                           genreId = m.genreID,
                                                                                                           bookName = m.bookName,
                                                                                                           rentalUer = r.rentalUser
                                                                                                       });
            if (userRentals.Count() == 0)
            {
                return Json(new Dictionary<string, object>() {
                {"book_id", 0},
                {"rating", 0},
            });
            }
            else if (userRentals.Where(m => m.genreId == favouriteGenre).Count() != 0)
                userRentals = userRentals.Where(m => m.genreId == favouriteGenre);

            long[] bookIdsTemp = new long[userRentals.Count()];
            int bookCounter = 0;
            foreach (var item in userRentals)
            {
                foreach (var record in records)
                {
                    if (item.bookName == record.title)
                    {
                        if (!bookIdsTemp.Contains(record.bookId)) { 
                            bookIdsTemp[bookCounter] = record.bookId;
                            bookCounter++;
                        }
                    }
                }
            }
            long[] bookIds = new long[bookCounter];
            for (int i = 0; i < bookCounter; i++)
                bookIds[i] = bookIdsTemp[i];

            var dataModel = GetDataModel();

            // recommendation is performed for the user that is missed in the preferences data
            var plusAnonymModel = new PlusAnonymousUserDataModel(dataModel);
            var prefArr = new GenericUserPreferenceArray(userRentals.Count());

            prefArr.SetUserID(0, PlusAnonymousUserDataModel.TEMP_USER_ID);
            for (int i = 0; i < bookIds.Length; i++)
            {
                prefArr.SetItemID(i, bookIds[i]);

                // in this example we have no ratings of books preferred by the user
                prefArr.SetValue(i, 5); // lets assume max rating
            }
            plusAnonymModel.SetTempPrefs(prefArr);

            var similarity = new LogLikelihoodSimilarity(plusAnonymModel);
            var neighborhood = new NearestNUserNeighborhood(15, similarity, plusAnonymModel);
            var recommender = new GenericUserBasedRecommender(plusAnonymModel, neighborhood, similarity);
            var recommendedItems = recommender.Recommend(PlusAnonymousUserDataModel.TEMP_USER_ID, 1, null);

            if (recommendedItems.Count() == 0)
            {
                return Json(new Dictionary<string, object>() {
                {"book_id", 0},
                {"rating", 0},
            });
            }

            return Json(recommendedItems.Select(ri => new Dictionary<string, object>() {
                {"book_id", ri.GetItemID() },
                {"rating", ri.GetValue() },
            }).ToArray()[0]);
        }

        /// <summary>
        /// Loads data model (preferences data) from the file. In the same manner data can be loaded from SQL database (or MongoDb).
        /// </summary>
        /// <remarks>
        /// Data model is cached to avoid CSV parsing on each request.
        /// </remarks>
        IDataModel GetDataModel()
        {
            var pathToDataFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/book_ratings.csv");

            var cacheKey = "RecommenderDataModel:" + pathToDataFile;
            var dataModel = HttpRuntime.Cache.Get(cacheKey) as IDataModel;
            if (dataModel == null)
            {
                dataModel = new FileDataModel(pathToDataFile, false, FileDataModel.DEFAULT_MIN_RELOAD_INTERVAL_MS, false);
                HttpRuntime.Cache[cacheKey] = dataModel;
            }
            return dataModel;
        }

        public ActionResult GetBooks()
        {
            var csv = new CsvReader(new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/books.csv")));
            var records = csv.GetRecords<BookRecord>();
            return Json(records, JsonRequestBehavior.AllowGet);
        }

        public class BookRecord
        {
            public int bookId { get; set; }
            public string title { get; set; }
        }

    }
}

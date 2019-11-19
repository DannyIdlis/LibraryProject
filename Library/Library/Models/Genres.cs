using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Genres
    {
        public int ID { get; set; }

        [Display(Name = "Genre Name")]
        public string genreName { get; set; }

        //public enum genreEnum 
        //{ 
        //    Comedy, 
        //    Romance, 
        //    Drama, 
        //    Action, 
        //    Horror,
        //    SciFi,
        //    Kids, 
        //    Family,
        //    Biography,
        //    Adult 
        //} 
    }
}

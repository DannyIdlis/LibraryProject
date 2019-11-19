using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Books
    {
        [Required]
        [Display(Name = "Book ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        [StringLength(100)]
        public string bookName { get; set; }

        [Display(Name = "Genre")]
        public Genres genre { get; set; }

        [Required]
        [Display(Name = "Genre ID")]
        public int genreID { get; set; }

        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Author")]
        [StringLength(150)]
        public string author { get; set; }
        
        [Display(Name = "Membership Type")]
        public int membershipType { get; set; }

        [Display(Name = "Summary")]
        [StringLength(500)]
        public string summary { get; set; }
     
    }

}
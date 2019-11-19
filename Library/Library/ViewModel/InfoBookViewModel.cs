using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.ViewModel
{
    public class InfoBookViewModel
    {

        [Display(Name = "Genre Name")]
        public string genre { get; set; }

        [Display(Name = "Book Name")]
        public string book { get; set; }
        
        [Required]
        [Display(Name = "Book ID")]
        public int ID { get; set; }
    
        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Author")]
        public string author { get; set; }

        [Display(Name = "Membership Type")]
        public string membershipType { get; set; }

        [Display(Name = "Summary")]
        public string summary { get; set; }

    }
}
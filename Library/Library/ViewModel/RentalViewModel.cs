using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.ViewModel
{
    public class RentalViewModel
    {
        [Display(Name = "Genre Name")]
        public string genre { get; set; }

        [Display(Name = "Book Name")]
        public string book { get; set; }

        [Display(Name = "Rental Expiration")]
        public DateTime rentalExpiration { get; set; }

        [Display(Name = "User rented")]
        public string rentalUser { get; set; }
    }
}
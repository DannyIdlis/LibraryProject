using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Principal;

namespace Library.Models
{
    public class Rentals
    {
        public int ID { get; set; }

        [Display(Name = "Renting User")]
        public string rentalUser { get; set; }

        [Display(Name = "Renting Book")]
        public string rentalBook { get; set; }     

        [Display(Name = "Rental Expiration Date")]
        public DateTime rentalExpiration { get; set; }

    }

}

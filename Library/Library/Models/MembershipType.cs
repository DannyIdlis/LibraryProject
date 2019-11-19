using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class MembershipType
    {
        [Required]
        [Display(Name = "Membership Type ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        [StringLength(100)]
        public string membershipType { get; set; }

        [Display(Name = "Duration")]
        public int duration { get; set; }

        [Display(Name = "Payment")]
        public int payment { get; set; }
       

    }
}
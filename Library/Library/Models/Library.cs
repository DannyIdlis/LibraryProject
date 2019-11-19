using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Library
    {
        [Required]
        [Display(Name = "Library ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Library Name")]
        [StringLength(100)]
        public string libraryName { get; set; }

        [Required]
        [Display(Name = "Library Address")]
        public string libraryAddress { get; set; }
    }

}
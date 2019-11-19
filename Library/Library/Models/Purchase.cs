using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Library.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
        public DateTime Expiration { get; set; }
    }
}

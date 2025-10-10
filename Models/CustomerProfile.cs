using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.Models
{
    public class CustomerProfile
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CustomerId { get; set; }
        public Customer ? customer { get; set; }
    }
}
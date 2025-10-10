using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [DefaultValue("Pending")]
        public string Status { get; set; } = "Pending";
        public int? ScreenId { get; set; }
        public Screen? screen { get; set; }
        public int? CustomerId { get; set; }
        public Customer ? customer { get; set; }
    }
}


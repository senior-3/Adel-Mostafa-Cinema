using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Cinema_Booking_System.DTOs
{
    public class ReadCustomerForBookingsDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class ReadCustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? TotalBooking { get; set; } = 0;
        public string? recentWatchedMovie { get; set; }
        public ReadCustomerProfileDTO? profile { get; set; }
        public IEnumerable<ReadBookingDTO>? bookings { get; set; }
    }
    
    public class UpdateCustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ReadCustomerProfileDTO? profile { get; set; }
    }
}
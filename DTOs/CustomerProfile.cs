using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.DTOs
{
    public class UpdateCustomerProfileDTO
    {

    }
    public class ReadCustomerProfileDTO
    {
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
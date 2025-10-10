using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.DTOs
{
    public class CreateScreenDTO
    {
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
        public string ?MovieName { get; set; }
    }
    public class ReadScreenDTO
    {
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
    }

    public class ReadScreenDetailsDTO
    {
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
        public int RemainingSeats { get; set; }
        public ReadMovieDetailsOnlyDTO? movie { get; set; }

    }
    
    public class UpdateScreenDTO
    {
        public int Capacity { get; set; }
        public string ?movieName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.DTOs
{
    public class CreateBookingDTO
    {
      public string Email { get; set; } = string.Empty;
      public int ScreenNumber { get; set; }
      public int SeatNumber { get; set; }
    }
  public class ReadBookingDTO
  {
    public DateTime BookingDate { get; set; }
    public int SeatNumber { get; set; }
    public string Status { get; set; }
    public ReadScreenDTO? screen { get; set; }
  }

  public class ReadBookingDetailsDTO
  {
    public int SeatNumber { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime BookingDate { get; set; }
    public string MovieName { get; set; } = string.Empty;
    public ReadCustomerForBookingsDTO? Customer { get; set; }

  }

  public class TicketsDTO
  {
    public string MovieName { get; set; } = string.Empty;
    public int SoldTickets { get; set; }
  }
    
    public class UpdateBookingDTO
    {
        public int SeatNumber { get; set; }
        public string Status{ get; set; } = string.Empty;
    }
} 
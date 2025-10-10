using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class BookingRepo : GenericRepo<Booking> ,IBookingRepo
    {
        public BookingRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<IList<Booking>> GetAllBookings()
        {
            var bookings = await _db.booking.Include(x => x.customer).Include(x => x.screen).ThenInclude(x => x.movie).ToListAsync();

            return bookings;
        }

        public async Task<Booking> GetBooking(int id)
        {
            var Booking = await _db.booking.FirstOrDefaultAsync(x => x.Id == id);
            return Booking;
        }

    }
}
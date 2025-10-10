using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.DTOs;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepo _br;
        private readonly IScreenRepo _sr;
        private readonly ICustomerRepo _cr;
        public BookingController(IBookingRepo br , ICustomerRepo cr , IScreenRepo sr)
        {
            _br = br;
            _cr = cr;
            _sr = sr;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _br.GetAllBookings();

            if (!bookings.Any()) return BadRequest("No Bookings Available");

            var veiwBookings = bookings.Select(x => new ReadBookingDetailsDTO
            {
                SeatNumber = x.SeatNumber,
                Status = x.Status,
                BookingDate = x.BookingDate,
                MovieName = x.screen.movie.Title,
                Customer = new ReadCustomerForBookingsDTO
                {
                    Name = x.customer.Name,
                    Email = x.customer.Email,
                    Phone = x.customer.Phone,

                },
            }).ToList();

            return Ok(veiwBookings);
        }

        [HttpGet("SoldTickets")]
        public async Task<IActionResult> SoldTickets()
        {
            var bookings = await _br.GetAllBookings();
            if (!bookings.Any()) return BadRequest("No Bookings Available");

            var veiwBookings = bookings.GroupBy(x => x.screen.movie.Title).Select(x => new TicketsDTO
            {
                MovieName = x.Key,
                SoldTickets = x.Count(),

            }).ToList();

            return Ok(veiwBookings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] int id, [FromBody] UpdateBookingDTO bo)
        {
            var Booking = await _br.GetBooking(id);

            if (Booking == null) return BadRequest("Invalid Id");

            Booking.Id = id;
            if (bo.SeatNumber > 0)
            {
                Booking.SeatNumber = bo.SeatNumber;
            }
            if (!string.IsNullOrWhiteSpace(bo.Status))
            {
                Booking.Status = bo.Status;
            }

            await _br.Update(Booking);

            return Ok("Done!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var Booking = await _br.GetBooking(id);

            if (Booking == null) return BadRequest("Invalid Id");

            await _br.Delete(Booking);
            return Ok("Done!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO newBo)
        {

            var cus = await _cr.GetCustomerByEmail(newBo.Email);

            if (cus == null) return BadRequest("Invalid Email");

            var scr = await _sr.GetScreenByScreenNum(newBo.ScreenNumber);

            if (scr == null) return BadRequest("Invalid Screen Num");

            var Booking = new Booking
            {
                BookingDate = DateTime.Now,
                customer = cus,
                CustomerId = cus.Id,
                screen = scr,
                ScreenId = scr.Id,
                SeatNumber = newBo.SeatNumber,
            };

            await _br.Create(Booking);

            return Ok("Done!");
        }
    }
}
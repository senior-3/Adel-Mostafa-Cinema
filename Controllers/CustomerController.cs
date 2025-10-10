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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _cr;
        public CustomerController(ICustomerRepo cr)
        {
            _cr = cr;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var cus = await _cr.GetAllCustomers();

            if (!cus.Any()) return NotFound("No customers available");

            var viewCus = cus.Select(x => new ReadCustomerDTO
            {
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                TotalBooking = x.bookings.Any() ? x.bookings.Count() : null,
                recentWatchedMovie = x.bookings.Any() ? x.bookings.Select(x => x.screen?.movie?.Title).First() : null,
                profile = x.customerProfile == null ? null : new ReadCustomerProfileDTO()
                {
                    Address = x.customerProfile.Address,
                    DateOfBirth = x.customerProfile.DateOfBirth
                },
                bookings = x.bookings.Any() ? x.bookings.Select(b => new ReadBookingDTO
                {
                    SeatNumber = b.SeatNumber,
                    BookingDate = b.BookingDate,
                    Status = b.Status,
                    screen = b.screen == null ? null : new ReadScreenDTO()
                    {
                        ScreenNumber = b.screen.ScreenNumber,
                        Capacity = b.screen.Capacity,
                    }
                }).ToList() : null
            }).ToList();



            return Ok(viewCus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCus([FromRoute] int id, [FromBody] UpdateCustomerDTO newcus)
        {
            var oldCus = await _cr.GetCusById(id);

            if (oldCus == null) return NotFound("Invalid Id");

            oldCus.Id = id;
            oldCus.Name = newcus.Name;
            oldCus.Email = newcus.Email;
            oldCus.Phone = newcus.Phone;

            var pro = new CustomerProfile
            {
                Address = newcus.profile.Address,
                DateOfBirth = newcus.profile.DateOfBirth
            };

            await _cr.UpdateCus(oldCus, pro);

            return Ok("Done!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCus([FromRoute] int id)
        {
            var res = await _cr.DeleteCus(id);

            if (res) return Ok("Done!");

            return BadRequest("invalid Id or assigned bookings");
        }

        [HttpPost]
        public async Task<IActionResult> AddCus([FromBody] UpdateCustomerDTO newCus)
        {
            var cus = new Customer
            {
                Name = newCus.Name,
                Email = newCus.Email,
                Phone = newCus.Phone,

            };

            var pro = new CustomerProfile
            {
                Address = newCus.profile.Address,
                DateOfBirth = newCus.profile.DateOfBirth
            };

            await _cr.CreateCus(cus, pro);

            return Ok("Done!");

        }

        
    }
}
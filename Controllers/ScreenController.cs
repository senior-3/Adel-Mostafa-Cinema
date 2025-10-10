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
    public class ScreenController : ControllerBase
    {
        private readonly IMovieRepo _mr;
        private readonly IScreenRepo _sr;
        public ScreenController(IScreenRepo sr ,IMovieRepo mr)
        {
            _sr = sr;
            _mr = mr;
        }

        [HttpGet]
        public async Task<IActionResult> GetScreens()
        {
            var scr = await _sr.GetScreens();

            var veiwSrc = scr.Select(x => new ReadScreenDetailsDTO
            {
                ScreenNumber = x.ScreenNumber,
                Capacity = x.Capacity,
                RemainingSeats = x.Capacity - (x.bookings != null ? x.bookings.Count : 0),
                movie = x.movie != null ? new ReadMovieDetailsOnlyDTO
                {
                    Title = x.movie.Title,
                    Description = x.movie.Description,
                    Duration = x.movie.Duration,
                    Rating = x.movie.Rating,
                    ReleaseDate = x.movie.ReleaseDate,

                } : null,


            }).ToList();

            return Ok(veiwSrc);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen([FromRoute] int id)
        {
            var res = await _sr.DeleteScreen(id);

            if (res == false) return BadRequest("booking were found or invalid id");

            return Ok("Done!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScreen([FromRoute] int id, UpdateScreenDTO newScr)
        {
            var res = await _sr.GetScreenById(id);

            var mov = await _mr.GetMovieByName(newScr.movieName);

            if (res == null) return BadRequest("invalid Id");
            if (mov == null || newScr.movieName == null) return BadRequest("invalid movie name");

            res.Capacity = newScr.Capacity;
            res.movie = mov;
            res.MovieId = mov.Id;
            res.Id = id;

            await _sr.Update(res);

            return Ok("Done!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateScreen([FromBody] CreateScreenDTO newScr)
        {
            if (newScr == null || newScr.MovieName == null) return BadRequest("Invalid Input");

            var mov = await _mr.GetMovieByName(newScr.MovieName);

            if (mov == null) return BadRequest("Invalid Movie Name");

            var CheckScreenNum = await _sr.CheckScreenNum(newScr.ScreenNumber);

            if (!CheckScreenNum) return BadRequest("Screen number already exists");

            var scr = new Screen
            {
                Capacity = newScr.Capacity,
                ScreenNumber = newScr.ScreenNumber,
                movie = mov,
                MovieId = mov.Id,
            };

            await _sr.Create(scr);
            return Ok("Done!");
        }
    }
}
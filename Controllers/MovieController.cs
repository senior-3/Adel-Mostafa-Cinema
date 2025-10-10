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
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _mr;
        public MovieController(IMovieRepo mr)
        {
            _mr = mr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var res = await _mr.GetMovies();

            if (!res.Any()) return NoContent();

            var veiwRes = res.Select(x => new ReadMovieDTO()
            {
                Title = x.Title,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                Rating = x.Rating,
                actors = x.actors.Select(x => new ReadActorDTO()
                {
                    Name = x.actor.Name,
                    Age = x.actor.Age,
                    Nationality = x.actor.Nationality
                }).ToList(),
                screens = x.screens.Select(x => new ReadScreenDTO()
                {
                    ScreenNumber = x.ScreenNumber,
                    Capacity = x.Capacity
                }).ToList()
            });

            return Ok(veiwRes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] UpdateMovieDTO newMov)
        {
            var mov = await _mr.GetById(id);

            if (mov == null) return NotFound();

            mov.Id = id;
            mov.Description = newMov.Description;
            mov.Duration = newMov.Duration;
            mov.Rating = newMov.Rating;

            await _mr.Update(mov);

            return Ok("Done!");

        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDTO newMov)
        {
            var mov = new Movie()
            {
                Title = newMov.Title,
                Description = newMov.Description,
                Duration = newMov.Duration,
                Rating = newMov.Rating,
                ReleaseDate = newMov.ReleaseDate,
            };

            if (!await _mr.ValidateTR(mov)) return BadRequest("Validation Error");

            var actors = new List<Actor>();

            foreach (var i in newMov.actors)
            {
                var ac = new Actor()
                {
                    Name = i.Name,
                    Age = i.Age,
                    Nationality = i.Nationality
                };

                actors.Add(ac);
            }

            await _mr.CreateMovie(mov, actors);

            return Ok("Done!");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            var res = await _mr.DeleteMovie(id);

            if (res == false) return BadRequest("Movie is on active screen");

            return Ok("Done!");
        }
    }
}
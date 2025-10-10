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
    public class ActorController : ControllerBase
    {
        private readonly IActorRepo _ar;
        private readonly IMovieRepo _mr;
        public ActorController(IActorRepo ar , IMovieRepo mr)
        {
            _ar = ar;
            _mr = mr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var res = await _ar.GetActors();

            if (!res.Any()) return NotFound("No Actors");

            var veiwRes = res.Select(x => new ReadActorAndMoviesDTO()
            {
                Name = x.Name,
                Age = x.Age,
                Nationality = x.Nationality,
                movies = x.movies.Select(x => new ReadMovieDetailsOnlyDTO()
                {
                    Title = x.movie.Title,
                    Description = x.movie.Description,
                    Duration = x.movie.Duration,
                    Rating = x.movie.Rating,
                    ReleaseDate = x.movie.ReleaseDate,
                })
            });

            return Ok(veiwRes);
        }

        [HttpGet("More_than_one")]
        public async Task<IActionResult> GetBigActors()
        {
            var res = await _ar.GetActors();

            if (!res.Any()) return NotFound("No Actors");

            var veiwRes = res.Where(x => x.movies.Count > 1).Select(x => new ReadActorAndMoviesDTO()
            {
                Name = x.Name,
                Age = x.Age,
                Nationality = x.Nationality,
                movies = x.movies.Select(x => new ReadMovieDetailsOnlyDTO()
                {
                    Title = x.movie.Title,
                    Description = x.movie.Description,
                    Duration = x.movie.Duration,
                    Rating = x.movie.Rating,
                    ReleaseDate = x.movie.ReleaseDate,
                })
            });

            return Ok(veiwRes);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int id)
        {
            var act = await _ar.DeleteActor(id);

            if (act == false) return BadRequest("Notfound or assigned to movie");

            return Ok("Done!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] CreateActorDTO act)
        {
            if (!ModelState.IsValid) return BadRequest("Validation Error");

            var actor = new Actor
            {
                Name = act.Name,
                Age = act.Age,
                Nationality = act.Nationality
            };
            var movs = new List<Movie>();
            if (act.MovieNames.Any())
            {

                foreach (var i in act.MovieNames)
                {
                    var mov = await _mr.GetMovieByName(i);

                    if (mov == null) return BadRequest("Invalid Movie Name");

                    movs.Add(mov);
                }
            }
            await _ar.CreateActor(actor, movs);
            return Ok("Done!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor([FromRoute] int id , [FromBody] CreateActorDTO act)
        {
            if (!ModelState.IsValid) return BadRequest("Validation Error");

            var actor = await _ar.GetActorById(id);

            if (actor == null) return BadRequest("Invalid Id");

            if (!string.IsNullOrWhiteSpace(act.Nationality)) actor.Nationality = act.Nationality;
            if (!string.IsNullOrWhiteSpace(act.Name)) actor.Name = act.Name;
            if (act.Age > 0) { actor.Age = act.Age; }
            
            actor.Id = id;

            var movs = new List<Movie>();
            if (act.MovieNames.Any())
            {

                foreach (var i in act.MovieNames)
                {
                    var mov = await _mr.GetMovieByName(i);

                    if (mov == null) return BadRequest("Invalid Movie Name");

                    var checkmov = await _ar.CheckMovieList(actor, mov);

                    if (checkmov) movs.Add(mov);

                }
            }
            await _ar.UpdateActor(actor, movs);
            return Ok("Done!");
        }

       
    }
}
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
    public class MovieRepo : GenericRepo<Movie>, IMovieRepo
    {
        private readonly IActorRepo _ar;
        private readonly IMovieActorRepo _ma;
        public MovieRepo(AppDb _db , IActorRepo ar , IMovieActorRepo ma) : base(_db)
        {
            _ar = ar;
            _ma = ma;
        }

        public async Task CreateMovie(Movie mov, List<Actor> actors)
        {
            await _db.movie.AddAsync(mov);
            await _db.SaveChangesAsync();

            if (actors.Any())
            {
                foreach (var i in actors)
                {
                    var res = await _ar.Create(i);
                    await _ma.CreateMA(mov, res);
                }
            }
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var mov = await _db.movie.Include(x => x.screens).FirstOrDefaultAsync(x => x.Id == id);

            if (mov == null) return false;
            
            if (mov.screens.Any()) return false;

            await Delete(mov);

            return true;
        }

        public async Task<Movie> GetMovieByName(string name)
        {
            var res = await _db.movie.FirstOrDefaultAsync(x => x.Title == name);

            return res;
        }

        public async Task<IList<Movie>> GetMovies()
        {
            var res = await _db.movie.Include(x => x.screens)
                                    .Include(x => x.actors)
                                    .ThenInclude(x => x.actor)
                                    .Where(x => x.ReleaseDate <= DateTime.Now)
                                    .OrderByDescending(x => x.Rating)
                                    .ToListAsync();
            return res;
        }

        public async Task<bool> ValidateTR(Movie mov)
        {
            var res = await _db.movie.FirstOrDefaultAsync(x => x.Title == mov.Title);

            if (res != null) return false;

            var release = await _db.movie.FirstOrDefaultAsync(x => x.ReleaseDate == mov.ReleaseDate);


            if (release != null) return false;

            return true;
        }
    }
}
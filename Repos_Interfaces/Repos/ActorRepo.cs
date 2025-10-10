using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class ActorRepo : GenericRepo<Actor>, IActorRepo
    {

        public ActorRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<bool> CheckMovieList(Actor actor, Movie mov)
        {
            foreach (var i in actor.movies)
            {
                if (i.movie.Title == mov.Title) return false;
            }
            return true;
        }

        public async Task CreateActor(Actor act, IList<Movie> movs)
        {
            await Create(act);

            foreach(var mov in movs)
            {
                
            var MA = new MovieActor
            {
                actor = act,
                ActorId = act.Id,
                movie = mov,
                MovieId = mov.Id
            };

            await _db.movieActor.AddAsync(MA);
            await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteActor(int id)
        {
            var act = await _db.actor.Include(x => x.movies).FirstOrDefaultAsync(x => x.Id == id);

            if (act == null) return false;
            if (act.movies.Any()) return false;

            await Delete(act);

            return true;
        }

        public async Task<Actor> GetActorById(int id)
        {
            var actor = await _db.actor.Include(x => x.movies).ThenInclude(x => x.movie).FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task<IList<Actor>> GetActors()
        {
            var res = await _db.actor.Include(x => x.movies).ThenInclude(x => x.movie).ToListAsync();

            return res;
        }

        public async Task UpdateActor(Actor act, IList<Movie> movs)
        {
            await Update(act);

            foreach(var mov in movs)
            {
                
            var MA = new MovieActor
            {
                actor = act,
                ActorId = act.Id,
                movie = mov,
                MovieId = mov.Id
            };

            await _db.movieActor.AddAsync(MA);
            await _db.SaveChangesAsync();
            }
        }
    }
}
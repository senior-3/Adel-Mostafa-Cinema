using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Project.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class MovieActorRepo : GenericRepo<MovieActor> , IMovieActorRepo
    {
        public MovieActorRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task CreateMA(Movie mov , Actor act)
        {
            var res = new MovieActor()
            {
                MovieId = mov.Id,
                ActorId = act.Id,
                movie = mov,
                actor = act
            };

            await _db.movieActor.AddAsync(res);
            await _db.SaveChangesAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;
using Project.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface IMovieActorRepo : IGenericRepo<MovieActor>
    {
        Task CreateMA(Movie mov , Actor actor);
    }
}
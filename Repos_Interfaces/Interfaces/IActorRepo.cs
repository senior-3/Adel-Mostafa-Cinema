using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface IActorRepo : IGenericRepo<Actor>
    {
        Task<IList<Actor>> GetActors();
        Task<bool> DeleteActor(int id);
        Task CreateActor(Actor act, IList<Movie> movs);
        Task<Actor> GetActorById(int id);
        Task<bool> CheckMovieList(Actor actor, Movie mov);
        Task UpdateActor(Actor act, IList<Movie> movs);
    }
}
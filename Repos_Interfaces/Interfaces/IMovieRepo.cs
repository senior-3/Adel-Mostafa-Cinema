using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface IMovieRepo : IGenericRepo<Movie>
    {
        Task<IList<Movie>> GetMovies();
        Task<bool> ValidateTR(Movie mov);
        Task CreateMovie(Movie mov, List<Actor> actors);
        Task<bool> DeleteMovie(int id);
        Task<Movie> GetMovieByName(string name);
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.DTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<CreateActorDTO>? actors { get; set; }
    }
    public class UpdateMovieDTO
    {
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Rating { get; set; }
    }
    public class ReadMovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<ReadScreenDTO> screens { get; set; }
        public IList<ReadActorDTO> actors { get; set; }
    }

    public class ReadMovieDetailsOnlyDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
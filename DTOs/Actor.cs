using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.DTOs
{
    public class CreateActorDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public IList<string>? MovieNames { get; set; }
    }
    public class ReadActorAndMoviesDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public IEnumerable<ReadMovieDetailsOnlyDTO>? movies { get; set; }
    }
    public class ReadActorDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
    }
}
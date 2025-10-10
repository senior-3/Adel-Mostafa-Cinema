using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Project.Models
{
    public class MovieActor
    {
        public int MovieId { get; set; }
        public Movie? movie { get; set; }
        public int ActorId { get; set; }
        public Actor ?actor { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Booking_System.Models
{
    [Index(nameof(ScreenNumber), IsUnique = true)]
    public class Screen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ScreenNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        public int? MovieId { get; set; }
        public Movie? movie { get; set; }
        public IList<Booking> ?bookings { get; set; }
    }
}


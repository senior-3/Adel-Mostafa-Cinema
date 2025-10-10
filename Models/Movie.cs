using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Cinema_Booking_System.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }
        [Range(0, 10)]
        public decimal Rating { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public IList<Screen>? screens { get; set; }
        public IList<MovieActor> ?actors { get; set; }
    }
}

 
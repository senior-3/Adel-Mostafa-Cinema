using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Cinema_Booking_System.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }
        public IList<MovieActor> ?movies { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Cinema_Booking_System.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "The Last Kingdom", Description = "An epic tale of courage and loyalty.", Duration = 145, Rating = 8.7m, ReleaseDate = new DateTime(2022, 5, 12) },
                new Movie { Id = 2, Title = "Galactic Odyssey", Description = "A sci-fi journey beyond imagination.", Duration = 132, Rating = 9.1m, ReleaseDate = new DateTime(2023, 3, 9) },
                new Movie { Id = 3, Title = "Silent Whispers", Description = "A thrilling mystery in a quiet town.", Duration = 118, Rating = 7.9m, ReleaseDate = new DateTime(2021, 10, 22) }
            );

          
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "John Carter", Age = 35, Nationality = "American" },
                new Actor { Id = 2, Name = "Emma Johnson", Age = 29, Nationality = "British" },
                new Actor { Id = 3, Name = "Kenji Tanaka", Age = 41, Nationality = "Japanese" },
                new Actor { Id = 4, Name = "Sophia Rossi", Age = 32, Nationality = "Italian" }
            );

         
            modelBuilder.Entity<Screen>().HasData(
                new Screen { Id = 1, ScreenNumber = 1, Capacity = 120, MovieId = 1 },
                new Screen { Id = 2, ScreenNumber = 2, Capacity = 80, MovieId = 2 },
                new Screen { Id = 3, ScreenNumber = 3, Capacity = 150, MovieId = 1 },
                new Screen { Id = 4, ScreenNumber = 4, Capacity = 100 ,MovieId = 3}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Adel Mostafa", Email = "adel@example.com", Phone = "+201234567890" }, 
                new Customer { Id = 2, Name = "Mona Youssef", Email = "mona@example.com", Phone = "+201109876543" }
            );

            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile { Id = 1, Address = "123 Nile Street, Cairo", DateOfBirth = new DateTime(2005, 8, 14) , CustomerId = 1},
                new CustomerProfile { Id = 2, Address = "45 Tahrir Square, Giza", DateOfBirth = new DateTime(1998, 12, 5) , CustomerId = 2}
            );


            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, BookingDate = new DateTime(2025, 10, 1), SeatNumber = 15, Status = "Confirmed", CustomerId = 1, ScreenId = 1 },
                new Booking { Id = 2, BookingDate = new DateTime(2025, 10, 3), SeatNumber = 42, Status = "Pending", CustomerId = 2, ScreenId = 2 },
                new Booking { Id = 3, BookingDate = new DateTime(2025, 10, 5), SeatNumber = 7, Status = "Cancelled", CustomerId = 1, ScreenId = 3 }
            );

            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor { MovieId = 1, ActorId = 1 },
                new MovieActor { MovieId = 2, ActorId = 3 },
                new MovieActor { MovieId = 3, ActorId = 1 },
                new MovieActor { MovieId = 1, ActorId = 2 },
                new MovieActor { MovieId = 3, ActorId = 3 }
            );

            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.ActorId, x.MovieId });
            modelBuilder.Entity<Customer>()
            .HasOne(c => c.customerProfile)
            .WithOne(p => p.customer)
            .HasForeignKey<CustomerProfile>(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
            .HasMany(c => c.bookings)
            .WithOne(p => p.customer)
            .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Actor> actor { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<CustomerProfile> customerProfile { get; set; }
        public DbSet<Movie> movie { get; set; }
        public DbSet<Screen> screen { get; set; }
        public DbSet<MovieActor> movieActor { get; set; }
    }
}
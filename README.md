# 🎬 Cinema Booking System (VisionCine) — .NET Web API

A structured, scalable **Cinema Booking Web API** built with **ASP.NET Core Web API**.  
Designed as the backend for VisionCine’s ticketing platform to allow users to browse movies, view showtimes, inspect cast details, and reserve seats online.

This project follows industry best practices: Dependency Injection (DI), Generic Repository Pattern, Fluent API for EF Core configuration, Data Annotations for validation, and DTOs for safe and efficient client-server data exchange.

---

## 🔎 Mission Summary
Build a modern Cinema Booking System that manages:
- **Movies** (title, description, duration, rating)
- **Screens** / auditoriums (capacity, seat layout)
- **Showtimes** (movie screenings per screen with date/time)
- **Customers** (profiles and contact info)
- **Bookings** (reserve seats for specific showtimes)
- **Actors** (cast details, movie-actor relationships)

Primary goals: maintainable architecture, secure DTO-based API surface, and clear separation between domain models and API contracts.

---

## 🧰 Tech Stack
- **Backend:** ASP.NET Core Web API (.NET 7/8 recommended)  
- **ORM:** Entity Framework Core (Fluent API + Data Annotations)  
- **Database:** MySQL / SQL Server  
- **Patterns:** Dependency Injection, Generic Repository, Unit of Work (optional)  
- **Testing:** xUnit  
- **Tools:** Postman / Swagger for API testing and documentation

---

## 🚀 Features
- Browse movies and view detailed information  
- View showtimes by movie or date  
- Manage customers and bookings  
- Actor–movie relationships (many-to-many)  
- Validation and error handling middleware  
- Repository + Service layer structure  
- DTO mapping and Fluent API configuration  
- Seed data for demo/testing

---

## 📁 Project Structure
/CinemaBooking.Api
/CinemaBooking.Core
/CinemaBooking.Infrastructure
/CinemaBooking.Services
/CinemaBooking.Tests

---

## 🔧 Setup Instructions
```bash
# 1. Clone
git clone https://github.com/senior-3/Adel-Mostafa-Cinema.git
cd Adel-Mostafa-Cinema

# 2. Configure database (in appsettings.json)
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=CinemaDB;User Id=root;Password=your_password;"
}

# 3. Build and run
dotnet restore
dotnet build
dotnet ef database update
dotnet run

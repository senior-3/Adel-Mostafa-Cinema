using Cinema_Booking_System.Data;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Cinema_Booking_System.Repos_Interfaces.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDb>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("connStr"), new MySqlServerVersion(new Version(8, 0, 43))));
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<IActorRepo, ActorRepo>();
builder.Services.AddScoped<IMovieActorRepo, MovieActorRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ICustomerProfileRepo , CustomerProfileRepo>();
builder.Services.AddScoped<IScreenRepo, ScreenRepo>();
builder.Services.AddScoped<IBookingRepo , BookingRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();


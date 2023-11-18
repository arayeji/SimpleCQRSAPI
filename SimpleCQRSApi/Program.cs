using FlightBookingAPI.Data;
using FlightBookingAPI.Repositories;

namespace FlightBookingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddDbContext<DbContextClass>();
            builder.Services.AddScoped<IFlightDetailsRepository, DatabaseFlightDetailsRepository>();
            builder.Services.AddScoped<IAirportsRepository,DatabaseAirportsRepository>();
           // builder.Services.AddScoped<IFlightDetailsRepository, AviationstackFlightRepository>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
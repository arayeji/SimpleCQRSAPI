using FlightBookingAPI.Domain.Models.DataSets;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace FlightBookingAPI.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL( Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<FlightDetails> FlightDetails { get; set; }
        public DbSet<Arrival> Arrivals { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<CodeShared> CodeShareds { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<FlightDetails>(entity =>
           // {
           //     entity.HasOne(A => A.arrival).WithMany(A=>A.FlightDetails).HasForeignKey(fd=>fd.arrivalId).IsRequired(false);
           //     entity.HasOne(F => F.flight).WithMany(A => A.FlightDetails).HasForeignKey(fd => fd.flightId).IsRequired(false);
           //     entity.HasOne(D => D.departure).WithMany(A => A.FlightDetails).HasForeignKey(fd => fd.departureId).IsRequired(false);
           //     entity.HasOne(A => A.airline).WithMany(A => A.FlightDetails).HasForeignKey(fd => fd.airlineId).IsRequired(false);
           // }
           //);

          //  modelBuilder.Entity<Flight>(entity =>
          //  {
          //      entity.HasOne(A => A.codeshared).WithMany(A => A.Flights).HasForeignKey(fd => fd.codesharedId).IsRequired(false);
          //  }
          //);


        }
    }
}

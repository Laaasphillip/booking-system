using BookingSystem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Api.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { Id = 1, Name = "Klippning", Duration = TimeSpan.FromMinutes(30) }, 
                new ServiceType { Id = 2, Name = "Hårfärgning", Duration = TimeSpan.FromMinutes(90) },
                new ServiceType { Id = 3, Name = "Skäggtrimning", Duration = TimeSpan.FromMinutes(15) },
                new ServiceType { Id = 4, Name = "Styling", Duration = TimeSpan.FromMinutes(45) }
                );
        }
    }
}

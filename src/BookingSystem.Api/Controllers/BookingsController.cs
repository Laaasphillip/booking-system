using BookingSystem.Api.Data;
using BookingSystem.Api.Dtos;
using BookingSystem.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingSystemDbContext _context;
        public BookingsController(BookingSystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var result = _context.Bookings.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingRequest request)
        {
            var validName = !string.IsNullOrWhiteSpace(request.CustomerName);
            var validStartTime = DateTime.Now < request.StartTime;
            if (!validName)
            {
                return BadRequest("Du måste angiva ett namn.");
            }

            if (!validStartTime)
            {
                return BadRequest("Detta datumet är inte tillgängligt.");
            }

            var serviceType = _context.ServiceTypes.Find(request.ServiceTypeId);
            if (serviceType == null)
            {
                return BadRequest("Tjänsten du vill ha finns inte");
            }

            var endTime = request.StartTime + serviceType.Duration;

            var booking = new Booking
            {
                ServiceTypeId = request.ServiceTypeId,
                CustomerName = request.CustomerName,
                StartTime = request.StartTime,
                EndTime = endTime
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok(booking);
        }
    }
}

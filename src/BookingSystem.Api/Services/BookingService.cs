using BookingSystem.Api.Data;
using BookingSystem.Api.Models;

namespace BookingSystem.Api.Services
{
    public class BookingService
    {
        private static readonly TimeSpan BufferTime = TimeSpan.FromMinutes(15);
        private readonly BookingSystemDbContext _context;
        

        public BookingService(BookingSystemDbContext context)
        {
            _context = context;
        }

        public bool IsBookingAvailable(DateTime startTime, DateTime endTime)
        {
            var bookings = _context.Bookings.ToList();

            return (IsBookingSlotFree(startTime, endTime, bookings));
        }

        public static bool IsBookingSlotFree(DateTime startTime, DateTime endTime, List<Booking> bookings)
        {
            foreach (var booking in bookings)
            {
                if (booking.EndTime + BufferTime > startTime && booking.StartTime < endTime + BufferTime)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

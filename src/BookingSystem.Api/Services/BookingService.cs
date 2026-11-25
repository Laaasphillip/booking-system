using BookingSystem.Api.Data;

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

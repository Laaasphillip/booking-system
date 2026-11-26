using BookingSystem.Api.Models;
using BookingSystem.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Tests
{
    public class BookingServiceTests
    {

        [Fact]
        public void IsBookingSlotFree_Overlap_ReturnsFalse()
        {
            var existingBooking = new Booking
            {
                StartTime = new DateTime(2026, 11, 27, 14, 0, 0),
                EndTime = new DateTime(2026, 11, 27, 15, 30, 0)
            };

            List<Booking> bookings = new List<Booking> { existingBooking };

            var newStartTime = new DateTime(2026, 11, 27, 15, 0, 0);
            var newEndTime = new DateTime(2026, 11, 27, 15, 30, 0);

            Assert.False(BookingService.IsBookingSlotFree(newStartTime, newEndTime, bookings));
        }

        [Fact]
        public void IsBookingSlotFree_NoOverlap_ReturnsTrue()
        {
            var existingBooking = new Booking
            {
                StartTime = new DateTime(2026, 11, 27, 14, 0, 0),
                EndTime = new DateTime(2026, 11, 27, 15, 30, 0)
            };

            List<Booking> bookings = new List<Booking> { existingBooking };


            var newStartTime = new DateTime(2026, 11, 27, 15, 45, 0);
            var newEndTime = new DateTime(2026, 11, 27, 16, 15, 0);


            Assert.True(BookingService.IsBookingSlotFree(newStartTime, newEndTime, bookings));
        }
    }
}

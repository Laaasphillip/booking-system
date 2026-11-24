namespace BookingSystem.Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

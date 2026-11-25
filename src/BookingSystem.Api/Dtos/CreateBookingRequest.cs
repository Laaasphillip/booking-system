namespace BookingSystem.Api.Dtos
{
    public class CreateBookingRequest
    {
        public int ServiceTypeId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
    }
}

namespace BookingSystem.Api.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
    }
}

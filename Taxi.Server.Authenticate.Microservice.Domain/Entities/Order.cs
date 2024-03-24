
namespace Taxi.Server.Authenticate.Microservice.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public string? ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}

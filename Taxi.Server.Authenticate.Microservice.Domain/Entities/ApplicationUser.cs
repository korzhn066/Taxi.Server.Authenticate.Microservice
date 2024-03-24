using Microsoft.AspNetCore.Identity;

namespace Taxi.Server.Authenticate.Microservice.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = null!;
        public float Rating { get; set; } = 5;
        public int NumberRatingChanges { get; set; } = 1;
        public CandidateDriver? CandidateDriver { get; set; }
    }
}

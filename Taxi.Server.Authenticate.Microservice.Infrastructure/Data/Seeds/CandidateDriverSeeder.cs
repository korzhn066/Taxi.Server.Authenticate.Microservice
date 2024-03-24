using Microsoft.EntityFrameworkCore;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Data.Seeds
{
    internal static class CandidateDriverSeeder
    {
        internal static void SeedCandidateDrivers(this ModelBuilder builder)
        {
            builder.Entity<CandidateDriver>()
                .HasData(
                    new CandidateDriver()
                    {
                        Id = 1,
                        Status = Domain.Enums.CandidateDriverStatus.Process,
                        Message = null,
                        ApplicationUserId = "6e445865-a24d-4543-a6c6-9443d048cdb9"
                    },
                    new CandidateDriver()
                    {
                        Id = 2,
                        Status = Domain.Enums.CandidateDriverStatus.Process,
                        Message = "Вы не отправили фото прав",
                        ApplicationUserId = "7e445865-a24d-4543-a6c6-9443d048cdb9"
                    }
                );
        }
    }
}

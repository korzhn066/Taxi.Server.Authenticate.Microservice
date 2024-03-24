using Microsoft.EntityFrameworkCore;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories.Base;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories
{
    public class CandidateDriverRepository : RepositoryBase<CandidateDriver>, ICandidateDriverRepository
    {
        public CandidateDriverRepository(DBContext context) : base(context)
        {
        }

        public async Task<List<CandidateDriver>> GetCandidateDriverWithPhotosAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            return await Context.CandidateDrivers
                .Include(cd => cd.Photos)
                .Skip(page*count)
                .Take(count)
                .ToListAsync(cancellationToken);
        }
    }
}

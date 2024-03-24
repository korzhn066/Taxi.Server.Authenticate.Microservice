using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories.Base;


namespace Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories
{
    public interface ICandidateDriverRepository : IRepositoryBase<CandidateDriver>
    {
        Task<List<CandidateDriver>> GetCandidateDriverWithPhotosAsync(int page, int count, CancellationToken cancellationToken = default);
    }
}

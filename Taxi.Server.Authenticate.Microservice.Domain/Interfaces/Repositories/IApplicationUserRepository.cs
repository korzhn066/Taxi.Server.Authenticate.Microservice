using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories.Base;

namespace Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories
{
    public interface IApplicationUserRepository : IRepositoryBase<ApplicationUser>
    {
        Task<ApplicationUser?> GetUserWithCandidateDriverByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    }
}

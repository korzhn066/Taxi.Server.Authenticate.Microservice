using Microsoft.EntityFrameworkCore;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories.Base;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(DBContext context) : base(context)
        {
        }

        public async Task<ApplicationUser?> GetUserWithCandidateDriverByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            var user = await Context.Users
                .Include(u => u.CandidateDriver)
                .FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);

            return user;
        }
    }
}

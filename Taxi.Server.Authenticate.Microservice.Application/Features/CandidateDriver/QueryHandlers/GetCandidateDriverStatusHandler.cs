using MediatR;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Queries;
using Taxi.Server.Authenticate.Microservice.Domain.Enums;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.QueryHandlers
{
    internal class GetCandidateDriverStatusHandler : IRequestHandler<GetCandidateDriverStatus, string>
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        public GetCandidateDriverStatusHandler(
            IApplicationUserRepository userRepository,
            UserManager<Domain.Entities.ApplicationUser> userManager) 
        { 
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<string> Handle(GetCandidateDriverStatus request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithCandidateDriverByUserNameAsync(request.UserName, cancellationToken);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Any(r => r.ToUpper() == "Driver".ToUpper()))
                return "Driver";

            if (user.CandidateDriver is null)
                return "Not candidate";

            if (user.CandidateDriver.Status == CandidateDriverStatus.Process)
                return user.CandidateDriver.Message ?? CandidateDriverStatus.Process.ToString();

            if (user.CandidateDriver.Status == CandidateDriverStatus.Denied)
                return CandidateDriverStatus.Denied.ToString();
            
            return CandidateDriverStatus.Accepted.ToString();
        }
    }
}

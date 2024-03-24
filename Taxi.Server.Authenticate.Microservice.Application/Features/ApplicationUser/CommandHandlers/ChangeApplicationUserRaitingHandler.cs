using MediatR;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Api.Helpers;
using Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.Commands;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.CommandHandlers
{
    internal class ChangeApplicationUserRaitingHandler : IRequestHandler<ChangeApplicationUserRaiting>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;
        public ChangeApplicationUserRaitingHandler(
            UserManager<Domain.Entities.ApplicationUser> userManager,
            IApplicationUserRepository applicationUserRepository)
        {
            _userManager = userManager;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task Handle(ChangeApplicationUserRaiting request, CancellationToken cancellationToken)
        {
            var user = await UserManagerHelper.GetApplicationUserByNameAsync(_userManager, request.UserName);

            user.Rating = (user.Rating * user.NumberRatingChanges + request.Raiting) / (user.NumberRatingChanges + 1);
            user.NumberRatingChanges++;

            await _applicationUserRepository.SaveChangesAsync();
        }
    }
}

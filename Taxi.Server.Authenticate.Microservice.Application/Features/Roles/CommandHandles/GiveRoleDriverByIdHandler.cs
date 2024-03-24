using MediatR;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Api.Helpers;
using Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands;

namespace Taxi.Server.Authenticate.Microservice.Authenticate.Microservice.Application.Features.Roles.CommandHandles
{
    internal class GiveRoleDriverByIdHandler : IRequestHandler<GiveRoleDriverById, IdentityResult>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public GiveRoleDriverByIdHandler(
            UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(GiveRoleDriverById request, CancellationToken cancellationToken)
        {
            var user = await UserManagerHelper.GetApplicationUserByIdAsync(_userManager, request.Id);

            return await _userManager.AddToRoleAsync(user, "Driver");
        }
    }
}

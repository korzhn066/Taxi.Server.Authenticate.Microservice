using MediatR;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Api.Helpers;
using Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.Roles.CommandHandles
{
    internal class DenyRoleAdminByIdHandler : IRequestHandler<DenyRoleAdminById, IdentityResult>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public DenyRoleAdminByIdHandler(
            UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(DenyRoleAdminById request, CancellationToken cancellationToken)
        {
            var user = await UserManagerHelper.GetApplicationUserByIdAsync(_userManager, request.Id);

            return await _userManager.RemoveFromRoleAsync(user, "Admin");
        }
    }
}

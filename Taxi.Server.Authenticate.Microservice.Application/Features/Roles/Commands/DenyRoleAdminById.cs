using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands
{
    public class DenyRoleAdminById : IRequest<IdentityResult>
    {
        public string Id { get; set; } = null!;
    }
}

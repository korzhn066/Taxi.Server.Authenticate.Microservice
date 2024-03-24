using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands
{
    public class GiveRoleDriverById : IRequest<IdentityResult>
    {
        public string Id { get; set; } = null!;
    }
}

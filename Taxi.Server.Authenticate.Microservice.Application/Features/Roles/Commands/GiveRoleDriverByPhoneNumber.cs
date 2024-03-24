using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands
{
    public class GiveRoleDriverByPhoneNumber : IRequest<IdentityResult>
    {
        public string PhoneNumber { get; set; } = null!;
    }
}

using MediatR;
using Taxi.Server.Authenticate.Microservice.Application.Models;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.Queries
{
    public class GetApplicationUserInformation : IRequest<ApplicationUserInformation>
    {
        public string UserName { get; set; } = null!;
    }
}

using MediatR;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.Commands
{
    public class ChangeApplicationUserPhoneNumber : IRequest
    {
        public string PhoneNumber { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}

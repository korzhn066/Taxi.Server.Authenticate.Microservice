using MediatR;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Api.Helpers;
using Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.Queries;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.QueryHandlers
{
    internal class GetApplicationUserNameHandler : IRequestHandler<GetApplicationUserName, string>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public GetApplicationUserNameHandler(UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(GetApplicationUserName request, CancellationToken cancellationToken)
        {
            return (await UserManagerHelper.GetApplicationUserByNameAsync(_userManager, request.UserName)).Name;
        }
    }
}

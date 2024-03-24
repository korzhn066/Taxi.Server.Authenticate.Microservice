using MediatR;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Api.Helpers;
using Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.Queries;
using Taxi.Server.Authenticate.Microservice.Application.Models;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.QueryHandlers
{
    internal class GetApplicationUserInformationHandler : IRequestHandler<GetApplicationUserInformation, ApplicationUserInformation>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        public GetApplicationUserInformationHandler(UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUserInformation> Handle(GetApplicationUserInformation request, CancellationToken cancellationToken)
        {
            var user = await UserManagerHelper.GetApplicationUserByNameAsync(_userManager, request.UserName);

            return new ApplicationUserInformation()
            {
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Rating = user.Rating
            };
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Domain.Models;

namespace Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Services
{
    public interface IApplicationAuthenticateService
    {
        string CreateJwtToken();
        Task<bool> LoginAsync(ApplicationUserLogin applicationUserLogin);
        Task<IdentityResult> RegisterAsync(ApplicationUserRegister applicationUserRegister);
    }
}

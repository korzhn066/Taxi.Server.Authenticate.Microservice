using Microsoft.AspNetCore.Mvc;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Services;
using Taxi.Server.Authenticate.Microservice.Domain.Models;

namespace Taxi.Server.Authenticate.Microservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IApplicationAuthenticateService _applicationAuthenticateService;

        public AuthenticateController(IApplicationAuthenticateService applicationAuthenticateService)
        {
            _applicationAuthenticateService = applicationAuthenticateService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ApplicationUserRegister applicationUserRegister)
        {
            var result = await _applicationAuthenticateService.RegisterAsync(applicationUserRegister);

            if (result.Succeeded)
            {
                HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", _applicationAuthenticateService.CreateJwtToken(),
                new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(60)
                });

                return Ok();
            }

            return new BadRequestObjectResult(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(ApplicationUserLogin applicationUserLogin)
        {
            var result = await _applicationAuthenticateService.LoginAsync(applicationUserLogin);

            if (result)
            {
                HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", _applicationAuthenticateService.CreateJwtToken(),
                new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(60)
                });

                return Ok();
            }


            return new BadRequestObjectResult(result);
        }
    }
}

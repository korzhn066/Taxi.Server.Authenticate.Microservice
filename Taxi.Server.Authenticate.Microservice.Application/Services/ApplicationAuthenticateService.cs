using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Services;
using Taxi.Server.Authenticate.Microservice.Domain.Models;

namespace Taxi.Server.Authenticate.Microservice.Application.Services
{
    public class ApplicationAuthenticateService : IApplicationAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        
        private ApplicationUser? _user;
        private IList<string>? _roles;

        public ApplicationAuthenticateService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public string CreateJwtToken()
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user!.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var role in _roles!)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> LoginAsync(ApplicationUserLogin applicationUserLogin)
        {
            _user = await _userManager.FindByNameAsync(applicationUserLogin.UserName);

            if (_user is null)
                return false;

            _roles = await _userManager.GetRolesAsync(_user);

            var result = await _userManager.CheckPasswordAsync(_user, applicationUserLogin.Password);

            return result;
        }

        public async Task<IdentityResult> RegisterAsync(ApplicationUserRegister applicationUserRegister)
        {
            _user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = applicationUserRegister.UserName,
                Name = applicationUserRegister.Name,
                PhoneNumber = applicationUserRegister.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(_user, applicationUserRegister.Password);

            if (!result.Succeeded)
                return result;

            _roles = new List<string> { "Client" };
            result = await _userManager.AddToRoleAsync(_user, "Client");

            return result;
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Server.Authenticate.Microservice.Api.Helpers;
using Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Commands;
using Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Queries;
using Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands;

namespace Taxi.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetDriverStatus")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDriverStatus()
        {
            var status = await _mediator.Send(new GetCandidateDriverStatus(){
                UserName = AuthenticateHelper.GetUserName(HttpContext)
            });

            return Ok(status);
        }

        [HttpGet]
        [Route("GetCandidates")]
        public async Task<IActionResult> GetCandidates(int page, int count)
        {
            var candidates = await _mediator.Send(new GetAllCandidates()
            {
                Page = page,
                Count = count
            });

            return Ok(candidates);
        }

        [HttpPost]
        [Route("AddCandidate")]
        public async Task<IActionResult> AddCandidate(IFormFileCollection files)
        {
            await _mediator.Send(new AddCandidateDriver()
            {
                UserName = AuthenticateHelper.GetUserName(HttpContext),
                Files = files
            });

            return NoContent();
        }

        [HttpPost]
        [Route("GiveRoleDriverById")]
        public async Task<IActionResult> GiveRoleDriverById(string id)
        {
            var result = await _mediator.Send(new GiveRoleDriverById()
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("GiveRoleAdminById")]
        public async Task<IActionResult> GiveRoleAdminById(string id)
        {
            var result = await _mediator.Send(new GiveRoleAdminById()
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("DenyRoleDriverById")]
        public async Task<IActionResult> DenyRoleDriverById(string id)
        {
            var result = await _mediator.Send(new DenyRoleDriverById()
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("DenyRoleAdminById")]
        public async Task<IActionResult> DenyRoleAdminById(string id)
        {
            var result = await _mediator.Send(new DenyRoleAdminById()
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("GiveRoleAdminByPhoneNumber")]
        public async Task<IActionResult> GiveRoleAdminByPhoneNumber(string phoneNumber)
        {
            var result = await _mediator.Send(new GiveRoleAdminByPhoneNumber()
            {
                PhoneNumber = phoneNumber
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("GiveRoleDriverByPhoneNumber")]
        public async Task<IActionResult> GiveRoleDriverByPhoneNumber(string phoneNumber)
        {
            var result = await _mediator.Send(new GiveRoleDriverByPhoneNumber()
            {
                PhoneNumber = phoneNumber
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("DenyRoleAdminByPhoneNumber")]
        public async Task<IActionResult> DenyRoleAdminByPhoneNumber(string phoneNumber)
        {
            var result = await _mediator.Send(new DenyRoleAdminByPhoneNumber()
            {
                PhoneNumber = phoneNumber
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("DenyRoleDriverByPhoneNumber")]
        public async Task<IActionResult> DenyRoleDriverByPhoneNumber(string phoneNumber)
        {
            var result = await _mediator.Send(new DenyRoleDriverByPhoneNumber()
            {
                PhoneNumber = phoneNumber
            });

            return Ok(result);
        }
    }
}

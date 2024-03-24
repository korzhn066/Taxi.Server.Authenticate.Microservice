using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Commands
{
    public class AddCandidateDriver : IRequest
    {
        public string UserName { get; set; } = null!;
        public IFormFileCollection Files { get; set; } = null!;
    }
}

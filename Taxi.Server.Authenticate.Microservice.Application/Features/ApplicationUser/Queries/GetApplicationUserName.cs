using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.ApplicationUser.Queries
{
    public class GetApplicationUserName : IRequest<string>
    {
        public string UserName { get; set; } = null!;
    }
}

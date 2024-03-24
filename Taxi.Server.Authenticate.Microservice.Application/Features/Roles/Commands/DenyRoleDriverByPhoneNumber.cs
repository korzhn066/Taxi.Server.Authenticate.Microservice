﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.Roles.Commands
{
    public class DenyRoleDriverByPhoneNumber : IRequest<IdentityResult>
    {
        public string PhoneNumber { get; set; } = null!;
    }
}

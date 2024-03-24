using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Application.Models
{
    public class ApplicationUserInformation
    {
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; } = string.Empty;
        public float Rating { get; set; }
    }
}

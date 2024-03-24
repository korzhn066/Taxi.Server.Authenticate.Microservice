using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Domain.Enums
{
    public enum CandidateDriverStatus
    {
        Process = 0,
        Accepted = 1,
        Denied = 2,
        Unique = 3,
    }
}

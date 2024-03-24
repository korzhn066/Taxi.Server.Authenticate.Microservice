using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Application.Models
{
    public class CandidateDriverInformation
    {
        public string ApplicationUserId { get; set; } = null!;
        public string StatusMessage { get; set; } = string.Empty;
        public List<string> PhotoPathes { get; set; } = new List<string>();
    }
}

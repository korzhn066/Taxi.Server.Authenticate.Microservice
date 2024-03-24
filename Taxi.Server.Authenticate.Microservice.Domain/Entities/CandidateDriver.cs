using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Server.Authenticate.Microservice.Domain.Enums;

namespace Taxi.Server.Authenticate.Microservice.Domain.Entities
{
    public class CandidateDriver
    {
        public int Id { get; set; }
        public CandidateDriverStatus Status { get; set; } = CandidateDriverStatus.Process;
        public string? Message { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public virtual List<Photo>? Photos { get; set; }
    }
}

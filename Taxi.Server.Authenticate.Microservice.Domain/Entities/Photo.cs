using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Domain.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string FilePath { get; set; } = null!;
        public int CandidateDriverId { get; set; }
        public CandidateDriver CandidateDriver { get; set; } = null!;
    }
}

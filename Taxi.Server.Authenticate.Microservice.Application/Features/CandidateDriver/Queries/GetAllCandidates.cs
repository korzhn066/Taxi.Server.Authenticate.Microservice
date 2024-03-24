using MediatR;
using Taxi.Server.Authenticate.Microservice.Application.Models;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Queries
{
    public class GetAllCandidates : IRequest<List<CandidateDriverInformation>>
    {
        public int Page { get; set; }
        public int Count { get; set; }
    }
}

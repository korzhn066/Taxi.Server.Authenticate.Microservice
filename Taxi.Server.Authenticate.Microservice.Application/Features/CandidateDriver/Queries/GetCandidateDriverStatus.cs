using MediatR;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Queries
{
    public class GetCandidateDriverStatus : IRequest<string>
    {
        public string UserName { get; set; } = null!;
    }
}

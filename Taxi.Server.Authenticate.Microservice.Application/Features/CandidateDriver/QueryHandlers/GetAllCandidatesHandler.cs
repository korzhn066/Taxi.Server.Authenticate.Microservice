using MediatR;
using Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Queries;
using Taxi.Server.Authenticate.Microservice.Application.Models;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.QueryHandlers
{
    internal class GetAllCandidatesHandler : IRequestHandler<GetAllCandidates, List<CandidateDriverInformation>>
    {
        private readonly ICandidateDriverRepository _candidateDriverRepository;

        public GetAllCandidatesHandler(ICandidateDriverRepository candidateDriverRepository)
        {
            _candidateDriverRepository = candidateDriverRepository;
        }
        async Task<List<CandidateDriverInformation>> IRequestHandler<GetAllCandidates, List<CandidateDriverInformation>>.Handle(GetAllCandidates request, CancellationToken cancellationToken)
        {
            var candidates = await _candidateDriverRepository
                .GetCandidateDriverWithPhotosAsync(request.Page, request.Count, cancellationToken);

            var candidatesInformation = new List<CandidateDriverInformation>();

            foreach (var candidate in candidates)
            {
                if (candidate.Photos is null)
                    throw new ArgumentNullException(nameof(candidate.Photos));

                var photoPathes = candidate.Photos.Select(p => p.FilePath).ToList();

                candidatesInformation.Add(new CandidateDriverInformation()
                {
                    ApplicationUserId = candidate.ApplicationUserId ?? string.Empty,
                    PhotoPathes = photoPathes,
                    StatusMessage = candidate.Message ?? candidate.Status.ToString()
                });
            }

            return candidatesInformation;
        }
    }
}

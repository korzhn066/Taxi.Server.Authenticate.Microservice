using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.Commands;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;

namespace Taxi.Server.Authenticate.Microservice.Application.Features.CandidateDriver.CommandHandlers
{
    internal class AddCandidateDriverHandler : IRequestHandler<AddCandidateDriver>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPhotoRepository _photoRepository;
        private readonly IApplicationUserRepository _aplicationUserRepository;
        private readonly ICandidateDriverRepository _candidateDriverRepository;
        public AddCandidateDriverHandler(
            UserManager<Domain.Entities.ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment,
            IPhotoRepository photoRepository,
            IApplicationUserRepository applicationUserRepository,
            ICandidateDriverRepository candidateDriverRepository)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _photoRepository = photoRepository;
            _aplicationUserRepository = applicationUserRepository;
            _candidateDriverRepository = candidateDriverRepository;
        }

        public async Task Handle(AddCandidateDriver request, CancellationToken cancellationToken)
        {
            var user = await _aplicationUserRepository
                .GetUserWithCandidateDriverByUserNameAsync(request.UserName, cancellationToken);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var candidateDriver = user.CandidateDriver;

            if (candidateDriver is null)
            {
                candidateDriver = new Domain.Entities.CandidateDriver()
                {
                    ApplicationUser = user
                };

                await _candidateDriverRepository.AddAsync(candidateDriver, cancellationToken);
            }

            foreach (var file in request.Files)
            {
                var fileName = UploadFile(file);

                var photo = new Photo()
                {
                    FilePath = fileName,
                    CandidateDriver = candidateDriver
                };

                await _photoRepository.AddAsync(photo,cancellationToken);
            }

            await _aplicationUserRepository.SaveChangesAsync();
        }

        private string UploadFile(IFormFile file)
        {
            var rootPath = _webHostEnvironment.WebRootPath + "\\Images\\";
            var fileName = Guid.NewGuid().ToString() + file.FileName[file.FileName.LastIndexOf('.')..];

            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(rootPath))
                    {
                        Directory.CreateDirectory(rootPath);
                    }

                    using FileStream fileStream = File.Create(rootPath + fileName);
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return fileName;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                throw new Exception("Upload Files");
            }
        }
    }
}

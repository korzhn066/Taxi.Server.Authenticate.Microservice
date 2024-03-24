using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories.Base;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(DBContext context) : base(context)
        {
        }
    }
}

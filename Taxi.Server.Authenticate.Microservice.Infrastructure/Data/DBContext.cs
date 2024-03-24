using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data.Seeds;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CandidateDriver> CandidateDrivers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DBContext(DbContextOptions options) : base(options) {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedIdentityRoles();
            builder.SeedApplicationUsers();  
            builder.SeedIdentityUserRoles();
            builder.SeedCandidateDrivers();
            builder.SeedPhotos();

            base.OnModelCreating(builder);
        }
    }
}

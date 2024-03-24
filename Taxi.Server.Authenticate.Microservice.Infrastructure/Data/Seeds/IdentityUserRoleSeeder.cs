using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Data.Seeds
{
    internal static class IdentityUserRoleSeeder
    {
        internal static void SeedIdentityUserRoles(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        UserId = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "9e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "2e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "3e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "4e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "0e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "4e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "5e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "0e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "6e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "7e445865-a24d-4543-a6c6-9443d048cdb9",
                        RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    }
                );
        }
    }
}

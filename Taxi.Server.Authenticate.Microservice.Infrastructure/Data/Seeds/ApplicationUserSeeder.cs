using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Data.Seeds
{
    internal static class ApplicationUserSeeder
    {
        internal static void SeedApplicationUsers(this ModelBuilder builder)
        {
            var users = new List<ApplicationUser>() {
                new ApplicationUser()
                {
                    Id = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN".ToUpper(),
                    Name = "admin",
                    PhoneNumber = "+375336481213",
                },
                new ApplicationUser()
                {
                    Id = "2e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "user1",
                    NormalizedUserName = "USER1".ToUpper(),
                    Name = "user1",
                    PhoneNumber = "+375336481213",
                },
                new ApplicationUser()
                {
                    Id = "3e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "user2",
                    NormalizedUserName = "USER2".ToUpper(),
                    Name = "user2",
                    PhoneNumber = "+375336481213",
                },
                new ApplicationUser()
                {
                    Id = "4e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "driver1",
                    NormalizedUserName = "DRIVER1".ToUpper(),
                    Name = "driver1",
                    PhoneNumber = "+375336481213",
                },
                new ApplicationUser()
                {
                    Id = "5e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "driver2",
                    NormalizedUserName = "DRIVER2".ToUpper(),
                    Name = "driver2",
                    PhoneNumber = "+375336481213",
                },
                new ApplicationUser()
                {
                    Id = "6e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "candidate1",
                    NormalizedUserName = "CANDIDATE1".ToUpper(),
                    Name = "candidate1",
                    PhoneNumber = "+375336481213",
                },
                new ApplicationUser()
                {
                    Id = "7e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "candidate2",
                    NormalizedUserName = "CANDIDATE2".ToUpper(),
                    Name = "candidate2",
                    PhoneNumber = "+375336481213",
                },
            };

            var hasher = new PasswordHasher<ApplicationUser>();

            users[0].PasswordHash = hasher.HashPassword(users[0], "admin");
            users[1].PasswordHash = hasher.HashPassword(users[1], "user1");
            users[2].PasswordHash = hasher.HashPassword(users[2], "user2");
            users[3].PasswordHash = hasher.HashPassword(users[3], "driver1");
            users[4].PasswordHash = hasher.HashPassword(users[4], "driver2");
            users[5].PasswordHash = hasher.HashPassword(users[5], "candidate1");
            users[6].PasswordHash = hasher.HashPassword(users[6], "candidate2");

            builder.Entity<ApplicationUser>().HasData(users);
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Nasir Desai",
                    Email = "nasirdesai313@gmail.com",
                    UserName = "nasirdesai313@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Nasir",
                        LastName = "Desai",
                        Street = "Villa 30, Mantri Courtyard",
                        City = "Bangalore",
                        State = "Karanataka",
                        ZipCode = "560109"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");

            }
        }
    }
}
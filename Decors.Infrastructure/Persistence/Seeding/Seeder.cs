using Decors.Domain.Entities;
using Decors.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Seeding
{
    public class Seeder
    {
        public static async Task SeedUsers(UserManager<User> userManager)
        {
            // Create seed users
            var seedUser = new User
            {
                UserName = "Admin",
                Email = "theophilusighalo@gmail.com",
                EmailConfirmed = true
            };
            
            if ((await userManager.FindByNameAsync(seedUser.UserName)) == null)
            {
                var result = await userManager.CreateAsync(seedUser, "P@ssw0rd");
                if (result.Succeeded)
                {
                    var newUser = userManager.FindByNameAsync(seedUser.UserName).Result;
                    await userManager.AddToRolesAsync(newUser, new[] { "Admin" });
                }
            }
        }

        public static async Task SeedUsersFromJson(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await SeedRoles(roleManager);
            var json = File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }
        }

        public static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            var roles = new List<Role>{
                new Role{ Name = RoleTypes.Admin.ToString()},
                new Role{ Name = RoleTypes.Vendor.ToString()},
                new Role{ Name = RoleTypes.Customer.ToString()},
            };

            foreach (var role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role.Name)))
                {
                    await roleManager.CreateAsync(role);
                    /*await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.view"));
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.create"));
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.update"));*/
                }
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserName = "Admin",
                    Email = "theophilusighalo@gmail.com",
                    EmailConfirmed = true
                }
            };
        }
    }
}

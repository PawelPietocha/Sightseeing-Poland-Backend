using System;
using System.Collections.Generic;
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
                    DisplayName = "Remek",
                    Email = "Remeczek@gmail.com",
                    UserName = "RemekRemczuk",
                    VoivodeshipId = 1,
                    Gender = 0,
                    DateOfBirth = new DateTime(1991, 01, 12)
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
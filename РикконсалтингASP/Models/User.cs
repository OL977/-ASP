using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public class User  : IdentityUser
    {
        public string КодДоступа { get; set; }

    }
    public class DataSeed
    {
        public static async Task SeedDataAsync(IdentDb context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                      {
                        new User
                            {
                              КодДоступа = "TestUserFirst",
                              UserName = "TestUserFirst",
                              Email = "testuserfirst@test.com"
                            },
                        new User
                            {
                              КодДоступа = "TestUserSecond",
                              UserName = "TestUserSecond",
                              Email = "testusersecond@test.com"
                             }
                         };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "qazwsX123@");
                }
            }
        }
    }
}

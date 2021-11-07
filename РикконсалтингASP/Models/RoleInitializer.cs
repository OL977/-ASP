using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;

namespace РикконсалтингASP.Models
{
    public class RoleInitializer


    {

        //private readonly IOptions<MyConfig> conf;
        //private static string adminEmail;
        //private static string password;
        //public RoleInitializer(IOptions<MyConfig> _conf)
        //{
        //    var ng = _conf.Value.Mail;
        //    adminEmail = _conf.Value.Mail;
        //    password = _conf.Value.Password;
        //}


        public static  async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            string adminEmail = "os@2trans.by";
            string password = "123456789ASD6135";
            string Emailuser1 = "1389925@gmail.com";
            string passworduser1 = "123456789ASD6135";
            //string adminEmail = conf.Value.Mail;
            //string password = conf.Value.Password;
            string Nm = "Админ";

            if (await roleManager.FindByNameAsync(Nm) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Nm));
            }
            if (await roleManager.FindByNameAsync("Пользователь") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Пользователь"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Nm);
                }
            }
            if (await userManager.FindByNameAsync(Emailuser1) == null)
            {
                User user1 = new User { Email = Emailuser1, UserName = Emailuser1 };
                IdentityResult result = await userManager.CreateAsync(user1, passworduser1);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Пользователь");
                }
            }
        }


    }
}

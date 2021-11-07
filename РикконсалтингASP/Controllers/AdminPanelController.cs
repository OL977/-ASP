using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;


namespace РикконсалтингASP.Controllers
{


    public class AdminPanelController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;

        public AdminPanelController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }



        //[Authorize(Roles ="Админ")]
        public async Task<IActionResult> Panel()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Contains("Админ"))
                {
                    return View();
                }
                return RedirectToAction("ОшибкаАвторизации", "Ошибки");
            }
            return RedirectToAction("ОшибкаАвторизации", "Ошибки");
        }
    }
}

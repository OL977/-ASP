using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;
using РикконсалтингASP.ViewModels.ChangeRoleViewModel;
using Microsoft.AspNetCore.Authorization;

namespace РикконсалтингASP.Controllers
{
    
    public class RolesController : Controller
    {

        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
           _userManager = userManager;
        }

      
        [Authorize(Roles = "Админ")]
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }



        [Authorize(Roles = "Админ")]
        public IActionResult Create() => View();



      
        [Authorize(Roles = "Админ")]
        [HttpPost]
        public async Task<IActionResult> Create(string Name)
         {
            if (!string.IsNullOrEmpty(Name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Start");
                }
                else
                {
                    foreach(var eror in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, eror.Description);
                    }
                }

            }
            return View(Name);


        }

     
        [Authorize(Roles = "Админ")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index", "Start");
           
        }




        [Authorize(Roles = "Админ")]
        public IActionResult UserList() => View(_userManager.Users.ToList());



  
        [Authorize(Roles = "Админ")]
        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var AllRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    AllRoles = AllRoles,
                    UserEmail = user.Email,
                    UserId = user.Id,
                    UserRoles = userRoles

                };
                return View(model);
            }

            return NotFound();
        }



        
        [Authorize(Roles = "Админ")]
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }





    }
}

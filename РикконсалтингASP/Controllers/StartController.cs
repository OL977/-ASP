using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;
using Microsoft.AspNetCore.Authorization;


namespace РикконсалтингASP.Controllers
{
    
    public class StartController : Controller
    {

        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                return RedirectToAction("IndexAuth","Start");
            }
            else
            {
                return View();
            }
            
        }

         public IActionResult Log()
        {
            return View();
        }


       [Authorize]
        public IActionResult IndexAuth()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Controllers
{
    public class ОшибкиController : Controller
    {


        public IActionResult ОшибкаАвторизации()
        {
            ViewBag.Message = "У вас недостаточно прав для доступа к этому ресурсу!";

            return View();
        }
    }
}

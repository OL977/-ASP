using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace РикконсалтингASP.Controllers
{
    [Authorize]
    public class СотрудникиController1 : Controller        
    {

        private DbAll db;
        public СотрудникиController1(DbAll context)
        {
            db = context;
        }

        public async Task<IActionResult> AllSotrudnik1()
        {
            return View(await (from x in db.Сотрудники
                               orderby x.ФИОСборное
                              where x.НазвОрганиз == "ЛемеЛ Лабс"
                              select x).ToListAsync());
        }
    }
}

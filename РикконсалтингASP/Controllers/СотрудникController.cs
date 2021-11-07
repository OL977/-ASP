using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using РикконсалтингASP.Models;
using РикконсалтингASP.ViewModels.DropdownОргСотр;
using РикконсалтингASP.ViewModels.СотрудникLemel;

namespace РикконсалтингASP.Controllers
{
    [Authorize]
    public class СотрудникController : Controller
    {
        private DbAll dbN;
        private DbAll db;
                
        private DbLemel dbLemels;
        private List<Клиенты> ClienRickCol = new List<Клиенты>();
        private List<Сотрудник> SotrRickCol = new List<Сотрудник>();
        private List<CompanyLemel> ClienLemelData = new List<CompanyLemel>();

        private readonly UserManager<User> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public СотрудникController (DbAll context, DbLemel context1, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            
            db = context;
            dbLemels = context1;
            dbN = context;
            _userManager = userManager;
            _httpContextAccessor= httpContextAccessor; /*это для выбора пользователя */

            ClienRickCol =(from x in dbN.Клиент
                          select x).ToList();

            SotrRickCol = (from x in dbN.Сотрудники
                            select x).ToList();



            ClienLemelData = (from x in dbLemels.CompanysLemel          
                              
                              select x).ToList();


           

            _ = ПроверкадвухБазНаИзменение();

        }

        private async Task ПроверкадвухБазНаИзменение()
        {

            //перебираем названия организаций в базе рик и базе лемел
            var Razn = ClienRickCol.Select(x => x.НазвОрг).Except(ClienLemelData.Select(x => x.Название)).ToList();

            if (Razn.Count > 0)
            {
                List<CompanyLemel> ComL = new List<CompanyLemel>();
                //dbLemels.AddRange(Razn);
                //await dbLemels.SaveChangesAsync();
                foreach (var b in Razn)
                {
                    CompanyLemel Cl = new() { Название = b };
                    ComL.Add(Cl);
                }

                await dbLemels.CompanysLemel.AddRangeAsync(ComL);
                await dbLemels.SaveChangesAsync();

            }



            var Sbor = (from x in dbLemels.CompanysLemel
                        join y in dbLemels.СотрудникиLemel on x.Id equals y.CompanyLemelId
                        select new { y, x }).ToList();


            //получение данных текщего пользователя
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = await _userManager.FindByIdAsync(userId);
            var userName = user.UserName;
            /*это для выбора пользователя */




            List<NewUserLemel> LemNew = new List<NewUserLemel>();
            foreach (var b1 in ClienLemelData) /*'перебираем список организаций по названию в базе лемел'*/
            {
                var colSotrOrg = (from x in SotrRickCol
                                  where x.НазвОрганиз == b1.Название
                                  select x).ToList();
                
                if (colSotrOrg.Count > 0)
                {
                    //данные лемелбазы выбираем действующих сотрудников
                    var Colsotrlemel = (from x in Sbor
                                        where x.x.Название == b1.Название
                                        select x.y).ToList();


                    //if (b1.Название == "Юнивест-Групп")
                    //{
                    //    var hj = 0;
                    //}



                    var prom = colSotrOrg.Select(x => x.ФИОСборное).Except(Colsotrlemel.Select(x => x.ФИОСборное)).ToList();
                    
                    if (prom.Count > 0)
                    {
                        
                        foreach (var b in prom)
                        {
                            var UsN = SotrRickCol.Where(x => x.ФИОСборное == b & x.НазвОрганиз == b1.Название).Select(x => x).LastOrDefault();
                            //var usd = _userManager.FindByNameAsync(User.Identity.Name);

                            //CompanyLemel = new CompanyLemel { Название = b1.Название, Id = b1.Id },
                           
                            NewUserLemel newL = new() {
                                ФИОСборное = b,                                
                                IDSotrРик = UsN.КодСотрудники,
                                CompanyLemelId = b1.Id,
                                Пользователь = userName,
                                ДатаИзменения = DateTime.Now,
                                Имя = UsN.Имя,
                                Отчество = UsN.Отчество,
                                Фамилия = UsN.Фамилия,
                                Организация = b1.Название


                            };


                            LemNew.Add(newL);                            
                        }

                       
                    }
                   
                }
                

            }

            if (LemNew.Count > 0)
            {
               dbLemels.СотрудникиLemel.AddRange(LemNew);

               await dbLemels.SaveChangesAsync();
            }


        }
        public JsonResult getEmplbyId(int id)
        {

            //var Nm = name;
            var Nm = (from x in dbLemels.CompanysLemel
                      where x.Id == id
                      select x.Название).FirstOrDefault();

            if (string.IsNullOrEmpty(Nm))
            {
                return Json(null);

            }
           
            List<EmployeDrop> list = new List<EmployeDrop>();
            list = (from x in dbLemels.СотрудникиLemel
                    join y in dbLemels.CompanysLemel on x.CompanyLemelId equals y.Id
                    orderby x.ФИОСборное
                    where y.Название == Nm
                    select new EmployeDrop { ID = x.Id, CompanyDropName = y.Название, Name = x.ФИОСборное }).ToList();

            list.Insert(0, new EmployeDrop { ID = 0, Name = "Выберите сотрудника" });
            return Json(new SelectList(list, "ID", "Name"));
        }
        public async Task<IActionResult> Главная() {

            ViewBag.company =(from x in dbLemels.CompanysLemel
                                     select new CompanyDrop { ID = x.Id, Name = x.Название }).ToList();

             List<CompanyLemel> tyu =await (from x in dbLemels.CompanysLemel
                                       orderby x.Название
                                   select new CompanyLemel { Id = x.Id, Название = x.Название }).ToListAsync();            

            ViewBag.добСотруд = tyu;
            return View();

          
        }
        public ActionResult GetItems(string id)
        {
            return PartialView(db.Сотрудники.Where(c => c.НазвОрганиз == id).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> ДобавитьСотруд()
        {
            ViewBag.company = await (from x in dbLemels.CompanysLemel
                                     select new CompanyDrop { ID = x.Id, Name = x.Название }).ToListAsync();

            //var Model = await(from x in dbLemels.CompanysLemel
            //                       select new CompanyDrop { ID = x.Id, Name = x.Название }).ToListAsync();

            return PartialView("_добавитьСотруд");
        }

        [HttpPost]
        public async Task<IActionResult> AddSotrud(string Фамилия, string Имя, string Отчество, string CompanyDroplist)
        {

            var FIO = (Фамилия + " " + Имя + " " + Отчество).Trim();
            //проверяем есть в базе такой же сотрудник
            //var sotr = await (from x in dbLemels.CompanysLemel
            //                  join y in dbLemels.СотрудникиLemel on x.Id equals y.CompanyLemelId
            //                  where x.Id == int.Parse(CompanyDroplist) && y.ФИОСборное == FIO
            //                  select y).FirstOrDefaultAsync();

            //if (sotr != null)
            //{
            //    string Txt = "Такой сотрудник уже есть в базе!";
            //    return Json(new { name = Txt });
            //}

            //var Org = dbLemels.CompanysLemel.Where(x => x.Id == int.Parse(CompanyDroplist)).Select(x => x.Название).FirstOrDefault();
            ////получение данных текщего пользователя
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //User user = await _userManager.FindByIdAsync(userId);
            //var userName = user.UserName;
            ///*это для выбора пользователя */



            //var IdOrg = dbLemels.CompanysLemel.Where(x => x.Id == int.Parse(CompanyDroplist)).Select(x => x.Id).FirstOrDefault();
            //NewUserLemel newUserLemel = new NewUserLemel
            //{
            //    CompanyLemelId = IdOrg,
            //    ДатаИзменения = DateTime.Now,
            //    Имя = Имя,
            //    Фамилия = Фамилия,
            //    Отчество = Отчество,
            //    ФИОСборное = FIO,
            //    Организация = Org,
            //    Пользователь = userName
            //};
            //await dbLemels.СотрудникиLemel.AddAsync(newUserLemel);
            //await dbLemels.SaveChangesAsync();

            var tst = "Сотрудник добавлен!";
            return Ok(tst);
        }


       
        public JsonResult AjaxMet(string CompanyDroplist, string FIO)
        {
            //string CompanyDroplist, string FIO


            ////проверяем есть в базе такой же сотрудник
            var sotr = (from x in dbLemels.CompanysLemel
                        join y in dbLemels.СотрудникиLemel on x.Id equals y.CompanyLemelId
                        where x.Id == int.Parse(CompanyDroplist) && y.ФИОСборное == FIO
                        select y).FirstOrDefault();



            if (sotr != null)
            {

                string txt = "Yes!";
              
                return Json(txt);

            }
            else
            {
                string txt = "Ok";
                return Json(txt);
            }
        }

        public ContentResult GetCALMdata(string CompanyDroplist, string FIO)
        {
            //проверяем есть в базе такой же сотрудник
            var sotr = (from x in dbLemels.CompanysLemel
                        join y in dbLemels.СотрудникиLemel on x.Id equals y.CompanyLemelId
                        where x.Id == int.Parse(CompanyDroplist) && y.ФИОСборное == FIO
                        select y).FirstOrDefault();

            if (sotr != null)
            {
                
                return Content("Такой сотрудник уже есть в базе!", "application/json");
            }
            else
            {
                return Content("0", "application/json");
            }


        }
        public class GetCALMdataClass
        {
            public int Id { get; set; }
            public string text { get; set; }
        }


    }   
}

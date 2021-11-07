using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;

namespace РикконсалтингASP.ViewModels.СотрудникLemel
{
    
    public class Добавить

        
    {

        [Required(ErrorMessage = "Не указана фамилия")]
        public string Фамилия { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Имя { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public string Отчество { get; set; }
        public string Организация { get; set; }

        [Required]
        public virtual CompanyLemel CompanyDrop { get; set; }
        public List< CompanyLemel> CompanyDropList { get; set; }

        //public Добавить()
        //{
        //    CompanyDropList = new List<CompanyLemel>();
        //}
    }


                      




}

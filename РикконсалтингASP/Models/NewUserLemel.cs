using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public class NewUserLemel
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public string Организация { get; set; }
        public string Пользователь { get; set; }
        public string Роль { get; set; }
        public DateTime ДатаИзменения { get; set; }
        public string ФИОСборное { get; set; }
        public int IDSotrРик { get; set; }
        public int CompanyLemelId { get; set; }      // внешний ключ
        public CompanyLemel CompanyLemel { get; set; }

    }
}

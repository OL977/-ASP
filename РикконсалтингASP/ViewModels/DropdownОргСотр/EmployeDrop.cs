using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.ViewModels.DropdownОргСотр
{
    public class EmployeDrop
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string CompanyDropName { get; set; }
        public virtual CompanyDrop  CompanyDrop { get; set; }
    }
}

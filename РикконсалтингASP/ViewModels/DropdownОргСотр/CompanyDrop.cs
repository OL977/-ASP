using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.ViewModels.DropdownОргСотр
{
    public class CompanyDrop
    {
        public int ID { set; get; }
        public string Name { get; set; }

        public virtual ICollection<EmployeDrop> EmployeDrops { get; set; }
    }
}

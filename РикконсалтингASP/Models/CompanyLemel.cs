using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public class CompanyLemel
    {
        public int Id { get; set; }

        public string Название { get; set; }

        public List<NewUserLemel> UsersLemel { get; set; }
    }
}

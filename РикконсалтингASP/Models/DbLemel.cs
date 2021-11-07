using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public class DbLemel : DbContext
    {
        public DbSet<NewUserLemel> СотрудникиLemel { get; set; }
        public DbSet<CompanyLemel> CompanysLemel { get; set; }

        public DbLemel(DbContextOptions<DbLemel> options)
           : base(options) { }
    }
}

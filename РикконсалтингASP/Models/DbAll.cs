using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public class DbAll : DbContext
    {
        public DbSet<Сотрудник> Сотрудники { get; set; }
        public DbSet<Клиенты> Клиент { get; set; }
        public DbSet<КарточкиСотрудников> КарточкаСотрудника { get; set; }
        public DbAll(DbContextOptions<DbAll> options)
            : base(options) { }


        //protected override void OnModelCreating(ModelBuilder modelBuilder) /*отмена миграции*/
        //{
        //    modelBuilder.Entity<DbAll>()
        //        .ToTable("Клиенты", t => t.ExcludeFromMigrations());
        //}
    }
}

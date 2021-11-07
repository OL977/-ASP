using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.Models
{
    public class IdentDb  : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; }

      
        public IdentDb(DbContextOptions<IdentDb> options)  : base(options)
                  {
            //Database.EnsureCreated();

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder) /*отмена миграции*/
        //{
        //    modelBuilder.Entity<IdentDb>()
        //        .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        //}
    }
}

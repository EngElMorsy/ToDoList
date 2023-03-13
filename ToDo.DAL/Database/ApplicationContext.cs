using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL.Entity;
using ToDo.DAL.Extend;

namespace ToDo.DAL.Database
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        #region Objects 
        public DbSet<TD> ToDo { get; set; }
        #endregion

        #region Connection String 
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server= .; database=ToDoList; integrated security=true");
         }
        #endregion
    }
}

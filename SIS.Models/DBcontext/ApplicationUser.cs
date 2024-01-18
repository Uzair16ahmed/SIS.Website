using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Models.Models
{
    public class ApplicationUser : DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {

        }
        public DbSet<RegisterModel> UserRegistration { get; set; }

        public DbSet<SIS.Models.Models.UserModel> UserModel { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }



    }
}

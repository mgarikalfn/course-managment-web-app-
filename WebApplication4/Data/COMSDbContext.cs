using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class COMSDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public COMSDbContext(DbContextOptions<COMSDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
         public DbSet<Semester> Semester { get; set; }
        public DbSet<Offering> Offering { get; set; }
    }


}

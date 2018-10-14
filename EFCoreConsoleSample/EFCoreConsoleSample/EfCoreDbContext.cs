using EFCoreConsoleSample.Entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EFCoreConsoleSample
{
    public  class EfCoreDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //ConfigurationManager需要引用System.Configuration.dll
            optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreConnectionString"].ConnectionString);
        }

        public DbSet<Student> Student { get; set; }
    }
}

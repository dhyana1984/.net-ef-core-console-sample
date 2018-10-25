using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample
{

    //如果用注入方式创建dbcontext，必须实现IDesignTimeDbContextFactory接口，否则找不到链接字符串
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EfCoreDbContext>
    {
        public EfCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EfCoreDbContext>();

            builder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreConnectionString"].ConnectionString);

            return new EfCoreDbContext(builder.Options);
        }
    }
}

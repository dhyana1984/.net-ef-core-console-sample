using EFCoreConsoleSample.Entity;
using EFCoreConsoleSample.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace EFCoreConsoleSample
{
    public  class EfCoreDbContext :DbContext
    {
        //EFCore需要重写OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //ConfigurationManager需要引用System.Configuration.dll
            optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreConnectionString"].ConnectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //全局约定，设置表明
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Totable("T_" + item.ClrType.Name);
                //全局约定，设置字符串映射数据库最大长度
                foreach (var property in item.GetProperties().Where(t=>t.ClrType==typeof(string)))
                {
                    property.SetMaxLength(50);
                }
            }
        
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                //   entity.HasKey(t => t.Id);
                entity.HasKey(t => t.Guid);
                entity.Property(t => t.Guid);//Guid自动被映射成为uniqueidentifier， 如果加上.HasColomnType(varchar(36)),将被映射成varchar(36)
                entity.Property<DateTime>("CreateTime");//定义CreateTime为狭隘属性
            });
            //自定义序列
            modelBuilder.Entity<Customer>()
                        .Property(t => t.CustomerId)
                        .ForSqlServerUseSequenceHiLo<int>("SqlSequence");

            //modelBuilder.HasSequence<int>("SqlSequence")
            //            .StartsAt(1000).IncrementsBy(2);

            //modelBuilder.Entity<Customer>()
            //            .Property(t => t.CustomerId)
            //            .HasDefaultValueSql("next value for SqlSequence");

            modelBuilder.Entity<Customer>()
                        .Property(t => t.Name).HasColumnType("varchar(10)");


            //集中配置EntityMapping
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
            {
                if(item.GetInterfaces().Any(x =>x.GetTypeInfo().IsGenericType&& x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                {
                 
                        dynamic configurationInstance = Activator.CreateInstance(item);
                        modelBuilder.ApplyConfiguration(configurationInstance);
                  
                }
            }
            //单个配置EntityMapping
            //modelBuilder.ApplyConfiguration(new BlogConfiguration());
            //modelBuilder.ApplyConfiguration(new CourseConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

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
            modelBuilder.Entity<Student>(entity =>
            {
                //entity.ToTable("Students");
                ////   entity.HasKey(t => t.Id);
                //entity.HasKey(t => t.Guid);
                //entity.Property(t => t.Guid);//Guid自动被映射成为uniqueidentifier， 如果加上.HasColomnType(varchar(36)),将被映射成varchar(36)
                //entity.Property(t => t.CreatedTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();

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

            //var typesToRegister = Assembly.GetExecutingAssembly()
            //                              .GetTypes()
            //                              .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //                              .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.ApplyConfiguration<Blog>(configurationInstance);
            //}
            modelBuilder.ApplyConfiguration<Blog>(new BlogConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}

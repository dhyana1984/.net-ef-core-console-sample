using EFCoreConsoleSample.Entity;
using EFCoreConsoleSample.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {

            //using (var context = new EfCoreDbContext())
            //{
            //    context.Database.Migrate(); //迁移后更新数据库
            //                                //context.Database.EnsureDeleted();
            //                                //context.Database.EnsureCreated();

            //    //var student = new Student()
            //    //{
            //    //    Age = 1,
            //    //    Decimal = 1,
            //    //    Double = 1,
            //    //    Int64 = 1,
            //    //    CreatedTime = DateTime.Now,
            //    //    Float=1,
            //    //    Name = "Chris"

            //    //};

            //    //context.Students.Add(student);
            //    //context.SaveChanges();

            //    //student.Name = "Chris1";
            //    //context.SaveChanges();

            //    //var customers = new List<Customer>()
            //    //{
            //    //    new Customer()
            //    //    {
            //    //        Name="Chris"
            //    //    },
            //    //    new Customer()
            //    //    {
            //    //        Name ="Tom"
            //    //    }

            //    //};

            //    //context.Customers.AddRange(customers);
            //    ////context.SaveChanges(); 
            //    //context.Blogs.Add(new Blog("http://www.github.com"));

            //    //context.SaveChanges();
            //    //foreach (var item in context.Blogs)
            //    //{
            //    //    Console.WriteLine(item.URL);
            //    //}

            //    //var course = new Course()
            //    //{
            //    //    Name = "EF Core111",
            //    //    Introduce = "Entity　Framework Core 2.01111"
            //    //};
            //    //context.Entry(course).Property("CreateTime").CurrentValue = DateTime.Now; //写狭隘属性值·
            //    //context.Courses.Add(course);
            //    //context.SaveChanges();

            //    //var courses = context.Courses.SingleOrDefault();
            //    //var createTime = EF.Property<DateTime>(courses.FirstOrDefault(), "CreateTime");// EF.Property<>不能单独使用，本句会报错
            //    //var createTime = context.Entry(courses).Property("CreateTime").CurrentValue; //读狭隘属性·

            //    //var result = context.Courses.OrderBy(t => EF.Property<DateTime>(t, "CreateTime"));//使用狭隘属性
            //    //Console.WriteLine(createTime);

            //    //var oldCourse = context.Courses.Find(1);
            //    //oldCourse.Introduce = "aaa";
            //    //oldCourse.Name = "bbb";

            //    //context.SaveChanges(); //修改时不会影响狭隘属性

            //   //查询元数据
            //    var efType = context.Model.FindEntityType(typeof(Blog).FullName);
            //    //获取Blog表名
            //    var tbName = efType.Relational().TableName;
            //    //获取属性
            //    var properties = efType.GetProperties();
            //    properties.ToList().ForEach(t => Console.WriteLine(t.Name));
            //    //获取列名
            //     properties.ToList().ForEach(t => Console.WriteLine(efType.FindProperty(t.Name).Relational().ColumnName));

            //    //使用封装的获取属性的lambda表达式
            //    Expression<Func<Blog, string>> model = d => d.Name;
            //    var propInfo = PropertyInfoHelper.GetPropertyInfoFromLambda(model);
            //    //获取列名
            //    var columnName = efType.FindProperty(propInfo.Name).Relational().ColumnName;
            //    //获取列类型
            //    var columnType = efType.FindProperty(propInfo.Name).Relational().ColumnType;
            //    Console.WriteLine(columnName + " " + columnType);



            //}

            //利用DI将context注入到容器，new DbContextOptionsBuilder<>()泛型方法可以注册多个不同的dbcontext类型
            var contextOptions = new DbContextOptionsBuilder().UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreConnectionString"].ConnectionString).Options;
            var services = new ServiceCollection().AddSingleton(contextOptions).AddScoped<EfCoreDbContext>();
            _serviceProvider = services.BuildServiceProvider();
            Initialize(_serviceProvider);

            Console.ReadLine();
        }

        private static EfCoreDbContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (EfCoreDbContext)serviceProvider.GetService(typeof(EfCoreDbContext));
            var student = new Student()
            {
                Age = 1,
                Decimal = 1,
                Double = 1,
                Int64 = 1,
                
                Float = 1,
                Name = "Chris"

            };

            context.Students.Add(student);
            context.SaveChanges();

        }


    }
}

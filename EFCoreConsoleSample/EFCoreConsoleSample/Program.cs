using EFCoreConsoleSample.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EfCoreDbContext())
            {
                context.Database.Migrate(); //迁移后更新数据库
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //var student = new Student()
                //{
                //    Age = 1,
                //    Decimal = 1,
                //    Double = 1,
                //    Int64 = 1,
                //    CreatedTime = DateTime.Now,
                //    Float=1,
                //    Name = "Chris"

                //};

                //context.Students.Add(student);
                //context.SaveChanges();

                //student.Name = "Chris1";
                //context.SaveChanges();

                //var customers = new List<Customer>()
                //{
                //    new Customer()
                //    {
                //        Name="Chris"
                //    },
                //    new Customer()
                //    {
                //        Name ="Tom"
                //    }

                //};

                //context.Customers.AddRange(customers);
                ////context.SaveChanges(); 
                //context.Blogs.Add(new Blog("http://www.github.com"));

                //context.SaveChanges();
                //foreach (var item in context.Blogs)
                //{
                //    Console.WriteLine(item.URL);
                //}

                //var course = new Course()
                //{
                //    Name = "EF Core111",
                //    Introduce = "Entity　Framework Core 2.01111"
                //};
                //context.Entry(course).Property("CreateTime").CurrentValue = DateTime.Now; //写狭隘属性值·
                //context.Courses.Add(course);
                //context.SaveChanges();

                //var courses = context.Courses.SingleOrDefault();
                //var createTime = EF.Property<DateTime>(courses.FirstOrDefault(), "CreateTime");// EF.Property<>不能单独使用，本句会报错
                //var createTime = context.Entry(courses).Property("CreateTime").CurrentValue; //读狭隘属性·

                //var result = context.Courses.OrderBy(t => EF.Property<DateTime>(t, "CreateTime"));//使用狭隘属性
                //Console.WriteLine(createTime);

                //var oldCourse = context.Courses.Find(1);
                //oldCourse.Introduce = "aaa";
                //oldCourse.Name = "bbb";

                //context.SaveChanges(); //修改时不会影响狭隘属性

   
            }

            Console.ReadLine();
        }

    }
}

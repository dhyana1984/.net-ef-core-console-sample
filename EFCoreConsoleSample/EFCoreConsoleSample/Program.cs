using EFCoreConsoleSample.Entity;
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
               context.Database.EnsureDeleted();
               context.Database.EnsureCreated();

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
                //context.SaveChanges(); 
                context.Blogs.Add(new Blog("http://www.github.com"));

                context.SaveChanges();
                foreach (var item in context.Blogs)
                {
                    Console.WriteLine(item.URL);
                }
            }


        }

    }
}

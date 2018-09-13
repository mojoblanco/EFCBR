using System;
using System.Linq;
using EFCBR.TestConsole.Models;
using EFCBR.TestConsole.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EFCBR.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<ApplicationDbContext>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddLogging()
                .BuildServiceProvider();


            // New student
            Console.WriteLine("Enter student name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter student age");
            var age = Console.ReadLine();

            var student = new Student { Name = name, Age = int.Parse(age) };


            // Insert student
            var service = serviceProvider.GetService<IStudentRepository>();
            service.Create(student);
            service.SaveChanges();

            // Get count of student
            Console.WriteLine(service.ItemCount());

            Console.ReadLine();
        }
    }
}

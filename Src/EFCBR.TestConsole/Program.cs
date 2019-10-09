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
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddLogging()
                .BuildServiceProvider();


            // New student
            Console.WriteLine("Enter student name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter student age");
            var age = Console.ReadLine();

            var student = new Student { Name = name, Age = int.Parse(age) };

            // Get Services 
            var studentRepo = serviceProvider.GetService<IStudentRepository>();
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();

            // Insert student
            studentRepo.Add(student);
            unitOfWork.Commit();

            // Get count of student
            Console.WriteLine(studentRepo.GetAll().Count());

            Console.ReadLine();
        }
    }
}

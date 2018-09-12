using System;
using Microsoft.Extensions.DependencyInjection;

namespace EFCBR.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            Console.WriteLine("Hello World!");
        }
    }
}

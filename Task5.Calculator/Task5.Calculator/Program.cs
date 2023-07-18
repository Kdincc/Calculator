using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection().RegisterServices().BuildServiceProvider();

            IUserInterface userInterface = services.GetRequiredService<IUserInterface>();
            ICalculatorService calculatorService = services.GetRequiredService<ICalculatorService>();

            Console.WriteLine("Hello this program can calculate math expressions in 2 mods");
            Console.WriteLine("If you want console mod, input math expression (without brackets) or if you want file mode input file path");

            calculatorService.CalculateAndWriteResults(userInterface.Input());

            Console.ReadLine();
        }
    }
}
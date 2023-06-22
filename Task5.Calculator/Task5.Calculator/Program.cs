using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection().RegisterServices().BuildServiceProvider();
            IMenu menu = services.GetRequiredService<IMenu>();

            menu.PrintMenu();
            menu.StartCalculating(menu.GetAnswer());

            Console.WriteLine();
        }
    }
}
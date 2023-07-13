﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
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
            IInputChecker inputChecker = services.GetRequiredService<IInputChecker>();
            ICalculatingResultsWriter resultsWriter = services.GetService<ICalculatingResultsWriter>();
            ICalculator calculator = services.GetService<ICalculator>();

            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");

            Console.WriteLine("Hello this program can calculate math expressions in 2 mods");
            Console.WriteLine("If you want console mod, input math expression (without brackets) or if you want file mode input file path");

            string input = userInterface.Input();

            calculator.Subscribe(resultsWriter);

            if (inputChecker.IsFilePathExists(input))
            {
                calculator.CalculateFromFile(input);
                resultsWriter.WriteResultsToFile(outputPath);
            }
            else
            {
                calculator.CalculateFromConsole(input);
                resultsWriter.WriteResultsToConsole();
            }

            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatingResultsWriter : ICalculatingResultsWriter
    {
        private readonly List<string> results = new List<string>();

        public void OnCompleted()
        {
            Console.WriteLine("Calculating is over !");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.ToString());
        }

        public void OnNext(string value)
        {
            results.Add(value);
        }

        public void WriteResultsToConsole()
        {
            Console.WriteLine(results.FirstOrDefault());
        }

        public void WriteResultsToFile(string path)
        {
            File.WriteAllLines(path, results);
        }
    }
}

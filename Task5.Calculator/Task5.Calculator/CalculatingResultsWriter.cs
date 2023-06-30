using System.Collections.Generic;
using System.IO;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatingResultsWriter : ICalculatingResultsWriter
    {
        private readonly List<string> results = new List<string>();

        public void AddResult(string expression, string result)
        {
            results.Add(expression + " = " + result);
        }

        public void WriteResults(string path)
        {
            File.WriteAllLines(path, results);
        }
    }
}

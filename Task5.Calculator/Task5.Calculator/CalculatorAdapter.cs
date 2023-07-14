using System;
using System.IO;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatorAdapter : ICalculator
    {
        private readonly ICalculator _calculator;
        private readonly ICalculatingResultsWriter _calculatingResultsWriter;
        private readonly string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");

        public CalculatorAdapter(ICalculator calculator, ICalculatingResultsWriter calculatingResultsWriter)
        {
            _calculator = calculator;
            _calculatingResultsWriter = calculatingResultsWriter;
        }
        public double CalculateFromConsole(string expression)
        {
            _calculator.Subscribe(_calculatingResultsWriter);

            var result = _calculator.CalculateFromConsole(expression);

            _calculatingResultsWriter.WriteResultsToConsole();

            return result;
        }

        public void CalculateFromFile(string path)
        {
            _calculator.Subscribe(_calculatingResultsWriter);

            _calculator.CalculateFromFile(path);

            _calculatingResultsWriter.WriteResultsToFile(outputPath);
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            return _calculator.Subscribe(observer);
        }
    }
}

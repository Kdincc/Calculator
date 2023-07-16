using System;
using System.IO;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
        private readonly IInputChecker _inputChecker;
        private readonly ICalculator _calculator;
        private readonly ICalculatingResultsWriter _calculatingResultsWriter;

        public CalculatorService(ICalculator calculator, ICalculatingResultsWriter calculatingResultsWriter, IInputChecker inputChecker)
        {
            _inputChecker = inputChecker;
            _calculator = calculator;
            _calculatingResultsWriter = calculatingResultsWriter;
        }

        public void CalculateAndWriteResults(string input)
        {
            _calculator.Subscribe(_calculatingResultsWriter);

            if (_inputChecker.IsFilePathExists(input))
            {
                using (var streamReader = new StreamReader(input))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var expression = streamReader.ReadLine();

                        _calculator.CalculateFromFile(expression);
                    }
                }

                _calculatingResultsWriter.WriteResultsToFile(outputPath);
            }
            else
            {
                _calculator.CalculateFromConsole(input);

                _calculatingResultsWriter.WriteResultsToConsole();
            }
        }
    }
}

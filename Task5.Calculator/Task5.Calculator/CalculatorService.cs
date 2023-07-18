using System;
using System.Collections.Generic;
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
        private Dictionary<Func<string, bool>, Action<string>> modes;

        public CalculatorService(ICalculator calculator, ICalculatingResultsWriter calculatingResultsWriter, IInputChecker inputChecker)
        {
            _inputChecker = inputChecker;
            _calculator = calculator;
            _calculatingResultsWriter = calculatingResultsWriter;

        }

        private void InitiModes()
        {
            modes = new Dictionary<Func<string, bool>, Action<string>>();
            {
                modes.Add(new Func<string, bool>(_inputChecker.IsFilePathExists), new Action<string>(CalculateAndWriteToFile));
                modes.Add(new Func<string, bool>(_inputChecker.IsMathExpression), new Action<string>(CalculateAndWriteToConsole));
            };
        }

        public void CalculateAndWriteResults(string input)
        {
            _calculator.Subscribe(_calculatingResultsWriter);
            InitiModes();

            foreach (var mode in modes)
            {
                if (mode.Key.Invoke(input))
                {
                    mode.Value.Invoke(input);
                }
            }
            
        }

        private void CalculateAndWriteToConsole(string input) 
        {
            _calculator.CalculateFromConsole(input);

            _calculatingResultsWriter.WriteResultsToConsole();
        }

        private void CalculateAndWriteToFile(string input) 
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
    }
}

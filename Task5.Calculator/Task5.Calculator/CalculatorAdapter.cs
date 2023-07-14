﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatorAdapter : ICalculator
    {
        private readonly ICalculator _calculator;
        private readonly ICalculatingResultsWriter _calculatingResultsWriter;

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

            _calculatingResultsWriter.WriteResultsToConsole();
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            return _calculator.Subscribe(observer);
        }
    }
}

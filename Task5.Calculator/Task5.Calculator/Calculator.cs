using System;
using System.Collections.Generic;
using System.IO;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly List<IObserver<string>> observers = new List<IObserver<string>>();
        private readonly IExpressionChecker _checker;
        private readonly ICalculateProcessor _calculateProcessor;
        public Calculator(ICalculateProcessor calculateProcessor, IExpressionChecker checker)
        {
            _checker = checker;
            _calculateProcessor = calculateProcessor;
        }

        public double CalculateFromConsole(string expression)
        {
            double result = 0;

            if (_checker.IsCorrectConsoleExpression(expression))
            {
                result = _calculateProcessor.ProcessMathExpression(expression);

                NotifyObservers($"{expression} = {result}");

                return result;
            }

            NotifyObservers($"{expression} =  Incorrect expression!");

            return result;
        }

        public void CalculateFromFile(string expression)
        {
            if (_checker.IsCorrectFileExpression(expression))
            {
                var result = _calculateProcessor.ProcessMathExpression(expression);
                NotifyObservers($"{expression} = {result}");
            }
            else
            {
                NotifyObservers($"{expression} = Incorrect expression!");
            }

            NotifyAboutCompleteObservers();
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber<string>(observers, observer);
        }

        private void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(message);
            }
        }

        private void NotifyAboutCompleteObservers()
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
        }
    }
}

using System;

namespace Task5.Calculator.Interfaces
{
    public interface ICalculatorParser
    {
        public Operation ParseSecondPriorityOperation(string expression, IFormatProvider formatProvider);

        public Operation ParseThirdPriorityOperation(string expression, IFormatProvider formatProvider);

        public string ParseFirstPriorityOperation(string expression, IFormatProvider formatProvider);
    }
}

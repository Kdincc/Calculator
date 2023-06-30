using System;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class OperationCalculator : IOperationCalculator
    {
        public double CalculateOperation(Operation operation)
        {
            Operators _operator = operation.Operator;
            double leftOperand = operation.LeftOperand;
            double rightOperand = operation.RightOperand;
            double result = 0;

            switch (_operator)
            {
                case Operators.Minus:
                    result = leftOperand - rightOperand;
                    break;
                case Operators.Plus:
                    result = leftOperand + rightOperand;
                    break;
                case Operators.Multiplication:
                    result = leftOperand * rightOperand;
                    break;
                case Operators.Division:
                    result = leftOperand / rightOperand;
                    break;
            }

            return Math.Round(result, 4);
        }
    }
}

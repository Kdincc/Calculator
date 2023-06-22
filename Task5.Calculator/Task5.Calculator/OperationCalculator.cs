using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    result = Math.Round(leftOperand / rightOperand, 3);
                    break;
            }

            return result;
        }
    }
}

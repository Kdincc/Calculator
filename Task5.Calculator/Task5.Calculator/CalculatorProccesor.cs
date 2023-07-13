using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatorProccesor : ICalculateProcessor
    {
        private readonly Dictionary<char, int> priority = new Dictionary<char, int>
        {
            { (char)Operators.Plus, 1 },
            { (char)Operators.Minus, 1 },
            { (char)Operators.Multiplication, 2 },
            { (char)Operators.Division, 2 },
            { (char)Operators.LeftBracket, 0 },
            { (char)Operators.RightBracket, 0 },
            { (char)Operators.UnaryMinus, 3 },
        };
        private readonly Stack<double> numbers = new Stack<double>();
        private readonly Stack<char> operators = new Stack<char>();

        public double ProcessMathExpression(string expression)
        {
            StringBuilder number = new StringBuilder();
            bool isPreviousSymbolOperator = false;

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == (char)Operators.Minus && (i == 0 || isPreviousSymbolOperator))
                {
                    ch = (char)Operators.UnaryMinus;
                }

                if (char.IsDigit(ch) || ch == '.')
                {
                    isPreviousSymbolOperator = false;
                    number.Append(ch);

                    if (i == expression.Length - 1)
                    {
                        TryAddNumber(number);
                    }
                }
                else
                {
                    isPreviousSymbolOperator = true;
                    TryAddNumber(number);

                    if (IsOperator(ch))
                    {
                        if (!operators.TryPeek(out char oper) || priority[oper] < priority[ch])
                        {
                            operators.Push(ch);
                        }
                        else
                        {
                            while (operators.TryPeek(out oper) && priority[oper] >= priority[ch] && (ch != '(') && oper != '(')
                            {
                                if (oper == (char)Operators.UnaryMinus)
                                {

                                    ProcessUnaryMinus();
                                }
                                else
                                {
                                    ProcessOperation();
                                }
                            }

                            if (ch == ')')
                            {
                                operators.Pop();
                            }
                            else
                            {
                                operators.Push(ch);
                            }
                        }
                    }
                }
            }

            while (operators.TryPeek(out char oper))
            {
                if (oper == (char)Operators.UnaryMinus)
                {
                    ProcessUnaryMinus();
                }
                else
                {
                    ProcessOperation();
                }
            }

            return numbers.Pop();
        }

        private void ProcessUnaryMinus()
        {
            numbers.Push(-numbers.Pop());
            operators.Pop();
        }

        private void ProcessOperation()
        {
            var rightOperand = numbers.Pop();
            var oper = operators.Pop();
            var leftOperand = numbers.Pop();
            var result = PerformOperation(leftOperand, oper, rightOperand);

            numbers.Push(result);
        }

        private void TryAddNumber(StringBuilder number)
        {
            if (double.TryParse(number.ToString(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double result))
            {
                numbers.Push(result);
                number.Clear();
            }
        }

        public static double PerformOperation(double leftOperand, char operation, double rightOperand)
        {
            double result = 0;

            return operation switch
            {
                (char)Operators.Plus => leftOperand + rightOperand,
                (char)Operators.Minus => leftOperand - rightOperand,
                (char)Operators.Multiplication => leftOperand * rightOperand,
                (char)Operators.Division => Math.Round(leftOperand / rightOperand, 3),
                _ => result
            };
        }

        public bool IsOperator(char ch)
        {
            if (priority.ContainsKey(ch))
            {
                return true;
            }

            return false;
        }

    }
}

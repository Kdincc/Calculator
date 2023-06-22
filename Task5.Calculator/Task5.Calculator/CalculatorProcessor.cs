using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Task5.Calculator.Interfaces;
using System;
using System.Globalization;

namespace Task5.Calculator
{
    public class CalculatorProcessor : ICalculateProcessor
    {
        private readonly ICalculatorParser _parser;
        private readonly IExpressionChecker _expressionChecker;
        private readonly IOperationCalculator _operationCalculator;

        public CalculatorProcessor(ICalculatorParser parser, IExpressionChecker expressionChecker, IOperationCalculator operationCalculator)
        {
            _parser = parser;
            _expressionChecker = expressionChecker;
            _operationCalculator = operationCalculator;
        }

        public string ProcessFirstPriorityOperations(string expression, IFormatProvider formatProvider)
        {
            StringBuilder stringBuilder = new StringBuilder(expression);
            string bracketExpression = _parser.ParseFirstPriorityOperation(expression, formatProvider);
            string processedBracketExpression = bracketExpression;

            if (string.IsNullOrEmpty(bracketExpression)) 
            {
                return expression;
            }

            if (CheckOperators(bracketExpression, Operators.Division, Operators.Multiplication)) 
            {
                processedBracketExpression = ProcessSecondPriorityOperations(bracketExpression, formatProvider);
            }

            processedBracketExpression = ProcessThirdPriorityOperations(processedBracketExpression, formatProvider);

            stringBuilder.Replace(bracketExpression, processedBracketExpression.Trim (new char[] { (char)Operators.LeftBracket, (char)Operators.RightBracket }));

            string processedExample = stringBuilder.ToString();

            if (CheckOperators(processedExample, Operators.LeftBracket, Operators.RightBracket))
            { 
                return ProcessFirstPriorityOperations(processedExample, formatProvider);
            }

            return processedExample;
        }

        public string ProcessSecondPriorityOperations(string expression, IFormatProvider formatProvider)
        {
            Operation operation = _parser.ParseSecondPriorityOperation(expression, formatProvider);

            if (IsEmptyOperation(operation))
            {
                return expression;
            }

            if (_expressionChecker.IsContainsZeroDivide(operation.ToString())) 
            {
                return "Divide by zero! " + operation.ToString();
            }

            string processedExpression = ProcessOperation(operation, expression, formatProvider);

            if (CheckOperators(processedExpression, Operators.Division, Operators.Multiplication))
            {
                return ProcessSecondPriorityOperations(processedExpression, formatProvider);
            }

            return processedExpression;
        }

        public string ProcessThirdPriorityOperations(string expression, IFormatProvider formatProvider)
        {
            Operation operation = _parser.ParseThirdPriorityOperation(expression, formatProvider);

            if (IsEmptyOperation(operation))
            {
                return expression;
            }

            string processedExample = ProcessOperation(operation, expression, formatProvider);

            if (CheckOperators(processedExample, Operators.Plus, Operators.Minus))
            {
                return ProcessThirdPriorityOperations(processedExample, formatProvider);
            }

            return processedExample;
        }

        private string ProcessOperation(Operation operation, string expression, IFormatProvider formatProvider)
        {
            StringBuilder stringBuilder = new StringBuilder(expression);
            double result;
            string strOperation = operation.ToString();
            int index = expression.IndexOf(strOperation);

            result = _operationCalculator.CalculateOperation(operation);

            stringBuilder.Remove(index, strOperation.Length);
            stringBuilder.Insert(index, result.ToString(formatProvider));

            return stringBuilder.ToString();
        }

        private bool CheckOperators(string processedExpression, Operators firstOperator, Operators secondOperator)
        {
            if (processedExpression.Any(x => x == (char)firstOperator || x == (char)secondOperator))
            {
                return true;
            }

            return false;
        }

        private bool IsEmptyOperation(Operation operation)
        {
            if (operation.Operator == Operators.None) 
            {
                return true;
            }

            return false;
        }
    }
}
using System;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class Menu : IMenu
    {
        private readonly IInputChecker _inputChecker;
        private readonly ICalculator _calculator;
        private readonly IUserInterface _userInterface;
        public Menu(IInputChecker inputChecker, ICalculator calculator, IUserInterface userInterface)
        {
            _inputChecker = inputChecker;
            _calculator = calculator;
            _userInterface = userInterface;
        }

        public int GetAnswer()
        {
            string answer = _userInterface.ChooseMenuVariant();

            if (!_inputChecker.IsCorrectMenuAnswer(answer))
            {
                EndProgram("Invalid answer!");
            }

            Console.Clear();
            return Convert.ToInt32(answer);
        }

        public void PrintMenu()
        {
            Console.WriteLine("Hello this program can calculate math expressions, please input number of variant do you need");
            Console.WriteLine("1.Calculate from input");
            Console.WriteLine("2.Calculate from file path");
            Console.WriteLine("3.EXIT");
        }

        public void StartCalculating(int answer)
        {
            if (answer == 1)
            {
                Console.Write("Input math expression: ");
                var expression = _userInterface.InputExpression();
                var result = _calculator.CalculateFromConsole(expression);
                Console.WriteLine(expression + " = " + result);
                return;
            }

            if (answer == 2)
            {
                Console.Write("Input file path with math expressions to calculate: ");
                var path = _userInterface.InputFilePath();

                if (_inputChecker.IsFilePathExists(path))
                {
                    _calculator.CalculateFromFile(path);
                    Console.WriteLine("Check the ouput file in programm directory for answers");
                    return;
                }
            }

            EndProgram("Invalid input!");
        }

        private void EndProgram(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(0);
        }
    }
}

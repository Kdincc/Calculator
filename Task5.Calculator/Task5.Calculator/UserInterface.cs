using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class UserInterface : IUserInterface
    {
        public string ChooseMenuVariant()
        {
            string input = Console.ReadLine();

            return input;
        }

        public string InputExpression()
        {
            string expression = Console.ReadLine();

            return expression;
        }

        public string InputFilePath()
        {
            string path = Console.ReadLine();

            return path;
        }
    }
}

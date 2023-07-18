using System;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class UserInterface : IUserInterface
    {
        public string Input()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}

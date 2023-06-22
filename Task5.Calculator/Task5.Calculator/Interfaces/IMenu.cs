using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.Interfaces
{
    public interface IMenu
    {
        public void PrintMenu();

        public void StartCalculating(int answer);

        public int GetAnswer();
    }
}

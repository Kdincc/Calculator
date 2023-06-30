namespace Task5.Calculator.Interfaces
{
    public interface IMenu
    {
        public void PrintMenu();

        public void StartCalculating(int answer);

        public int GetAnswer();
    }
}

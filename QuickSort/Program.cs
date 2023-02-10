using Common.ConsoleIO;
using QuickSort.Commands;

namespace MatrixProblem
{
    public static class Program
    {
        private static MainManager? mainManager;
        static void Main(string[] args)
        {
            ConsoleSettings.SetConsoleParam();
            mainManager = new MainManager();
            mainManager.Run();
            Console.ReadKey(true);
        }
    }
}
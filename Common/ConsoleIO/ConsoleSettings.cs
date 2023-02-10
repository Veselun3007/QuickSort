using System.Text;

namespace Common.ConsoleIO
{
    public static class ConsoleSettings
    {
        public static void SetConsoleParam()
        {
            Console.Clear();          
            Console.Title = "QuickSort";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;        
        }
    }
}

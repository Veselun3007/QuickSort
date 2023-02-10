namespace Common.ConsoleIO
{
    public class Entering
    {
        public static int EnterInt32(string prompt, object? arg0)
        {
            string? str;
            while (true)
            {
                Console.Write(prompt, arg0);
                str = Console.ReadLine();
                int value;
                try
                {
                    value = Convert.ToInt32(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\t" + "A non-integer number was entered ",
                        Console.ForegroundColor = ConsoleColor.DarkRed);
                    Console.ResetColor();
                    continue;
                }
                return value;
            }
        }
        public static int EnterInt32(string prompt, int min, object? arg0,
            int max = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    int value = EnterInt32(prompt, arg0);
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tThe value should be " +
                    "between {0} and {1}", min, max,
                    Console.ForegroundColor = ConsoleColor.DarkRed);
                    Console.ResetColor();
                }
            }
        }
    }
}

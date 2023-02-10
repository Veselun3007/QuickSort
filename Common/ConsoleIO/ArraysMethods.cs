namespace Common.ConsoleIO
{
    public static class ArraysMethods
    {
        public static int[] GenerateArray(Random random, int n)
        {
            int[] arr = new int[random.Next(n, n)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 30);
            }
            return arr;
        }

        public static void OutResult(int[] arr)
        {
            Console.WriteLine("");
            Console.Write($"| " +
                    $"{string.Join(" | ", arr)}" + " | ");
            Console.WriteLine("");
        }
    }
}

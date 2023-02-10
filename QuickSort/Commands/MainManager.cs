using Common.ConsoleIO;
using QuickSort.AlgorithmsQS;

namespace QuickSort.Commands
{
    class MainManager : CommandManager
    {
        public MainManager() { }
        readonly Random _random = new();

        protected override void IniCommandInfoArray()
        {
            commandInfoArray = new CommandInfo[]
            {
                new CommandInfo("Exit", command: null),
                new CommandInfo("Direct quick sort", DQuickSort),
                new CommandInfo("Parallel(Thread) quick sort", TQuickSort),
                new CommandInfo("Parallel(Parallel) quick sort", PQuickSort),
                new CommandInfo("Parallel(Task) quick sort", TkQuickSort),
            };
        }
        private void DQuickSort()
        {
            int[] arr = GenerateTestArray();
            Console.WriteLine("\nGenerated array:");
            ArraysMethods.OutResult(arr);
            DirectQuickSort<int>.QuickSort(arr);
            Console.WriteLine("\nSorted array:");
            ArraysMethods.OutResult(arr);
            Console.ReadKey(true);
        }

        private void TQuickSort()
        {
            int[] arr = GenerateTestArray();
            Console.WriteLine("\nGenerated array:");
            ArraysMethods.OutResult(arr);
            ThreadQuickSort<int>.QuickSort(arr);
            Console.WriteLine("\nSorted array:");
            ArraysMethods.OutResult(arr);
            Console.ReadKey(true);
        }
        private void PQuickSort()
        {
            int[] arr = GenerateTestArray();
            Console.WriteLine("\nGenerated array:");
            ArraysMethods.OutResult(arr);
            ParallelQuickSort<int>.QuickSort(arr);
            Console.WriteLine("\nSorted array:");
            ArraysMethods.OutResult(arr);           
            Console.ReadKey(true);
        }
        private void TkQuickSort()
        {
            int[] arr = GenerateTestArray();
            Console.WriteLine("\nGenerated array:");
            ArraysMethods.OutResult(arr);
            TaskQuickSort<int>.QuickSort(arr);
            Console.WriteLine("\nSorted array:");
            ArraysMethods.OutResult(arr);
            Console.ReadKey(true);
        }

        private int[] GenerateTestArray()
        {
            int n = Entering.EnterInt32("\n\tEnter the number of elements in the array: ", null);
            int[] arr = ArraysMethods.GenerateArray(_random, n);
            return arr;
        }

        protected override void PrepareScreen()
        {
            Console.Clear();
        }
    }
}

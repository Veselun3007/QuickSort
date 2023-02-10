using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common.ConsoleIO;

namespace BenchmarkForQuickSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class Benchmark : IComparable
    {
        Random _random = new();
        private readonly object _locker = new();
        private int _numThreads = 0;
        private readonly int _maxThreads = Environment.ProcessorCount;
        int _maxDepth = Environment.ProcessorCount;
        int[] arr { get; set; }

        public Benchmark()
        {
            arr = ArraysMethods.GenerateArray(_random, 100000);
        }


        [Benchmark]
        public async Task TaskQuickSort()
        {
            await TaskQuickSort(arr, 0, arr.Length - 1);
        }
        public async Task TaskQuickSort(int[] arr, int left, int right)
        {
            if (right <= left) return;
            int lt = left;
            int gt = right;
            Partition(arr, left, ref lt, ref gt);
            var task1 = Task.Run(() => TaskQuickSort(arr, left, lt - 1));
            var task2 = Task.Run(() => TaskQuickSort(arr, gt + 1, right));
            await Task.WhenAll(task1, task2).ConfigureAwait(false);
        }

        [Benchmark]
        public void DirectQuickSort()
        {
            DirectQuickSort(arr, 0, arr.Length - 1);
        }
        public void DirectQuickSort(int[] arr, int left, int right)
        {
            if (right <= left) return;
            int lt = left;
            int gt = right;
            Partition(arr, left, ref lt, ref gt);
            DirectQuickSort(arr, left, lt - 1);
            DirectQuickSort(arr, gt + 1, right);
        }

        [Benchmark]
        public void ThreadQuickSort()
        {
            ThreadQuickSort(arr, 0, arr.Length - 1);
        }
        public void ThreadQuickSort(int[] arr, int left, int right)
        {
            int _maxThreads = (int)Math.Log((double)arr.Length, 2);
            if (right <= left) return;
            int lt = left;
            int gt = right;
            Partition(arr, left, ref lt, ref gt);
            if (_numThreads < _maxThreads)
            {
                lock (_locker)
                {
                    _numThreads++;
                }
                var _myThread = new Thread(() => ThreadQuickSort());
                _myThread.Start();
            }
            else
            {
                ThreadQuickSort(arr, left, lt - 1);
            }
            ThreadQuickSort(arr, gt + 1, right);
        }

        [Benchmark]
        public void ParallelQuickSort()
        {
            ParallelQuickSort(arr, 0, arr.Length - 1);
        }
        public void ParallelQuickSort(int[] arr, int left, int right)
        {
            if (right <= left) return;
            int lt = left;
            int gt = right;
            Partition(arr, left, ref lt, ref gt);

            if (_maxDepth < 1)
            {
                ParallelQuickSort(arr, left, lt - 1);
                ParallelQuickSort(arr, gt + 1, right);
            }
            else
            {
                --_maxDepth;
                Parallel.Invoke(
                () => ParallelQuickSort(arr, left, lt - 1),
                () => ParallelQuickSort(arr, gt + 1, right));
            }
        }
        public static void Partition(int[] arr, int left, ref int lt, ref int gt)
        {
            var pivot = arr[left];
            int i = left + 1;
            while (i <= gt)
            {
                int cmp = arr[i].CompareTo(pivot);
                if (cmp < 0)
                    Swap(arr, lt++, i++);
                else if (cmp > 0)
                    Swap(arr, i, gt--);
                else
                    i++;
            }
        }
        public static void Swap(int[] arr, int i, int j)
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        [Benchmark]
        public void UsingArraySort()
        {
            Array.Sort(arr);
        }
    }
}
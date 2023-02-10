using QuickSort.Helpers;
namespace QuickSort.AlgorithmsQS
{
    public static class ThreadQuickSort<T> where T : IComparable<T>, new()
    {
        private static readonly object _locker = new();
        private static int _numThreads = 0;      
        public static void QuickSort(T[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        private static void QuickSort(T[] arr, int left, int right)
        {
            int _maxThreads = (int)Math
                .Log((double)arr.Length, 2);
            if (right <= left) return;
            int lt = left;
            int gt = right;
            SortingHelpers<T>.Partition(arr, left, ref lt, ref gt);
            if (_numThreads < _maxThreads)
            {
                lock (_locker)
                {
                    _numThreads++;
                }
                var _myThread = new Thread(() 
                    => QuickSort(arr));
                _myThread.Start();
            }
            else
            {
                QuickSort(arr, left, lt - 1);
            }
            QuickSort(arr, gt + 1, right);
        }
    }
}

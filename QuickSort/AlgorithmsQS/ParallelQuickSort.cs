using QuickSort.Helpers;

namespace QuickSort.AlgorithmsQS
{
    public static class ParallelQuickSort<T> where T : 
        IComparable<T>
    {
        static int maxDepth = Environment.ProcessorCount;
        public static void QuickSort(T[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        private static void QuickSort(T[] arr, int left, int right)
        {
            if (right <= left)
            {
                return;
            }
            int lt = left;
            int gt = right;
            SortingHelpers<T>.Partition(arr, left, ref lt, ref gt);
            if (maxDepth < 1)
            {
                QuickSort(arr, left, lt - 1);
                QuickSort(arr, gt + 1, right);
            }
            else
            {
                --maxDepth;
                CallParallelInvoke(arr, left, right, lt, gt);
            }
        }
        private static void CallParallelInvoke(T[] arr, int left, int right, int lt, int gt)
        {
            Parallel.Invoke(
                () => QuickSort(arr, left, lt - 1),
                () => QuickSort(arr, gt + 1, right));
        }
    }
}

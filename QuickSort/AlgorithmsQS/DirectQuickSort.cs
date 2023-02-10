using QuickSort.Helpers;

namespace QuickSort.AlgorithmsQS
{
    public class DirectQuickSort<T> where T : IComparable<T>, new()
    {
        public static void QuickSort(T[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        private static void QuickSort(T[] arr, int left, int right)
        {
            if (right <= left) return;
            int lt = left;
            int gt = right;
            SortingHelpers<T>.Partition(arr, left, ref lt, ref gt);
            QuickSort(arr, left, lt - 1);
            QuickSort(arr, gt + 1, right);
        }
    }
}

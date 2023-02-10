using QuickSort.Helpers;

namespace QuickSort.AlgorithmsQS
{
    public static class TaskQuickSort<T> where T : IComparable<T>, new()
    {
        public static async Task QuickSort(T[] arr)
        {
            await QuickSort(arr, 0, arr.Length - 1);
        }
        private static async Task QuickSort(T[] arr, int left, int right)
        {
            if (right <= left)
            {
                return;
            }
            int lt = left;
            int gt = right;
            SortingHelpers<T>.Partition(arr, left, ref lt, ref gt);
            var task1 = Task.Run(() => 
                QuickSort(arr, left, lt - 1));
            var task2 = Task.Run(() => 
                QuickSort(arr, gt + 1, right));
            await Task.WhenAll(task1, task2)
                .ConfigureAwait(false);
        }
    }
}


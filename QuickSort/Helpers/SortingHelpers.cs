namespace QuickSort.Helpers
{
    public static class SortingHelpers<T> where T : IComparable<T>
    {
        public static void Partition(T[] arr, int left, 
            ref int lt, ref int gt)
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
                else i++;
            }
        }
        private static void Swap(T[] arr, int i, int j)
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
    }
}

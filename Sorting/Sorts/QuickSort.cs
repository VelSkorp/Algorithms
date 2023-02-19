namespace Sorting
{
    public sealed class QuickSort
    {
        public static void Sort(int[] array, SortOrder order)
        {
            QuickSortImpl(array, 0, array.Length - 1, order);
        }

        public static void QuickSortImpl(int[] array, int left, int right, SortOrder order)
        {
            if (left < right)
            {
                int q = Partition(array, left, right, order);
                QuickSortImpl(array, left, q - 1, order);
                QuickSortImpl(array, q + 1, right, order);
            }
        }

        public static int Partition(int[] array, int left, int right, SortOrder order)
        {
            int x = array[right];
            int less = left;

            for (int i = left; i < right; i++)
            {
                if (ConditionUtil.GetCondition(array[i], x, order))
                {
                    SwapUtil.Swap(ref array[i], ref array[less++]);
                }
            }
            SwapUtil.Swap(ref array[less], ref array[right]);
            return less;
        }
    }
}
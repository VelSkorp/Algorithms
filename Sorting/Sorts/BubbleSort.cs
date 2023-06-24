namespace Sorting
{
    public sealed class BubbleSort
    {
        public static void Sort(int[] array, SortOrder order)
        {
            for (var left = 0; left < array.Length; left++) 
            {
                for (var middle = left + 1; middle < array.Length; middle++)
                {
                    if (ConditionUtil.GetCondition(array[left], array[middle], order))
                    {
                        SwapUtil.Swap(ref array[left], ref array[middle]);
                    }
                }
            }
        }
    }
}
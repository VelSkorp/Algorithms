namespace Sorting
{
    public sealed class CocktailSort
    {
        public static void Sort(int[] array, SortOrder order)
        {
            for (var left = 0; left < array.Length; left++) 
            {
                for (var middle = left + 1; middle < array.Length; middle++)
                {
                    for (var right = array.Length - 1; right > left; right--)
                    {
                        if (ConditionUtil.GetCondition(array[left], array[middle], order))
                        {
                            SwapUtil.Swap(ref array[left], ref array[middle]);
                        }
                        if (ConditionUtil.GetCondition(array[middle], array[right], order))
                        {
                            SwapUtil.Swap(ref array[middle], ref array[right]);
                        }
                    }
                }
            }
        }
    }
}
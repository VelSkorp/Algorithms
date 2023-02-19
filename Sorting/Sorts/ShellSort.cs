namespace Sorting
{
    public sealed class ShellSort
    {
        public static void Sort(int[] array, SortOrder order)
        {
            var elementsCount = array.Length;
            for (var gap = elementsCount / 2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < elementsCount; i++)
                {
                    for (var j = i - gap; j >= 0 && ConditionUtil.GetCondition(array[j], array[j + gap], order); j -= gap)
                    {
                        SwapUtil.Swap(ref array[j], ref array[j + gap]);
                    }
                }
            }
        }
    }
}
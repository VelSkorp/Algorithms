namespace Sorting
{
    public sealed class ConditionUtil
    {
        public static bool GetCondition(int element1, int element2, SortOrder order)
        {
            return order.Equals(SortOrder.Ascending) ? element1 > element2 : element1 < element2;
        }
    }
}
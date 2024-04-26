namespace Sorting
{
	public class CocktailSort : ISort
	{
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>
		{
			for (var left = 0; left < array.Count; left++)
			{
				for (var middle = left + 1; middle < array.Count; middle++)
				{
					for (var right = array.Count - 1; right > left; right--)
					{
						if (ConditionUtility.GetCondition(array[left], array[middle], order))
						{
							(array[middle], array[left]) = (array[left], array[middle]);
						}
						if (ConditionUtility.GetCondition(array[middle], array[right], order))
						{
							(array[right], array[middle]) = (array[middle], array[right]);
						}
					}
				}
			}
			return array;
		}
	}
}
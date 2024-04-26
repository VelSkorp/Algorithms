namespace Sorting
{
	public class ShellSort : ISort
	{
		public IList<T> Sort<T>(IList<T> array, SortOrder order)
			where T : IComparable<T>
		{
			var elementsCount = array.Count;
			for (var gap = elementsCount / 2; gap > 0; gap /= 2)
			{
				for (var i = gap; i < elementsCount; i++)
				{
					for (var j = i - gap; j >= 0 && ConditionUtility.GetCondition(array[j], array[j + gap], order); j -= gap)
					{
						(array[j + gap], array[j]) = (array[j], array[j + gap]);
					}
				}
			}
			return array;
		}
	}
}
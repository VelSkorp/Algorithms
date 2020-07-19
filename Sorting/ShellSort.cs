namespace Sorting
{
    public class ShellSort
    {
        public static void Sort(int[] v, int n)
        {
            for (var gap = n / 2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < n; i++)
                {
                    for (var j = i - gap; j >= 0 && v[j] > v[j + gap]; j -= gap)
                    {
                        var temp = v[j];
                        v[j] = v[j + gap];
                        v[j + gap] = temp;
                    }
                }
            }
        }
    }
}
namespace Sorting
{
    public sealed class SwapUtil
    {
        public static void Swap(ref int element1, ref int element2)
        {
            int temp = element1;
            element1 = element2;
            element2 = temp;
        }
    }
}
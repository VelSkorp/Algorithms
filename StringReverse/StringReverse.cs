using System;
using System.Text;

namespace Algorithms
{
    public sealed class StringReverse
    {
        public static void Main()
        {
            var message = "Hello world";

            Console.WriteLine(Reverse(message));
            
            Console.ReadKey();
        }

        public static string Reverse(string message)
        {
            var stringB = new StringBuilder(message);
            int i, j;

            for (i = 0, j = stringB.Length - 1; i < j; i++, j--)
            {
                (stringB[j], stringB[i]) = (stringB[i], stringB[j]);
            }

            return stringB.ToString();
        }
    }
}
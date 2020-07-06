using System;

namespace Algoritms
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var Message = "Hello world";
			int i, j;

			for (i = 0, j = Message.Length - 1; i < j; i++, j--)
			{
				var chrs = Message[i].ToString();

				Message = Message.Remove(i, 1).Insert(i, Message[j].ToString());
				Message = Message.Remove(j, 1).Insert(j, chrs);
			}

			Console.WriteLine(Message);
			Console.ReadKey();
		}
	}
}
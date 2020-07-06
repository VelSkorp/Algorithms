using System;

namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Using a program for an arbitrary graph represented as an adjacency matrix, check for the existence of an Euler path between pairs of vertices
	/// </summary>
	public class EulerPath
	{
		#region Public Properties

		public Stack<int> Path { get; private set; }
		public int[,] Graph { get; set; } 

		#endregion

		#region Constructor

		public EulerPath(int[,] graph)
		{
			Graph = graph;
		}

		#endregion

		#region Public Properties

		public static void Test()
		{
			int[,] graph =
			{
				{ 0, 1, 1, 0, 0, 1, 1, },
				{ 1, 0, 1, 0, 0, 0, 0, },
				{ 1, 1, 0, 1, 1, 0, 0, },
				{ 0, 0, 1, 0, 1, 1, 0, },
				{ 0, 0, 1, 1, 0, 1, 1, },
				{ 1, 0, 0, 1, 1, 0, 0, },
				{ 1, 0, 0, 0, 1, 0, 0, },
			};

			var _this = new EulerPath(graph);

			if (_this.IsEulerPath(out var v1, out var v2))
			{
				graph[v1, v2] = 0;
				graph[v2, v1] = 0;
			}

			if (v1 != -1 & v2 != -1)
			{
				Console.WriteLine($"Only the Euler path from top {v2} to {v1} is possible");

				_this.CreateEulerPath(v1);
				_this.Path.Push(v2);
			}
			else
			{
				Console.WriteLine("Only Euler cycle possible");
				Console.WriteLine("Enter the top");

				var vertex1 = int.Parse(Console.ReadLine());

				_this.CreateEulerPath(vertex1);
			}

			_this.PrintEulerPath();

			Console.ReadLine();
		}

		public void PrintEulerPath()
		{
			while (!Path.IsEmpty)
				Console.WriteLine(Path.Pop() + " ");
		}

		public void CreateEulerPath(int vertex)
		{
			var size = (int)Math.Sqrt(Graph.Length);
			var stack = new Stack<int>();

			Path = new Stack<int>();

			stack.Push(vertex);

			while (!stack.IsEmpty)
			{
				vertex = stack.Peek();

				var i = 0;

				while (i < size) if (Graph[vertex, i] == 0) i++; else break;

				if (i < size)
				{
					var temp = i;

					stack.Push(temp);

					Graph[vertex, temp] = 0;
					Graph[temp, vertex] = 0;
				}
				else
				{
					var x = stack.Pop();

					Path.Push(x);
				}
			}
		}

		public bool IsEulerPath(out int vertex1, out int vertex2)
		{
			var size = (int)Math.Sqrt(Graph.Length);
			var countEdge = 0;
			var edgeOf3 = 0;

			vertex1 = -1;
			vertex2 = -1;

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
					if (Graph[i, j] != 0)
						countEdge++;

				if (countEdge % 2 != 0)
				{
					edgeOf3++;

					if (edgeOf3 == 1) vertex1 = i;

					if (edgeOf3 == 2) vertex2 = i;
				}
				countEdge = 0;
			}

			return edgeOf3 == 2;
		} 

		#endregion
	}
}
using System;

namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Design a program for finding the Hamiltonian path between two user-specified vertices of an arbitrary undirected graph described by its adjacency matrix
	/// </summary>
	public class HamiltonPath
	{
		#region Public Properties

		public int[] Path { get; private set; }
		public int[,] Graph { get; private set; } 

		#endregion

		#region Constructor

		public HamiltonPath(int[,] graph)
		{
			Graph = graph;
		}

		#endregion

		#region Public Methods

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


			Console.WriteLine("введите вершину 1");

			var vertex1 = int.Parse(Console.ReadLine());

			Console.WriteLine("введите вершину 2");

			var vertex2 = int.Parse(Console.ReadLine());
			var _this = new HamiltonPath(graph);

			_this.CreateHamiltonPath(vertex1, vertex2);
			_this.PrintPath();

			Console.ReadLine();
		}

		public void CreateHamiltonPath(int vertex1, int vertex2)
		{
			var size = (int)Math.Sqrt(Graph.Length);

			Path = new int[size];

			Path[0] = vertex1;

			for (var i = 1; i < size; i++)
				Path[i] = -1;

			var vertexMinCountEdge = -1;
			var minCountEdge = int.MaxValue;

			for (var i = 1; i < size; i++)
			{
				for (var k = 0; k < size; k++)
				{
					if (Path[i - 1] == -1) throw new ArgumentException("No way possible");

					if (Graph[Path[i - 1], k] != 0)
						if (CountEdge(k) < minCountEdge & !Array.Exists(Path, element => element == k) & k != vertex2)
						{
							minCountEdge = CountEdge(k);
							vertexMinCountEdge = k;
						}
				}

				Path[i] = vertexMinCountEdge;

				if (CountEdge(vertex2) == 0 & vertexMinCountEdge == -1) Path[i] = vertex2;

				minCountEdge = int.MaxValue;
				vertexMinCountEdge = -1;
			}
		}

		public void PrintPath()
		{
			var size = (int)Math.Sqrt(Graph.Length);

			Console.Write("Hamilton path: ");

			for (var i = 0; i < size; i++)
				Console.Write(Path[i] + " ");
		}

		#endregion

		#region Ptivate Method

		private int CountEdge(int vertex)
		{
			var size = (int)Math.Sqrt(Graph.Length);
			var count = 0;

			for (var i = 0; i < size; i++)
				if (Graph[vertex, i] != 0 & !Array.Exists(Path, element => element == i))
					count++;

			return count;
		} 

		#endregion
	}
}
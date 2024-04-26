using System;

namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Develop a program that determines if there is a path from one vertex to another according to the reachability matrix
	/// </summary>
	public class PathAlongTheReachabilityMatrix
	{
		#region Public Properties

		public int[,] Graph { get; private set; }

		/// <summary>
		/// Reachability matrix
		/// </summary>
		public int[,] Matrix { get; private set; }

		#endregion

		#region Constructor

		public PathAlongTheReachabilityMatrix(int[,] graph)
		{
			Graph = graph;
		}

		#endregion

		#region Public Methods

		public static void Test()
		{
			int[,] graph =
			{
				{0,1,0,0,1,0,0 },
				{0,1,0,1,0,0,0 },
				{0,0,0,1,0,0,0 },
				{0,0,0,0,1,0,0 },
				{0,0,0,0,1,0,0 },
				{0,0,1,0,0,0,1 },
				{0,0,0,1,0,1,0 },
			};

			var _this = new PathAlongTheReachabilityMatrix(graph);

			Console.WriteLine("Test graph");

			_this.PrintGraph();
			_this.CreateMatrixReachability();
			_this.PrintMatrix();

			Console.WriteLine("введите вершину 1");

			var vertex1 = int.Parse(Console.ReadLine());

			Console.WriteLine("введите вершину 2");

			var vertex2 = int.Parse(Console.ReadLine());

			Console.WriteLine();

			if (_this.PathExist(vertex1, vertex2))
				Console.WriteLine($"Path from {vertex1} to {vertex2} exist");
			else
				Console.WriteLine($"Path from {vertex1} to {vertex2} is not exist");

			Console.ReadKey();
		}

		public bool PathExist(int vertex1, int vertex2) => Matrix[vertex1 - 1, vertex2 - 1] == 1;

		public void CreateMatrixReachability()
		{
			var size = (int)Math.Sqrt(Graph.Length);
			var visited = new bool[7];

			Matrix = new int[size, size];

			for (var i = 0; i < size; i++)
				for (var j = 0; j < size; j++)
				{
					Matrix[i, j] = DFS(Graph, i, j, visited) ? 1 : 0;
					visited = new bool[7];
				}
		}

		public void PrintMatrix() => Print(Matrix);

		public void PrintGraph() => Print(Graph); 

		#endregion

		#region Private Methods

		private void Print(int[,] matrix)
		{
			if (matrix == null)
				throw new NullReferenceException();

			var size = (int)Math.Sqrt(matrix.Length);

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
					Console.Write(matrix[i, j] + " ");

				Console.WriteLine();
			}
		} 

		private static bool DFS(int[,] graph, int vertexStart, int vertexEnd, bool[] visited)
		{
			var size = (int)Math.Sqrt(graph.Length);

			visited[vertexStart] = true;

			for (var i = 0; i < size; i++)
			{
				if (graph[vertexStart, i] != 0 & !visited[i])
					if (DFS(graph, i, vertexEnd, visited))
						return true;

				if (vertexStart == vertexEnd)
					return true;
			}

			return false;
		} 

		#endregion
	}
}
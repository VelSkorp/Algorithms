using System;

namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Perform a software implementation of finding the minimum spanning tree using the Prima algorithm.
	/// </summary>
	public class PrimaAlgorithm
	{
		#region Public Propeties

		public int[,] Graph { get; private set; }

		public int[] Tree { get; private set; } = { 0, -1, -1, -1, -1, -1 };

		#endregion

		#region Constructor

		public PrimaAlgorithm(int[,] graph)
		{
			Graph = graph;
		}

		#endregion

		#region Public Methods

		public static void Test()
		{
			int[,] graph =
			{
				{0,6,1,5,0,0 },
				{6,0,5,0,3,0 },
				{1,5,0,5,6,4 },
				{5,0,5,0,0,2 },
				{0,3,6,0,0,6 },
				{0,0,4,2,6,0 },
			};

			var _this = new PrimaAlgorithm(graph);

			Console.WriteLine("Test Graph\n");

			_this.PrintGraph();
			_this.CreateSpanningTree();
			_this.PrintTree();

			Console.ReadKey();
		}

		public void CreateSpanningTree()
		{
			var vertex = 0;
			var counter = 1;
			var size = (int)Math.Sqrt(Graph.Length);

			for (var i = 0; i < size; i++)
			{
				vertex = FindMin(vertex);

				if (!Array.Exists(Tree, element => element == vertex) & vertex != -1)
				{
					Tree[counter] = vertex;
					counter++;
				}
			}
		}

		public void PrintGraph()
		{
			if (Graph == null)
				throw new NullReferenceException("Graph is not setted");

			var size = (int)Math.Sqrt(Graph.Length);

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
					Console.Write(Graph[i, j] + " ");

				Console.WriteLine();
			}
		}

		public void PrintTree()
		{
			if (Tree == null)
				throw new NullReferenceException("Spanning tree is not created");

			var size = (int)Math.Sqrt(Graph.Length);

			Console.Write("\nSpanning tree: ");

			for (var i = 0; i < size; i++)
				Console.Write(Tree[i] + 1 + " ");
		}

		#endregion

		#region Private Methods

		private int FindMin(int vertexStart)
		{
			var size = (int)Math.Sqrt(Graph.Length);
			var min = 255;
			var index = -1;

			if (vertexStart == -1)
			{
				foreach (var item in Tree)
					for (var i = 0; i < size; i++)
						if (item != -1)
							if (Graph[item, i] < min & Graph[item, i] != 0 & !Array.Exists(Tree, element => element == i))
							{
								min = Graph[item, i];
								index = i;
							}
			}
			else for (var i = 0; i < size; i++)
					if (Graph[vertexStart, i] < min & Graph[vertexStart, i] != 0 & !Array.Exists(Tree, element => element == i))
					{
						min = Graph[vertexStart, i];
						index = i;
					}

			return index;
		}

		#endregion	
	}
}
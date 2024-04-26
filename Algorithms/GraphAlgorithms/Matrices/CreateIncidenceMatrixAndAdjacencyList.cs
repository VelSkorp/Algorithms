using System;

namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Write a program that constructs and prints incidence matrices and adjacency lists for graphs using the adjacency matrix.
	/// </summary>
	public class CreateIncidenceMatrixAndAdjacencyList
	{
		#region Public Properties

		public int[,] Graph { get; private set; }
		public int[][] List { get; private set; }
		public string[,] Matrix { get; private set; } 

		#endregion

		#region Constructor

		public CreateIncidenceMatrixAndAdjacencyList(int[,] graph)
		{
			Graph = graph;
		}

		#endregion

		public static void Test()
		{
			#region Test graph 1

			Console.WriteLine("Test graph №1\n");

			int[,] graph1 =
			{
				{ 0,1,1,1 },
				{ 1,0,1,1 },
				{ 1,1,0,1 },
				{ 1,1,1,0 }
			};

			var _this = new CreateIncidenceMatrixAndAdjacencyList(graph1);

			_this.PrintGraph();
			_this.CraeteAdjacencyList();
			_this.PrintList();
			_this.CreateMatrix();
			_this.PrintMatrix();

			#endregion

			#region Test graph 2

			Console.WriteLine("\nTest graph №2\n");

			int[,] graph2 =
			{
				{ 0,1,0,0,0 },
				{ 0,0,0,0,1 },
				{ 1,0,0,0,0 },
				{ 0,0,1,0,0 },
				{ 0,0,0,1,0 }
			};

			_this = new CreateIncidenceMatrixAndAdjacencyList(graph2);

			_this.PrintGraph();
			_this.CraeteAdjacencyList();
			_this.PrintList();
			_this.CreateMatrix();
			_this.PrintMatrix();

			#endregion

			#region Test graph 3

			Console.WriteLine("\nTest graph №3\n");

			int[,] graph3 =
			{
				{ 0,0,1,0,1 },
				{ 0,0,1,1,0 },
				{ 1,1,0,1,1 },
				{ 1,1,0,0,0 },
				{ 0,0,1,0,0 }
			};

			_this = new CreateIncidenceMatrixAndAdjacencyList(graph3);

			_this.PrintGraph();
			_this.CraeteAdjacencyList();
			_this.PrintList();
			_this.CreateMatrix();
			_this.PrintMatrix();

			#endregion

			Console.ReadKey();
		}

		#region Create Methods

		public void CraeteAdjacencyList()
		{
			var size = (int)Math.Sqrt(Graph.Length);

			List = new int[size][];

			for (var i = 0; i < size; i++)
			{
				List[i] = new int[size];

				for (var j = 0; j < size; j++)
					if (Graph[i, j] != 0)
						List[i][j] = j + 1;
			}
		}
		public void CreateMatrix()
		{
			var tableSize = (int)Math.Sqrt(Graph.Length);
			var countEdge = GetCountOfEdge();

			CreateMatrixFrame();

			for (var i = 1; i <= tableSize; i++)
				for (var j = 1; j <= countEdge; j++)
				{
					var v1 = Matrix[0, j][0] - '0';
					var v2 = Matrix[0, j][2] - '0';

					Matrix[i, j] = (v1 != i) && (v2 != i) ? "   0" :
						(Graph[i - 1, v2 - 1] != 1) && (Graph[i - 1, v1 - 1] != 1) ? "  -1" : "   1";
				}
		}

		private void CreateMatrixFrame()
		{
			var countEdge = GetCountOfEdge();
			var tableSize = List.Length;
			var c = 1;

			Matrix = new string[tableSize + 1, countEdge + 1];

			Matrix[0, 0] = " ";

			for (var i = 0; i < tableSize; i++)
			{
				Matrix[i + 1, 0] = (i + 1).ToString();

				foreach (var item in List[i])
					if (item != 0)
						if (IsInMatrix($" {i + 1}-{item}"))
						{
							Matrix[0, c] = $"{i + 1}-{item}";
							c++;
						}
			}
		} 

		#endregion

		#region Helper Methods

		private int GetCountOfEdge()
		{
			var countEdge = 0;
			var size = (int)Math.Sqrt(Graph.Length);
			var temp = (int[,])Graph.Clone();

			for (var i = 0; i < size; i++)
				for (var j = 0; j < size; j++)
					if (temp[i, j] != 0)
					{
						if (temp[i, j] == 1 & temp[j, i] == 1)
							temp[j, i] = 0;

						countEdge++;
					}

			return countEdge;
		}

		private bool IsInMatrix(string item)
		{
			var countEdge = GetCountOfEdge();

			item = item[3] + item[2].ToString() + item[1].ToString();

			for (var i = 1; i <= countEdge; i++)
				if (Matrix[0, i] == item)
					return false;

			return true;
		} 

		#endregion

		#region Output Methods

		private void PrintGraph()
		{
			var size = (int)Math.Sqrt(Graph.Length);

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
				{
					Console.Write($"{Graph[i, j]} ");
				}
				Console.WriteLine();
			}
		}

		public void PrintList()
		{
			if (List == null)
				throw new NullReferenceException("Adjacency list is not created");

			Console.WriteLine("\nAdjacency list:\n");

			for (var i = 0; i < List.Length; i++)
			{
				Console.Write($"({i + 1})");

				for (var j = 0; j < List[i].Length; j++)
					if (List[i][j] != 0)
						Console.Write($"\t{List[i][j]}");

				Console.WriteLine();
			}
		}

		public void PrintMatrix()
		{
			if (List == null)
				throw new NullReferenceException("Incidence matrix is not created");

			Console.WriteLine("\nIncidence matrix:\n");

			var countEdge = GetCountOfEdge();
			var matrixSize = (int)Math.Sqrt(Matrix.Length);

			for (var i = 0; i < matrixSize; i++)
			{
				for (var j = 0; j <= countEdge; j++)
				{
					Matrix[0, j] = Matrix[0, j] + " ";

					Console.Write(Matrix[i, j] + " ");
				}

				Console.WriteLine();
			}
		}

		#endregion
	}
}
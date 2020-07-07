using System;
using System.Collections.Generic;

namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Develop a program that determines the maximum flow in a graph using depth search
	/// </summary>
	public class MaximumFlow
	{
		#region Private Members

		private bool[] mVis;
		private List<int> mVer = new List<int>();
		private int mGeneralMin;

		#endregion

		#region Public Properties

		public string[,] Graph { get; private set; } 

		#endregion

		#region Constructor

		public MaximumFlow(string[,] graph)
		{
			Graph = graph;
		}

		#endregion

		#region Public Methods

		public void Start()
		{
			PrintGraph();

			ChangeAndPrintGraph();

			mVer.Remove(0);
			mVer.Remove(6);
			ChangeAndPrintGraph();

			mVer.Remove(0);
			mVer.Remove(6);
			ChangeAndPrintGraph();

			mVer = new List<int>();
			ChangeAndPrintGraph();

			mVer = new List<int>();
			ChangeAndPrintGraph();

			PrintNetworkFlow();

			PrintSaturatedArcs();
		}

		public static void Test()
		{
			string[,] graph =
			{
				{ "0/0","8/0","0/0","0/0","4/0","7/0","0/0" },
				{ "8/0","0/0","4/0","0/0","0/0","4/0","0/0" },
				{ "0/0","4/0","0/0","0/0","0/0","0/0","7/0" },
				{ "0/0","0/0","0/0","0/0","9/0","0/0","5/0" },
				{ "4/0","0/0","0/0","9/0","0/0","6/0","0/0" },
				{ "7/0","4/0","0/0","0/0","6/0","0/0","9/0" },
				{ "0/0","0/0","7/0","5/0","0/0","9/0","0/0" },
			};

			var _this = new MaximumFlow(graph);

			_this.Start();
		}

		public void PrintNetworkFlow()
		{
			var size = (int)Math.Sqrt(Graph.Length);
			var flow = 0;
			var subStrSource = "";
			var subStrStock = "";

			Console.Write("Network flow equals: ");

			for (var i = 0; i < size; i++)
			{
				if (Graph[0, i][2] != '0')
				{
					flow += GetNumFromChar(Graph[0, i][2]);
					subStrSource += $" + {GetNumFromChar(Graph[0, i][2])}";
				}

				if (Graph[i, size - 1][2] != '0')
					subStrStock += $" + {GetNumFromChar(Graph[i, size - 1][2])}";
			}

			subStrSource = subStrSource.Remove(0, 2);
			subStrStock = subStrStock.Remove(0, 2);

			Console.WriteLine($"{subStrSource} = {subStrStock} = {flow}");
		}

		public void PrintSaturatedArcs()
		{
			var size = (int)Math.Sqrt(Graph.Length);

			Console.Write("Saturated arcs: ");

			for (var i = 0; i < size; i++)
				for (var j = 0; j < size; j++)
					if (GetNumFromChar(Graph[i, j][0]) == GetNumFromChar(Graph[i, j][2]) && Graph[i, j][2] != '0')
						Console.Write($"{i + 1}-{j + 1}, ");
		}

		public void PrintGraph()
		{
			var size = (int)Math.Sqrt(Graph.Length);

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
					Console.Write(Graph[i, j] + " ");

				Console.WriteLine();
			}

			Console.WriteLine();
		}

		#endregion

		#region Helper Methods

		private void ChangeAndPrintGraph()
		{
			var size = (int)Math.Sqrt(Graph.Length);

			mVis = new bool[size];
			mGeneralMin = int.MaxValue;
			DFS(0, size - 1);
			PrintGraph();
		}

		private bool DFS(int vertexStart, int vertexEnd)
		{
			var size = (int)Math.Sqrt(Graph.Length);

			mVis[vertexStart] = true;
			mVer.Add(vertexStart);

			for (var i = 0; i < size; i++)
			{
				if (vertexStart == vertexEnd) return true;

				if (Graph[vertexStart, i][0] == Graph[vertexStart, i][2] || mVis[i] || mVer.Contains(i))
					continue;

				var currentMin = GetNumFromChar(Graph[vertexStart, i][0]) - GetNumFromChar(Graph[vertexStart, i][2]);

				if (currentMin < mGeneralMin)
					mGeneralMin = currentMin;

				if (DFS(i, vertexEnd))
				{
					ReplaceChar(vertexStart, i);
					return true;
				}
			}
			return false;
		}

		private void ReplaceChar(int vertexOne, int vertexTwo)
		{
			var lastValue = GetNumFromChar(Graph[vertexOne, vertexTwo][2]);
			Graph[vertexOne, vertexTwo] = Graph[vertexOne, vertexTwo].Remove(2, 1);
			Graph[vertexOne, vertexTwo] = Graph[vertexOne, vertexTwo].Insert(2, $"{lastValue + mGeneralMin}");
		}

		private int GetNumFromChar(char ch) => int.Parse(ch.ToString()); 

		#endregion
	}
}
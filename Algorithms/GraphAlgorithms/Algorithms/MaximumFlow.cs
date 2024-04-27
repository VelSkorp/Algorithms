namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Develop a program that determines the maximum flow in a graph using depth search
	/// </summary>
	public class MaximumFlow
	{
		#region Private Members

		private bool[] mVis;
		private HashSet<int> mVer = new HashSet<int>();
		private int mGeneralMin;

		#endregion

		#region Public Methods

		/// <summary>
		/// Calculates the maximum flow in the graph and returns information about it.
		/// </summary>
		/// <param name="graph">The graph represented as a 2D array of strings.</param>
		/// <returns>
		/// A tuple containing information about the maximum flow and saturated edges.
		/// </returns>
		public (string, string) FindMaxFlowAndSaturatedEdges(string[,] graph)
		{
			Initialize(graph);

			mVer.Remove(0);
			mVer.Remove(6);
			Initialize(graph);

			mVer.Remove(0);
			mVer.Remove(6);
			Initialize(graph);

			mVer = new HashSet<int>();
			Initialize(graph);

			mVer = new HashSet<int>();
			Initialize(graph);

			return (GetMaxFlow(graph), GetSaturatedEdges(graph));
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Initializes the graph for maximum flow calculation.
		/// </summary>
		/// <param name="graph">The graph represented as a 2D array of strings.</param>
		private void Initialize(string[,] graph)
		{
			var size = (int)Math.Sqrt(graph.Length);

			mVis = new bool[size];
			mGeneralMin = int.MaxValue;
			DFS(graph, 0, size - 1);
		}

		/// <summary>
		/// Depth-First Search (DFS) algorithm to find augmenting paths in the graph.
		/// </summary>
		/// <param name="graph">The graph represented as a 2D array of strings.</param>
		/// <param name="vertexStart">The starting vertex for DFS.</param>
		/// <param name="vertexEnd">The ending vertex for DFS (sink).</param>
		/// <returns>True if an augmenting path is found; otherwise, false.</returns>
		private bool DFS(string[,] graph, int vertexStart, int vertexEnd)
		{
			var size = (int)Math.Sqrt(graph.Length);

			mVis[vertexStart] = true;
			mVer.Add(vertexStart);

			if (vertexStart == vertexEnd || vertexStart >= size || vertexEnd >= size)
			{
				return true;
			}

			for (var i = 0; i < size; i++)
			{
				if (graph[vertexStart, i][0] == graph[vertexStart, i][2] || mVis[i] || mVer.Contains(i))
				{
					continue;
				}

				var currentMin = GetNumFromChar(graph[vertexStart, i][0]) - GetNumFromChar(graph[vertexStart, i][2]);

				if (currentMin < mGeneralMin)
				{
					mGeneralMin = currentMin;
				}

				if (DFS(graph, i, vertexEnd))
				{
					UpdateFlow(graph, vertexStart, i);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Retrieves the maximum flow value from the graph.
		/// </summary>
		/// <param name="graph">The graph represented as a 2D array of strings.</param>
		/// <returns>The string representation of the maximum flow.</returns>
		private string GetMaxFlow(string[,] graph)
		{
			var size = (int)Math.Sqrt(graph.Length);
			var flow = 0;
			var source = new List<char>();
			var stock = new List<char>();

			for (var i = 0; i < size; i++)
			{
				if (graph[0, i][2] != '0')
				{
					flow += GetNumFromChar(graph[0, i][2]);
					source.Add(graph[0, i][2]);
				}

				if (graph[i, size - 1][2] != '0')
				{
					stock.Add(graph[i, size - 1][2]);
				}
			}

			var strSource = source.Count > 0 ? string.Join(" + ", source) : "0";
			var strStock = stock.Count > 0 ? string.Join(" + ", stock) : "0";

			return $"{strSource} = {strStock} = {flow}";
		}

		/// <summary>
		/// Retrieves the saturated edges from the graph.
		/// </summary>
		/// <param name="graph">The graph represented as a 2D array of strings.</param>
		/// <returns>The string representation of saturated edges.</returns>
		private string GetSaturatedEdges(string[,] graph)
		{
			var size = (int)Math.Sqrt(graph.Length);
			var edges = new List<string>();

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
				{
					if (GetNumFromChar(graph[i, j][0]) == GetNumFromChar(graph[i, j][2]) && graph[i, j][2] != '0')
					{
						edges.Add($"{i + 1}-{j + 1}");
					}
				}
			}
			return string.Join(", ", edges);
		}

		/// <summary>
		/// Updates the flow value along an edge in the graph.
		/// </summary>
		/// <param name="graph">The graph represented as a 2D array of strings.</param>
		/// <param name="vertexOne">The starting vertex of the edge.</param>
		/// <param name="vertexTwo">The ending vertex of the edge.</param>
		private void UpdateFlow(string[,] graph, int vertexOne, int vertexTwo)
		{
			var lastValue = GetNumFromChar(graph[vertexOne, vertexTwo][2]);
			graph[vertexOne, vertexTwo] = graph[vertexOne, vertexTwo].Remove(2, 1);
			graph[vertexOne, vertexTwo] = graph[vertexOne, vertexTwo].Insert(2, $"{lastValue + mGeneralMin}");
		}

		/// <summary>
		/// Converts a character representing a digit to its corresponding integer value.
		/// </summary>
		/// <param name="ch">The character to convert.</param>
		/// <returns>The integer value corresponding to the character.</returns>
		private int GetNumFromChar(char ch) => ch - '0';

		#endregion
	}
}
namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Develop a program that determines if there is a path from one vertex of a directed graph to another using the reachability matrix
	/// </summary>
	public class TransposedReachabilityMatrixPathFinder
	{
		/// <summary>
		/// Checks if a path is reachable between two vertices in the transposed reachability matrix.
		/// </summary>
		/// <param name="matrix">The transposed reachability matrix representing the graph.</param>
		/// <param name="vertex1">The starting vertex.</param>
		/// <param name="vertex2">The ending vertex.</param>
		/// <returns>True if a path is reachable between vertex1 and vertex2 in the matrix; otherwise, false.</returns>
		public bool IsPathReachable(int[,] matrix, int vertex1, int vertex2) => matrix[vertex1, vertex2] == 1;

		/// <summary>
		/// Generates the transposed reachability matrix from the given adjacency matrix using Depth-First Search (DFS).
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <returns>The transposed reachability matrix representing the graph.</returns>
		public int[,] GenerateTransposedReachabilityMatrix(int[,] graph)
		{
			var size = graph.GetLength(0);
			var matrix = new int[size, size];

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
				{
					var visited = new HashSet<int>();
					matrix[i, j] = DFS(graph, i, j, visited) ? 1 : 0;
				}
			}

			for (var i = size - 1; i > 0; i--)
			{
				for (var j = 0; j < i; j++)
				{
					(matrix[j, i], matrix[i, j]) = (matrix[i, j], matrix[j, i]);
				}
			}

			return matrix;
		}

		/// <summary>
		/// Performs Depth-First Search (DFS) to determine reachability between two vertices.
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <param name="startVertex">The starting vertex for the DFS traversal.</param>
		/// <param name="endVertex">The target vertex to reach.</param>
		/// <param name="visited">A HashSet to keep track of visited vertices during traversal.</param>
		/// <returns>True if a path exists between the startVertex and the endVertex; otherwise, false.</returns>
		private bool DFS(int[,] graph, int startVertex, int endVertex, HashSet<int> visited)
		{
			var size = graph.GetLength(0);

			if (startVertex == endVertex && visited.Count > 0)
			{
				return true;
			}

			if (visited.Contains(startVertex))
			{
				return false;
			}

			visited.Add(startVertex);

			for (var i = 0; i < size; i++)
			{
				if (graph[startVertex, i] == 1 && DFS(graph, i, endVertex, visited))
				{
					return true;
				}
			}

			return false;
		} 
	}
}
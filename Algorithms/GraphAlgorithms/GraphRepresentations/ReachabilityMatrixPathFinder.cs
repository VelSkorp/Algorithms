namespace GraphAlgorithms
{
	/// <summary>
	/// Task: Develop a program that determines if there is a path from one vertex to another according to the reachability matrix
	/// </summary>
	public class ReachabilityMatrixPathFinder
	{
		/// <summary>
		/// Checks if a path exists between two vertices in the given reachability matrix.
		/// </summary>
		/// <param name="matrix">The reachability matrix representing the graph.</param>
		/// <param name="vertex1">The starting vertex.</param>
		/// <param name="vertex2">The ending vertex.</param>
		/// <returns>True if a path reachable between vertex1 and vertex2 in the matrix; otherwise, false.</returns>
		public bool IsPathReachable(int[,] matrix, int vertex1, int vertex2) => matrix[vertex1, vertex2] == 1;

		/// <summary>
		/// Creates a reachability matrix from the given adjacency matrix using Depth-First Search (DFS).
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <returns>The reachability matrix representing the graph.</returns>
		public int[,] GenerateReachabilityMatrix(int[,] graph)
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
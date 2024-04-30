namespace GraphAlgorithms
{
	/// <summary>
	/// Class for finding paths and creating transposed reachability matrices for a graph.
	/// </summary>
	public class TransposedReachabilityMatrixPathFinder : ReachabilityMatrixPathFinder
	{
		/// <summary>
		///     <para>
		///         Generates the transposed reachability matrix from the given adjacency matrix using Depth-First Search (DFS).
		///     </para>
		///     <para>
		///         Time Complexity:  O(n^3), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(n^2), where n is the number of vertices in the graph.
		///     </para>
		/// </summary>
		/// <param name="graph">The adjacency matrix representation of the graph.</param>
		/// <returns>The transposed reachability matrix representing the graph.</returns>
		public int[,] GenerateTransposedReachabilityMatrix(int[,] graph)
		{
			var size = graph.GetLength(0);
			var matrix = GenerateReachabilityMatrix(graph);

			for (var i = size - 1; i > 0; i--)
			{
				for (var j = 0; j < i; j++)
				{
					(matrix[j, i], matrix[i, j]) = (matrix[i, j], matrix[j, i]);
				}
			}

			return matrix;
		}
	}
}
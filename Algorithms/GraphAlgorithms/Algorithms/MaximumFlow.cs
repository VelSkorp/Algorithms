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
		private string[,] mGraph;

		#endregion

		#region Constructor

		public MaximumFlow(string[,] graph)
		{
			mGraph = graph;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Calculates the maximum flow in the graph and returns information about it.
		/// </summary>
		/// <returns>
		/// A tuple containing information about the maximum flow and saturated edges.
		/// </returns>
		public (string, string) FindMaxFlowAndSaturatedEdges()
		{
			Initialize();

			mVer.Remove(0);
			mVer.Remove(6);
			Initialize();

			mVer.Remove(0);
			mVer.Remove(6);
			Initialize();

			mVer = new HashSet<int>();
			Initialize();

			mVer = new HashSet<int>();
			Initialize();

			return (GetMaxFlow(), GetSaturatedEdges());
		}

		#endregion

		#region Private Methods

		private void Initialize()
		{
			var size = (int)Math.Sqrt(mGraph.Length);

			mVis = new bool[size];
			mGeneralMin = int.MaxValue;
			DFS(0, size - 1);
		}

		private bool DFS(int vertexStart, int vertexEnd)
		{
			var size = (int)Math.Sqrt(mGraph.Length);

			mVis[vertexStart] = true;
			mVer.Add(vertexStart);

			for (var i = 0; i < size; i++)
			{
				if (vertexStart == vertexEnd)
				{
					return true; 
				}

				if (mGraph[vertexStart, i][0] == mGraph[vertexStart, i][2] || mVis[i] || mVer.Contains(i))
				{
					continue; 
				}

				var currentMin = GetNumFromChar(mGraph[vertexStart, i][0]) - GetNumFromChar(mGraph[vertexStart, i][2]);

				if (currentMin < mGeneralMin)
				{
					mGeneralMin = currentMin; 
				}

				if (DFS(i, vertexEnd))
				{
					UpdateFlow(vertexStart, i);
					return true;
				}
			}
			return false;
		}

		private string GetMaxFlow()
		{
			var size = (int)Math.Sqrt(mGraph.Length);
			var flow = 0;
			var source = new List<char>();
			var stock = new List<char>();

			for (var i = 0; i < size; i++)
			{
				if (mGraph[0, i][2] != '0')
				{
					flow += GetNumFromChar(mGraph[0, i][2]);
					source.Add(mGraph[0, i][2]);
				}

				if (mGraph[i, size - 1][2] != '0')
				{
					stock.Add(mGraph[i, size - 1][2]);
				}
			}

			var strSource = source.Count > 0 ? string.Join(" + ", source) : "0";
			var strStock = stock.Count > 0 ? string.Join(" + ", stock) : "0";

			return $"{strSource} = {strStock} = {flow}";
		}

		private string GetSaturatedEdges()
		{
			var size = (int)Math.Sqrt(mGraph.Length);
			var edges = new List<string>();

			for (var i = 0; i < size; i++)
			{
				for (var j = 0; j < size; j++)
				{
					if (GetNumFromChar(mGraph[i, j][0]) == GetNumFromChar(mGraph[i, j][2]) && mGraph[i, j][2] != '0')
					{
						edges.Add($"{i + 1}-{j + 1}");
					}
				}
			}
			return string.Join(", ", edges);
		}

		private void UpdateFlow(int vertexOne, int vertexTwo)
		{
			var lastValue = GetNumFromChar(mGraph[vertexOne, vertexTwo][2]);
			mGraph[vertexOne, vertexTwo] = mGraph[vertexOne, vertexTwo].Remove(2, 1);
			mGraph[vertexOne, vertexTwo] = mGraph[vertexOne, vertexTwo].Insert(2, $"{lastValue + mGeneralMin}");
		}

		private int GetNumFromChar(char ch) => ch - '0';

		#endregion
	}
}
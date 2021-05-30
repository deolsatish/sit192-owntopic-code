using System;

namespace DjikstraCode
{
	class GFG
	{
		
		static int V = 9;
		

		void printSolution(int[] dist)
		{
			Console.Write("Vertex \t\t Distance "
						+ "from Source\n");
			for (int i = 0; i < V; i++)
				Console.Write(i + " \t\t " + dist[i] + "\n");
		}

		int minDist(int[] dist, bool[] minSet)
		{
			int min = int.MaxValue;
			int min_index = -1;

			for (int v = 0; v < V; v++)
				if (minSet[v] == false && dist[v] <= min)
				{
					min = dist[v];
					min_index = v;
				}

			return min_index;
		}

		void dijkstra(int[,] graph, int src)
		{
			int[] dist = new int[V]; 
			bool[] minSet = new bool[V];

			for (int i = 0; i < V; i++)
			{
				dist[i] = int.MaxValue;
				minSet[i] = false;
			}

			dist[src] = 0;

			for (int count = 0; count < V - 1; count++)
			{
				int u = minDist(dist, minSet); 

				minSet[u] = true;

				for (int v = 0; v < V; v++)

					if (!minSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
						dist[v] = dist[u] + graph[u, v]; // this is basically relaxation
			}

			printSolution(dist);
		}

		public static void Main()
		{
			int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
									{ 4, 0, 8, 0, 0, 0, 0, 11, 0 },
									{ 0, 8, 0, 7, 0, 4, 0, 0, 2 },
									{ 0, 0, 7, 0, 9, 14, 0, 0, 0 },
									{ 0, 0, 0, 9, 0, 10, 0, 0, 0 },
									{ 0, 0, 4, 14, 10, 0, 2, 0, 0 },
									{ 0, 0, 0, 0, 0, 2, 0, 1, 6 },
									{ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
									{ 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
			GFG gfg = new GFG();
			gfg.dijkstra(graph, 0);
		}
	}
}

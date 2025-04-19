using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.GraphMst;
using Algorithms.Graphs;
using Algorithms.GraphsMst;
using Algorithms.GraphsShortestPath;
using Algorithms.Hashs;
using Algorithms.Heap;
using Algorithms.Lists;
using Algorithms.TopologicalSortAndConnectedComponent;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            UndirectedGraph graph = new UndirectedGraph(6);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 5);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);

            Console.WriteLine(graph.ToString());

            DepthFirstSearch dfs = new DepthFirstSearch();
            Vertex[] vertices = dfs.Execute(graph, 0);
            foreach (var vertice in vertices)
            {
                Console.WriteLine($"Vertice: {vertice.V} - Distance {vertice.Distance} - Time {vertice.FinishTime}");
            }

            foreach (var each in dfs.PathTo(5))
            {
                Console.Write(each + " ");
            }
        }
    }
}
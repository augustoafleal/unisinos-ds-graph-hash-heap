using System;
using System.Linq;
using Algorithms.GraphMst;
using Algorithms.Graphs;
using Algorithms.GraphsMst;
using Algorithms.GraphsShortestPath;
using Algorithms.Hashs;
using Algorithms.Heap;
using Algorithms.Lists;
using Algorithms.TopologicalSort;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pecas =
                { "cueca", "calça", "cinto", "camisa", "gravata", "paletó", "meias", "sapatos", "relógio" };
            
            DirectedGraph graph = new DirectedGraph(9);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(0, 7);
            graph.AddEdge(1, 7);
            graph.AddEdge(1, 2);
            graph.AddEdge(6, 7);
            graph.AddEdge(3, 2);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.AddEdge(2, 8);
            graph.AddEdge(8, 5);
            Console.WriteLine(graph);
            
            TopologicalSort.TopologicalSort tr = new TopologicalSort.TopologicalSort(graph, 0);

            foreach (var vertex in tr.Order)
            {
                Console.WriteLine($"{pecas[vertex.V]}: ({vertex.Distance} / {vertex.FinishTime})");
            }
        }
    }
}


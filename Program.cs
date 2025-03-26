using System;
using System.Linq;
using Algorithms.GraphMst;
using Algorithms.Graphs;
using Algorithms.GraphsMst;
using Algorithms.Hashs;
using Algorithms.Heap;
using Algorithms.Lists;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph wg = new WeightedGraph(9);

            wg.AddEdge(new Edge(0, 1, 4));
            wg.AddEdge(new Edge(0, 7, 8));
            wg.AddEdge(new Edge(1, 7, 11));
            wg.AddEdge(new Edge(1, 2, 8));
            wg.AddEdge(new Edge(7, 8, 7));
            wg.AddEdge(new Edge(7, 6, 1));
            wg.AddEdge(new Edge(8, 6, 6));
            wg.AddEdge(new Edge(8, 2, 2));
            wg.AddEdge(new Edge(2, 3, 7));
            wg.AddEdge(new Edge(2, 5, 4));
            wg.AddEdge(new Edge(6, 5, 2));
            wg.AddEdge(new Edge(3, 5, 14));
            wg.AddEdge(new Edge(3, 4, 9));
            wg.AddEdge(new Edge(5, 4, 10));
            Console.WriteLine(wg.ToString());

            Prim prim = new Prim(wg, 0);
            var queue = prim.Mst;
            foreach (var edge in queue)
            {
                Console.WriteLine(edge.ToString());
            }
            Console.WriteLine(prim.Weight);
        }
    }
}
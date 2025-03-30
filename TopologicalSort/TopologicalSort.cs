using System.Collections.Generic;
using Algorithms.Graphs;

namespace Algorithms.TopologicalSort;

public class TopologicalSort
{
    public List<Vertex> Order { get; set; }
    public Vertex[] Vertices { get; set; }
    public int time { get; set; }

    public TopologicalSort(DirectedGraph graph, int s)
    {
        DepthFirstSearch dfs = new DepthFirstSearch();
        Vertices = dfs.Execute(graph, s);
        Order = dfs.Order;
    }
}
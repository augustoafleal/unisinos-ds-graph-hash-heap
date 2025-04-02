using System;
using Algorithms.Graphs;

namespace Algorithms.TopologicalSortAndConnectedComponent;

public class ConnectedComponent
{
    public bool[] Marked { get; set; }
    public int[] Id { get; set; }
    public int Count { get; set; }

    public ConnectedComponent(Graph graph)
    {
        Marked = new bool[graph.V];
        Id = new int[graph.V];
        for (int v = 0; v < graph.V; v++)
        {
            if (!Marked[v])
            {
                dfs(graph, v);
                Count++;
            }
        }
    }

    private void dfs(Graph graph, int v)
    {
        Marked[v] = true;
        Id[v] = Count;
        foreach (var w in graph.Adj(v))
        {
            if (!Marked[w])
            {
                dfs(graph, w);
            }
        }
    }

    public int GetIdByPosition(int v)
    {
        if (Id == null || v < 0 || v >= Id.Length)
        {
            throw new IndexOutOfRangeException($"Index {v} is out of range.");
        }
        return Id[v];
    }
    
}
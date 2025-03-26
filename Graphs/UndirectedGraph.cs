using System;

namespace Algorithms.Graphs;

public class UndirectedGraph(int v) : Graph(v)
{
    public override void AddEdge(int v, int w) {
        base.AddEdge(v, w);
        adj[v].Add(w);
        adj[w].Add(v);
    }

}
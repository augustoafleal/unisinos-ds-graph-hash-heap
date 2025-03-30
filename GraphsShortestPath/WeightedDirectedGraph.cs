using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.GraphsMst;

namespace Algorithms.GraphsShortestPath;

public class WeightedDirectedGraph
{
    public int V { get; private set; }
    public int E { get; private set; }
    public List<DirectedEdge>[] adj;

    public WeightedDirectedGraph(int v)
    {
        if (this.V < 0)
        {
            throw new ArgumentException("Number of vertices must be non-negative");
        }

        this.V = v;
        this.E = 0;
        adj = new List<DirectedEdge>[V];    
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<DirectedEdge>();
        }
    }

    private void ValidateVertex(int v)
    {
        if (v < 0 || v >= this.V)
        {
            throw new ArgumentException($"Vertex {v} should be between 0 and {this.V - 1}");
        }
    }

    public void AddEdge(DirectedEdge e)
    {
        int v = e.From();
        int w = e.To();
        ValidateVertex(v);
        ValidateVertex(w);
        adj[v].Add(e);
        E++;
    }

    public IEnumerable<DirectedEdge> Adj(int v)
    {
        ValidateVertex(v);
        return adj[v];
    }

    public IEnumerable<DirectedEdge> Edges()
    {
        List<DirectedEdge> edges = new List<DirectedEdge>();          
        for (int v = 0; v < this.V; v++)
        {
            edges.AddRange(adj[v]);
        }
        return edges;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"V: {this.V}, E: {this.E}");

        for (int v = 0; v < this.V; v++)
        {
            sb.Append($"{v}: ");
            foreach (var edge in adj[v])
            {
                sb.Append($"[{edge.From()} -> {edge.To()}, Weight: {edge.Weight}] ");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
    
}
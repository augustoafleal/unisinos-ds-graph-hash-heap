using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.GraphsMst;

namespace Algorithms.GraphMst;

public class WeightedGraph
{
    public int V { get; private set; }
    public int E { get; private set; }
    public List<Edge>[] adj;

    public WeightedGraph(int v)
    {
        if (this.V < 0)
        {
            throw new ArgumentException("Number of vertices must be non-negative");
        }

        this.V = v;
        this.E = 0;
        adj = new List<Edge>[V];    
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<Edge>();
        }
    }

    private void ValidateVertex(int v)
    {
        if (v < 0 || v >= this.V)
        {
            throw new ArgumentException($"Vertex {v} should be between 0 and {this.V - 1}");
        }
    }

    public void AddEdge(Edge e)
    {
        int v = e.V;
        int w = e.Other(v);
        ValidateVertex(v);
        ValidateVertex(w);
        adj[v].Add(e);
        adj[w].Add(e);
        E++;
    }

    public IEnumerable<Edge> Adj(int v)
    {
        ValidateVertex(v);
        return adj[v];
    }

    public IEnumerable<Edge> Edges()
    {
        List<Edge> edges = new List<Edge>();
        for (int v = 0; v < this.V; v++)
        {
            int selfLoops = 0;
            foreach (var e in Adj(v))
            {
                if (e.Other(v) > v)
                {
                    edges.Add(e);
                }
                // Add only one copy of each self loop (self loops will be consecutive
                else if (e.Other(v) == v)
                {
                    if (selfLoops % 2 == 0)
                    {
                        edges.Add(e);
                    } 
                    selfLoops++;
                }
                
            }

        }
        
        return edges;
    }

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"V: {this.V} - E:{this.E}");
        sb.AppendLine();
        for (int i = 0; i < this.V; i++)
        {
            sb.Append($"{i}: ");
            foreach (var edge in adj[i])
            {
                sb.Append($"[W: {edge.Other(i).ToString()} Weight: {edge.Weight}] ");
            }

            sb.AppendLine();
        }
        return sb.ToString();
    }
    
}
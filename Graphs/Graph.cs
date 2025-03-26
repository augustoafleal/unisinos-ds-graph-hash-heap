using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graphs;

public abstract class Graph
{
    public int V { get; }
    protected int E { get; set; }
    protected List<int>[] adj;

    public Graph(int V)
    {
        if (V < 0)
        {
            throw new ArgumentException("Number of vertices must be non-negative");
        }

        this.V = V;
        Clear();
    }

    public bool IsEmpty()
    {
        return V == 0;
    }

    public virtual void Clear()
    {
        E = 0;
        adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }
    }
    public virtual void AddEdge(int v, int w)
    {
        ValidateVertex(v);
        ValidateVertex(w);
        E++;
    }

    public virtual IEnumerable<int> Adj(int v)
    {
        ValidateVertex(v);
        return adj[v];
    }

    private void ValidateVertex(int v)
    {
        if (v < 0 || v >= adj.Length)
        {
            throw new ArgumentException($"Vertex {v} is out of bounds.");
        }
    }

    public new string ToString()
    {
        StringBuilder sb = new StringBuilder("\n");
        for (int i = 0; i < V; i++)
        {
            sb.Append("[" + i + "] => ");
        
            // Ensure that adj[i] is not null and is a list (or similar collection)
            if (adj[i].Count > 0)
            {
                sb.Append(string.Join(", ", adj[i]));  // Join the adjacent vertices with a comma
            }
            else
            {
                sb.Append("No adjacent vertices");
            }
        
            sb.Append("\n");
        }
        return sb.ToString();
    }
}
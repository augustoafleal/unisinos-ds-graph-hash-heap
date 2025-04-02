using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Graphs;

namespace Algorithms.TopologicalSortAndConnectedComponent;

public class StronglyConnectedComponent
{
    public Vertex[] Vertices { get; set; }
    public int Time { get; set; }
    public int Components { get; set; }
    
    public int[] VerticesComponents { get; set; }
    
    public Vertex[] Execute(DirectedGraph graph)
    {
        Initialize(graph.V);

        this.Time = 0;

        // DFS 1
        foreach (var u in Vertices)
        {
            if (u.Color == Color.WHITE)
            {
                Visit(graph, u);
            }
            
        }
        
        // G^T
        var orderedVertices = Vertices.OrderByDescending(v => v.FinishTime).ToList();
        DirectedGraph reversedGraph = Reverse(graph);
        
        // DFS II
        this.Time = 0;
        this.Components = 0;
        foreach (var v in orderedVertices)
        {
            v.Color = Color.WHITE;
        }
        foreach (var u in orderedVertices)
        {                

            if (u.Color == Color.WHITE)
            {
                this.Components++;
                Visit(reversedGraph, u);
            }
            
        }
        
        return Vertices;
    }

    public void Initialize(int v)
    {
        Vertices = new Vertex[v];
        VerticesComponents = new int[v];
        for (int i = 0; i < v; i++)
        {
            Vertices[i] = new Vertex(i, Color.WHITE);
            VerticesComponents[i] = 0;
        }
    }

    public void Visit(Graph graph, Vertex u)
    {
        u.Distance = ++this.Time;
        u.Color = Color.GRAY;
        foreach (var v in graph.Adj((u.V)))
        {
            if (Vertices[v].Color == Color.WHITE)
            {
                Vertices[v].Predecessor = u.V;
                Visit(graph, Vertices[v]);
            }
        }

        VerticesComponents[u.V] = Components;
        u.FinishTime = ++this.Time;
        u.Color = Color.BLACK;
    }
    private DirectedGraph Reverse(DirectedGraph graph)
    {
        DirectedGraph reverse = new DirectedGraph(graph.V);

        for (int v = 0; v < reverse.V; v++)
        {
            foreach (var w in graph.Adj(v))
            {
                reverse.AddEdge(w, v);
            }
        }

        return reverse;
    }
}
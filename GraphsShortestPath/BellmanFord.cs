using System;
using System.Collections.Generic;
using Algorithms.Graphs;
using Algorithms.Heap;

namespace Algorithms.GraphsShortestPath;

public class BellmanFord
{
    public double Weight { get; set; }

    //public Queue<Edge> Mst { get; set; } = new Queue<Edge>();
    public Vertex[] Vertices { get; set; }

    public bool Execute(WeightedDirectedGraph graph, int s)
    {
        InitializeSingleSource(graph, s);

        for (int i = 0; i < graph.V; i++)
        {
            foreach (var edge in graph.Edges())
            {
                //Console.WriteLine(edge);
                Relax(edge);
            }
        }

        foreach (var edgeVerify in graph.Edges())
        {
            Vertex u = Vertices[edgeVerify.From()];
            Vertex v = Vertices[edgeVerify.To()];
            if (v.Distance > u.Distance + edgeVerify.Weight)
            {
                return false;
            }
        }

        return true;
    }

    private void InitializeSingleSource(WeightedDirectedGraph graph, int s)
    {
        Vertices = new Vertex[graph.V];
        for (int i = 0; i < graph.V; i++)
        {
            Vertices[i] = new Vertex(i);
        }

        Vertices[s].Distance = 0;
    }

    private void Relax(DirectedEdge e)
    {
        int v = e.From();
        int w = e.To();

        if (Vertices[w].Distance > Vertices[v].Distance + e.Weight)
        {
            Vertices[w].Predecessor = v;
            Vertices[w].Distance = Vertices[v].Distance + (int)e.Weight;
        }
    }

    public IEnumerable<int> PathTo(int v)
    {
        if (Vertices[v].Distance == int.MaxValue)
        {
            return null;
        }

        LinkedList<int> path = new LinkedList<int>();
        int current;
        for (current = v; Vertices[current].Predecessor != -1; current = Vertices[current].Predecessor)
        {
            path.AddFirst(Vertices[current].V);
        }

        path.AddFirst(Vertices[current].V);
        return path;
    }

    public int Distance(int v)
    {
        if (Vertices[v].Distance == int.MaxValue)
        {
            throw new ArgumentException("Distance can't be positive infinity");
        }

        int distance = Vertices[v].Distance;

        return distance;
    }
}
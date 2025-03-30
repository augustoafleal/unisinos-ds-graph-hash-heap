using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.GraphMst;
using Algorithms.Graphs;
using Algorithms.Heap;

namespace Algorithms.GraphsShortestPath;

public class Dijkstra
{
    public PQ<Vertex> Pq { get; set; } = new MinPQ<Vertex>();
    public Vertex[] Vertices { get; set; }

    public Dijkstra(WeightedDirectedGraph graph, int s)
    {
        foreach (var edge in graph.Edges())
        {
            if (edge.Weight < 0)
            {
                throw new ArgumentNullException($"Edge {edge} must have weight greater than 0");
            }

            InitializeSingleSource(graph, s);

            foreach (var vertex in Vertices)
            {
                Pq.Insert(vertex);
            }

            while (!Pq.IsEmpty())
            {
                Vertex u = Pq.Extract();
                foreach (var edgeAdj in graph.Adj(u.V))
                {
                    Relax(edgeAdj);
                }
            }
        }
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
            int indexPq = Pq.Search(Vertices[w]);
            Pq.Decrease(indexPq, Vertices[w]);
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
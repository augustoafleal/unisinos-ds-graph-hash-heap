using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.GraphMst;
using Algorithms.Graphs;
using Algorithms.Heap;

namespace Algorithms.GraphsMst;

public class Prim
{
    public double Weight { get; set; }
    public Queue<Edge> Mst { get; set; } = new Queue<Edge>();
    public PQ<Vertex> Pq { get; set; } = new MinPQ<Vertex>();
    public Vertex[] Vertices { get; set; }

    public Prim(WeightedGraph graph, int s)
    {
        // Create vertices
        Vertex[] verticesArray = new Vertex[graph.V];
        for (int i = 0; i < graph.V; i++)
        {
            verticesArray[i] = new Vertex(i);
        }
        
        verticesArray[s].V = 0;

        // Add vertex to Pq
        foreach (var vertex in verticesArray)
        {
            Pq.Insert(vertex);
        }

        // Prim

        while (!Pq.IsEmpty())
        {
            Vertex u = Pq.Extract();
            foreach (var edge in graph.Adj(u.V))
            {
                Vertex v = verticesArray[edge.Other(u.V)];
                int indexPq = Pq.Search(v);
                if (indexPq != -1 && edge.Weight < v.Distance)
                {
                    v.Predecessor = u.V;
                    v.Distance = (int) edge.Weight;
                    Pq.Decrease(indexPq, v);
                }
            }

            if (u.Predecessor != -1 && u.Distance < Int32.MaxValue)
            {
                Weight += u.Distance;
            }
        }

        foreach (var edge in graph.Edges())
        {
            int v = edge.V;
            int w = edge.Other(v);
            if (verticesArray[v].Predecessor == w || verticesArray[w].Predecessor == v)
            {
                Mst.Enqueue(edge);
            }
        }
        
        Mst = new Queue<Edge>(Mst.OrderBy(edge => edge.Weight));
        
    }
    
}
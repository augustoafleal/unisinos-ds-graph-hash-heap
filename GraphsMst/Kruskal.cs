using System;
using System.Collections.Generic;
using Algorithms.GraphMst;
using Algorithms.Graphs;

namespace Algorithms.GraphsMst;

public class Kruskal
{
    public double Weight { get; set; }
    public Queue<Edge> Mst { get; set; } = new Queue<Edge>();
    public HashSet<HashSet<int>?> Sets { get; set; }

    public Kruskal(WeightedGraph graph)
    {
        Sets = new HashSet<HashSet<int>?>();
        // Make set
        for (int i = 0; i < graph.V; i++)
        {
            Sets.Add(new HashSet<int> { i });
        }

        // Edges order
        List<Edge> edges = new List<Edge>();
        foreach (var edge in graph.Edges())
        {
            edges.Add(edge);
        }

        edges.Sort();

        foreach (var edge in edges)
        {
            int v = edge.V;
            int w = edge.Other(v);
            //v -w does not create a cycle
            if (FindSet(v) != FindSet(w))
            {
                Mst.Enqueue(edge);
                Union(v, w);
                this.Weight += edge.Weight;
            }
        }
    }

    private HashSet<int>? FindSet(int u)
    {
        foreach (var set in this.Sets)
        {
            if (set.Contains(u))
            {
                return set;
            }
        }

        return null;
    }

    private void Union(int v, int w)
    {
        HashSet<int> set1 = FindSet(v);
        HashSet<int> set2 = FindSet(w);
        var union = new HashSet<int>(set1);
        union.UnionWith(set2);
        Console.WriteLine("Union of sets: " + string.Join(", ", union));
        Sets.Remove(set1);
        Sets.Remove(set2);
        Sets.Add(union);
    }
    
}
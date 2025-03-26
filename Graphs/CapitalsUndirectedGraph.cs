using System;
using System.Collections.Generic;

namespace Algorithms.Graphs;

public class CapitalsUndirectedGraph(int v) : Graph(v)
{
    protected Dictionary<(int, int), int> EdgeWeights;
    
    public override void Clear()
    {
        base.Clear(); // Inicializa a lista de adjacência
        EdgeWeights = new Dictionary<(int, int), int>(); // Inicializa o dicionário de pesos
    }
    
    public void AddEdge(int v, int w, int weight)
    {
        base.AddEdge(v, w);
        adj[v].Add(w);
        adj[w].Add(v); 
        EdgeWeights[(v, w)] = weight;
        EdgeWeights[(w, v)] = weight;
        E++;
    }
    
    public int GetKm(int v, int w)
    {
        if (EdgeWeights.TryGetValue((v, w), out int weight))
        {
            return weight;
        }
        throw new ArgumentException($"No edge exists between vertex {v} and vertex {w}");
    }



}
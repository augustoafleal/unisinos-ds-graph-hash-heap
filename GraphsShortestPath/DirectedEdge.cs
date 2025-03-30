using System;
using Algorithms.Graphs;

namespace Algorithms.GraphsShortestPath;

public class DirectedEdge : IComparable<DirectedEdge>
{
    public int V { get; set; }
    public int W { get; set; }
    public double Weight { get; set; }

    public DirectedEdge(int v, int w, double weight)
    {
        if (v < 0 || w < 0)
        {
            throw new ArgumentException("Vertex index must be non-negative");
        }

        if (double.IsNaN(weight))
        {
            throw new ArgumentException("Vertex weight must not be NaN");
        }
        
        this.V = v;
        this.W = w;
        this.Weight = weight;
    }

    public int From() => this.V;
    
    public int To() => this.W;

    public int CompareTo(DirectedEdge other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        return this.Weight.CompareTo(other.Weight);
    }

    public override bool Equals(Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        DirectedEdge other = (DirectedEdge) obj;
        return this.V == other.V && this.W == other.W && this.Weight == other.Weight;
    }

    public override String ToString()
    {
        return $"{V} -> {W} ({Weight})";
    }
    
}
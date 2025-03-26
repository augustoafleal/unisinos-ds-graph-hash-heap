using System;

namespace Algorithms.GraphsMst;

public class Edge : IComparable<Edge>
{
    public int V { get; set; }
    public int W { get; set; }
    public double Weight { get; set; }

    public Edge(int v, int w, double weight)
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

    public int Other(int vertex)
    {
        if (vertex == this.V)
        {
            return this.W;
        } 
        else if (vertex == this.W)
        {
            return this.V;
        }
        else
        {
            throw new ArgumentException($"Illegal endpoint");
        }
    }

    public int CompareTo(Edge that)
    {
        return this.Weight.CompareTo(that.Weight);
    }

    public bool Equals(Object obj)
    {
        Edge other = (Edge)obj;
        return this.V == other.V && this.W == other.W;
    }

    public String ToString()
    {
        return String.Format($"V:{this.V}, W:{this.W}, Weight:{this.Weight}");
    }
    
}
using System;

namespace Algorithms.Graphs;

public enum Color
{
    WHITE,
    GRAY,
    BLACK
}
public class Vertex : IComparable<Vertex>
{
    public int V { get; set; }
    public Color Color { get; set; }
    public int Distance { get; set;  }
    public int Predecessor { get; set; }
    
    public int FinishTime { get; set; }

    public Vertex(int v, Color color)
    {
        this.V = v;
        this.Color = color;
        this.Predecessor = -1;
    }
    
    public Vertex(int v)
    {
        this.V = v;
        this.Color = Color.BLACK;
        this.Predecessor = -1;
        this.Distance = Int32.MaxValue;
    }

    public int CompareTo(Vertex? other)
    {
        return this.Distance.CompareTo(other.Distance);
    }

    public bool Equals(object obj)
    {
        Vertex other = (Vertex)obj;
        return this.V == other.V;   
    }

    public override string ToString()
    {
        return $"[v: {this.V} predecessor: {this.Predecessor} distance: {this.Distance}]";
    }
    
}
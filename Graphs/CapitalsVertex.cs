namespace Algorithms.Graphs;

public enum CapitalsColor
{
    WHITE,
    GRAY,
    BLACK
}
public class CapitalsVertex
{
    public int V { get; set; }
    public Color Color { get; set; }
    public int Distance { get; set; }
    public int Predecessor { get; set; }
    
    public int FinishTime { get; set; }
    
    public CapitalsVertex(int v, Color color, int km)
    {
        this.V = v;
        this.Color = color;
        this.Predecessor = -1;
    }

    public bool Equals(object obj)
    
    {
        Vertex other = (Vertex)obj;
        return this.V == other.V;   
    }
    
}
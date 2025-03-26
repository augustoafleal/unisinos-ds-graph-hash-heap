namespace Algorithms.Graphs;

public class DirectedGraph(int v) : Graph(v)
{
    public new void AddEdge(int v, int w) {
        base.AddEdge(v, w);
        adj[v].Add(w);
    }

}
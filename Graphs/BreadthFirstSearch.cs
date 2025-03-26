using System.Collections.Generic;

namespace Algorithms.Graphs;

public class BreadthFirstSearch
{
    private Vertex[] _vertices;
    
    public Vertex[] Execute(Graph g, int s)
    {
        _vertices = new Vertex[g.V];
        
        for (int i = 0; i < g.V; i++)
        {
            _vertices[i] = new Vertex(i, Color.WHITE);
        }
        
        _vertices[s].Color = Color.GRAY;
        _vertices[s].Distance = 0;
        
        Queue<Vertex> q = new Queue<Vertex>();
        q.Enqueue(_vertices[s]);
        while (q.Count > 0)
        {
            Vertex u = q.Dequeue();
            foreach (var v in g.Adj(u.V))
            {
                if (_vertices[v].Color == Color.WHITE)
                {
                    _vertices[v].Color = Color.GRAY;
                    _vertices[v].Distance = u.Distance + 1;
                    _vertices[v].Predecessor = u.V;
                    q.Enqueue(_vertices[v]);
                }
            }

            u.Color = Color.BLACK;
        }

        return _vertices;

    }

    public IEnumerable<int> PathTo(int v)
    {
        LinkedList<int> path = new LinkedList<int>();
        int x;
        for (x = v; _vertices[x].Predecessor != -1; x = _vertices[x].Predecessor)
        {
            path.AddFirst(_vertices[x].V);
        }
        path.AddFirst(x);
        return path;
    }
}
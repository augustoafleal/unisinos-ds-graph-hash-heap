using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs;

public class DepthFirstSearch
{
    
    private Vertex[] _vertices;
    private int _time;
    
    public Vertex[] Execute(Graph g, int s)
    {
        _vertices = new Vertex[g.V];
        
        for (int i = 0; i < g.V; i++)
        {
            _vertices[i] = new Vertex(i, Color.WHITE);
        }
        
  
        _time = 0;

        for (var i = 0; i < g.V; i++)
        {
            if (_vertices[i].Color == Color.WHITE)
            {
                ExecuteVisit(g, i);
            }
        }

        return _vertices;
    }

    private void ExecuteVisit(Graph g, int i)
    {
        _time += 1;
        _vertices[i].Distance = _time;
        _vertices[i].Color = Color.GRAY;
        Console.WriteLine($"Working with {_vertices[i].V}");
        foreach (var v in g.Adj(_vertices[i].V).OrderBy(x => x))
        {
            if (_vertices[v].Color == Color.WHITE)
            {   
                Console.WriteLine($"Adjacency with {_vertices[v].V}");
                _vertices[v].Predecessor = _vertices[i].V; 
                ExecuteVisit(g, _vertices[v].V);
            }
        }

        _vertices[i].Color = Color.BLACK;
        _time += 1;
        _vertices[i].FinishTime = _time;
        Console.WriteLine($"Painting black: {_vertices[i].V}");

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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.GraphMst;
using Algorithms.Graphs;
using Algorithms.GraphsMst;
using Algorithms.GraphsShortestPath;
using Algorithms.Hashs;
using Algorithms.Heap;
using Algorithms.Lists;
using Algorithms.TopologicalSortAndConnectedComponent;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "TopologicalSortAndConnectedComponent/graphScc.txt");
            
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                
                DirectedGraph graph = new DirectedGraph(int.Parse(lines[0]));
                
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    int v = int.Parse(parts[0]);
                    int w = int.Parse(parts[1]);
                    graph.AddEdge(v, w);
                }
                
                Console.WriteLine(graph);
                
                StronglyConnectedComponent scc = new StronglyConnectedComponent();
                Vertex[] vertices = scc.Execute(graph);
                int components = scc.Components;
                
                
                Console.WriteLine("Components: " + components);
                Queue<int>[] listOfComponents = new Queue<int>[components];
                
                for (int i = 0; i < components; i++)
                {
                    listOfComponents[i] = new Queue<int>();
                }

                foreach (var vertex in vertices)
                {
                    int component = scc.VerticesComponents[vertex.V];
                    listOfComponents[component - 1].Enqueue(vertex.V);
                }
                
                for (int i = 0; i < components; i++)
                {
                    foreach (var v in listOfComponents[i])
                    {
                        Console.Write($"{v} ");
                    }
                    Console.WriteLine();
                }
               
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            
        }
    }
}
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
                  string[] capitals =
            {
                "AP - Macapá",
                "RS - Porto Alegre",
                "SC - Florianópolis",
                "PR - Curitiba",
                "SP - São Paulo",
                "RJ - Rio de Janeiro",
                "ES - Vitória",
                "MG - Belo Horizonte",
                "MS - Campo Grande",
                "MT - Cuiabá",
                "GO - Goiânia",
                "DF - Brasília",
                "BA - Salvador",
                "SE - Aracaju",
                "AL - Maceió",
                "PE - Recife",
                "PB - João Pessoa",
                "RN - Natal",
                "CE - Fortaleza",
                "PI - Teresina",
                "MA - São Luís",
                "TO - Palmas",
                "RO - Porto Velho",
                "AC - Rio Branco",
                "AM - Manaus",
                "RR - Boa Vista",
                "PA - Belém"
            };

            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent
                .FullName;
            string filePath = Path.Combine(projectDirectory, "GraphsShortestPath/graphCapitals.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                WeightedDirectedGraph graph = new WeightedDirectedGraph(int.Parse(lines[0]));

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int v = int.Parse(parts[0]);
                    int w = int.Parse(parts[1]);
                    int weight = int.Parse(parts[2]);
                    graph.AddEdge(new DirectedEdge(v, w, weight));
                }

                int source = 12;
                Dijkstra dijkstra = new Dijkstra(graph, source);

                Console.WriteLine($"> Listando caminhos e distâncias a partir da capital: {capitals[source]}");

                for (int i = 0; i < graph.V; i++)
                {
                    int destination = i;
                    foreach (var each in dijkstra.PathTo(destination))
                    {
                        Console.Write($"[{each} {capitals[each]}]");
                        if (each != destination)
                        {
                            Console.Write(" -> ");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    Console.WriteLine($" | Distance: {dijkstra.Distance(destination)} km");
                }
            }
        }
    }
}
## **Hashing**

```c#
int capacity = 8;
var table = new OpenHashing<int, int>(capacity);
            
int[] values = { 1055, 1492, 1776, 1812, 1918, 1945, 2002 };
            
foreach (var value in values)
{
    table.Insert(value, value);  
}

//for (int i = 1; i <= 20; i++)
//{
//    table.Insert(i, i);
//}
Console.WriteLine(table);
```

## Heap

### Heap normal

```c#
int[] a = { 64, 60, 21, 38, 59, 7, 18, 1, 23, 2 };
PQ<int> pq = new MaxPQ<int>();
for (var i = 0; i < 10; i++)
{
    pq.Insert(a[i]);
}
Console.WriteLine(pq.ToTree());

pq.Insert(75);
Console.WriteLine(pq.ToTree());
Console.WriteLine(pq.ToString());
Console.WriteLine($"A chave max é: {pq.Key()}");
Console.WriteLine($"Realizando extract: {pq.Extract()}");

Console.WriteLine(pq.ToTree());
Console.WriteLine(pq.ToString());
Console.ReadKey();
```

### HeapSort
```c#
int[] a = { 60, 56, 65, 12, 99, 19, 50, 48, 5, 44, 51, 17, 94, 7, 88, 72, 25, 29, 88, 3 };
Console.WriteLine(string.Join(", ", a));
HeapsortUtil.HeapSort(a);
Console.WriteLine(string.Join(", ", a));
Console.ReadKey();
```

## Graphs

### BreadthFirstSearch
```c#
UndirectedGraph graph = new UndirectedGraph(6);
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(0, 5);
graph.AddEdge(1, 2);
graph.AddEdge(2, 3);
graph.AddEdge(2, 4);
graph.AddEdge(3, 4);
graph.AddEdge(3, 5);

Console.WriteLine(graph.ToString());

BreadthFirstSearch bfs = new BreadthFirstSearch();
Vertex[] vertices = bfs.bfs(graph, 0);
foreach (var vertice in vertices)
{
    Console.WriteLine($"Vertice: {vertice.V} - Distance {vertice.Distance}");
}

foreach (var each in bfs.PathTo(5))
{
    Console.Write(each + " ");
}
```

### DepthFirstSearch
```c#
UndirectedGraph graph = new UndirectedGraph(6);
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(0, 5);
graph.AddEdge(1, 2);
graph.AddEdge(2, 3);
graph.AddEdge(2, 4);
graph.AddEdge(3, 4);
graph.AddEdge(3, 5);

Console.WriteLine(graph.ToString());

DepthFirstSearch dfs = new DepthFirstSearch();
Vertex[] vertices = dfs.Execute(graph, 0);
foreach (var vertice in vertices)
{
    Console.WriteLine($"Vertice: {vertice.V} - Distance {vertice.Distance} - Time {vertice.FinishTime}");
}

foreach (var each in dfs.PathTo(5))
{
    Console.Write(each + " ");
}
```

### Capitals BFS
```c#
CapitalsUndirectedGraph graph = new CapitalsUndirectedGraph(27);
graph.AddEdge(1, 2, 376);
graph.AddEdge(2, 3, 305);
graph.AddEdge(3, 8, 991);
graph.AddEdge(3, 4, 408);
graph.AddEdge(4, 5, 429);
graph.AddEdge(4, 7, 586);
graph.AddEdge(4, 8, 1014);
graph.AddEdge(5, 6, 521);
graph.AddEdge(5, 7, 434);
graph.AddEdge(6, 7, 524);
graph.AddEdge(7, 10, 906);
graph.AddEdge(7, 11, 716);
graph.AddEdge(7, 8, 1358);
graph.AddEdge(7, 12, 1372);
graph.AddEdge(8, 9, 694);
graph.AddEdge(8, 10, 935);
graph.AddEdge(9, 10, 934);
graph.AddEdge(9, 22, 1451);
graph.AddEdge(9, 24, 2145);
graph.AddEdge(9, 26, 2008);
graph.AddEdge(9, 21, 1270);
graph.AddEdge(10, 12, 1425);
graph.AddEdge(10, 21, 874);
graph.AddEdge(10, 11, 209);
graph.AddEdge(12, 6, 1202);
graph.AddEdge(12, 13, 356);
graph.AddEdge(12, 14, 631);
graph.AddEdge(12, 15, 839);
graph.AddEdge(12, 19, 994);
graph.AddEdge(12, 21, 1323);
graph.AddEdge(13, 14, 294);
graph.AddEdge(14, 15, 256);
graph.AddEdge(15, 19, 994);
graph.AddEdge(15, 18, 629);
graph.AddEdge(15, 16, 120);
graph.AddEdge(16, 17, 185);
graph.AddEdge(16, 18, 702);
graph.AddEdge(17, 18, 553);
graph.AddEdge(18, 19, 634);
graph.AddEdge(19, 20, 946);
graph.AddEdge(19, 21, 1163);
graph.AddEdge(20, 21, 1599);
graph.AddEdge(20, 26, 806);
graph.AddEdge(21, 26, 1323);
graph.AddEdge(22, 24, 759);
graph.AddEdge(22, 23, 511);
graph.AddEdge(23, 24, 1145);
graph.AddEdge(24, 25, 785);
graph.AddEdge(24, 26, 529);
graph.AddEdge(25, 26, 1318);
graph.AddEdge(26, 0, 329);

Console.WriteLine(graph.ToString());

CapitalsBreadthFirstSearch bfs = new CapitalsBreadthFirstSearch();
Vertex[] vertices = bfs.Execute(graph, 7);

foreach (var vertice in vertices)
{
    Console.WriteLine($"Vertice: {vertice.V} - Distance {vertice.Distance}");
}

foreach (var each in bfs.PathTo(1))
{
    Console.Write(each + " ");
}
```

# Graphs MST

## Kruskal
```c#
WeightedGraph wg = new WeightedGraph(9);

wg.AddEdge(new Edge(0, 1, 4));
wg.AddEdge(new Edge(0, 7, 8));
wg.AddEdge(new Edge(1, 7, 11));
wg.AddEdge(new Edge(1, 2, 8));
wg.AddEdge(new Edge(7, 8, 7));
wg.AddEdge(new Edge(7, 6, 1));
wg.AddEdge(new Edge(8, 6, 6));
wg.AddEdge(new Edge(8, 2, 2));
wg.AddEdge(new Edge(2, 3, 7));
wg.AddEdge(new Edge(2, 5, 4));
wg.AddEdge(new Edge(6, 5, 2));
wg.AddEdge(new Edge(3, 5, 14));
wg.AddEdge(new Edge(3, 4, 9));
wg.AddEdge(new Edge(5, 4, 10));
Console.WriteLine(wg.ToString());

Kruskal kruskal = new Kruskal(wg);
var queue = kruskal.Mst;
foreach (var edge in queue)
{
    Console.WriteLine(edge.ToString());
}
Console.WriteLine(kruskal.Weight);
```

## Prim 
```c#
WeightedGraph wg = new WeightedGraph(9);

wg.AddEdge(new Edge(0, 1, 4));
wg.AddEdge(new Edge(0, 7, 8));
wg.AddEdge(new Edge(1, 7, 11));
wg.AddEdge(new Edge(1, 2, 8));
wg.AddEdge(new Edge(7, 8, 7));
wg.AddEdge(new Edge(7, 6, 1));
wg.AddEdge(new Edge(8, 6, 6));
wg.AddEdge(new Edge(8, 2, 2));
wg.AddEdge(new Edge(2, 3, 7));
wg.AddEdge(new Edge(2, 5, 4));
wg.AddEdge(new Edge(6, 5, 2));
wg.AddEdge(new Edge(3, 5, 14));
wg.AddEdge(new Edge(3, 4, 9));
wg.AddEdge(new Edge(5, 4, 10));
Console.WriteLine(wg.ToString());

Prim prim = new Prim(wg, 0);
var queue = prim.Mst;
foreach (var edge in queue)
{
    Console.WriteLine(edge.ToString());
}
Console.WriteLine(prim.Weight);
```

## Example

**Graph**

![](/img/graph1.jpg)

```c#
WeightedGraph wg = new WeightedGraph(12);
wg.AddEdge(new Edge(0, 1, 3));
wg.AddEdge(new Edge(0, 2, 7));
wg.AddEdge(new Edge(0, 9, 10));
wg.AddEdge(new Edge(1, 2, 11));
wg.AddEdge(new Edge(1, 3, 9));
wg.AddEdge(new Edge(2, 5, 23));
wg.AddEdge(new Edge(1, 4, 15));
wg.AddEdge(new Edge(3, 5, 13));
wg.AddEdge(new Edge(4, 7, 19));
wg.AddEdge(new Edge(5, 4, 21));
wg.AddEdge(new Edge(5, 7, 29));
wg.AddEdge(new Edge(5, 8, 33));
wg.AddEdge(new Edge(6, 4, 17));
wg.AddEdge(new Edge(6, 7, 25));
wg.AddEdge(new Edge(7, 8, 31));
wg.AddEdge(new Edge(8, 6, 27));
wg.AddEdge(new Edge(8, 10, 2));
wg.AddEdge(new Edge(9, 10, 4));
wg.AddEdge(new Edge(10, 11, 9));
wg.AddEdge(new Edge(11, 5, 8));

Console.WriteLine(wg.ToString());

Prim prim = new Prim(wg, 0);
var queue = prim.Mst;
foreach (var edge in queue)
{
    Console.WriteLine(edge.ToString());
}
Console.WriteLine(prim.Weight);

Kruskal kruskal = new Kruskal(wg);
var queue = kruskal.Mst;
foreach (var edge in queue)
{
    Console.WriteLine(edge.ToString());
}
Console.WriteLine(kruskal.Weight);
```

# Graph Shortest Path

## Dijkstra

![](/img/graph2.png)

```c#
WeightedDirectedGraph graph = new WeightedDirectedGraph(5);
graph.AddEdge(new DirectedEdge(0, 1, 10));
graph.AddEdge(new DirectedEdge(0, 2, 5));
graph.AddEdge(new DirectedEdge(1, 2, 2));
graph.AddEdge(new DirectedEdge(1, 3, 1));
graph.AddEdge(new DirectedEdge(2, 1, 3));
graph.AddEdge(new DirectedEdge(2, 3, 9));
graph.AddEdge(new DirectedEdge(2, 4, 2));
graph.AddEdge(new DirectedEdge(3, 4, 4));
graph.AddEdge(new DirectedEdge(4, 0, 7));
graph.AddEdge(new DirectedEdge(4, 3, 6));
Console.WriteLine(graph);

Dijkstra dijkstra = new Dijkstra(graph, 0);
int destination = 3;
foreach (var each in dijkstra.PathTo(destination))
{
    Console.Write($"{each} ");
}

Console.WriteLine($"Distance: {dijkstra.Distance(destination)}");
```

## Bellman-Ford

- Without negative cycles

![](/img/graph3.png)

```c#
WeightedDirectedGraph graph = new WeightedDirectedGraph(5);
graph.AddEdge(new DirectedEdge(0, 1, 6));
graph.AddEdge(new DirectedEdge(0, 2, 7));
graph.AddEdge(new DirectedEdge(1, 2, 8));
graph.AddEdge(new DirectedEdge(1, 4, -4));
graph.AddEdge(new DirectedEdge(2, 3, -3));
graph.AddEdge(new DirectedEdge(3, 1, -2));
graph.AddEdge(new DirectedEdge(4, 3, 7));
Console.WriteLine(graph);

BellmanFord bellmanFord = new BellmanFord();
int destination = 4;
if (bellmanFord.Execute(graph, 0))
{
    foreach (var each in bellmanFord.PathTo(destination))
    {
        Console.Write($"{each} ");
    }

    Console.WriteLine($"Distance: {bellmanFord.Distance(destination)}");
}
else
{
    Console.WriteLine("[Error] Negative cycles");
}
```

- Trying negative cycles (should give an **error**)

![](/img/graph4.png)

```c#
WeightedDirectedGraph graph = new WeightedDirectedGraph(5);
graph.AddEdge(new DirectedEdge(0, 2, 7));
graph.AddEdge(new DirectedEdge(1, 0, -6));
graph.AddEdge(new DirectedEdge(1, 2, 8));
graph.AddEdge(new DirectedEdge(1, 4, -4));
graph.AddEdge(new DirectedEdge(2, 3, -3));
graph.AddEdge(new DirectedEdge(3, 1, -2));
graph.AddEdge(new DirectedEdge(4, 3, 7));
Console.WriteLine(graph);

BellmanFord bellmanFord = new BellmanFord();
int destination = 3;
if (bellmanFord.Execute(graph, 0))
{
    foreach (var each in bellmanFord.PathTo(destination))
    {
        Console.Write($"{each} ");
    }

    Console.WriteLine($"Distance: {bellmanFord.Distance(destination)}");
}
else
{
    Console.WriteLine("[Error] Negative cycles");
}
```

# Topological Sort

![](/img/graph5.png)
![](/img/graph6.png)

```c#
string[] pecas =
        { "cueca", "calça", "cinto", "camisa", "gravata", "paletó", "meias", "sapatos", "relógio" };
            
DirectedGraph graph = new DirectedGraph(9);
graph.AddEdge(0, 1);
graph.AddEdge(1, 2);
graph.AddEdge(0, 7);
graph.AddEdge(1, 7);
graph.AddEdge(1, 2);
graph.AddEdge(6, 7);
graph.AddEdge(3, 2);
graph.AddEdge(3, 4);
graph.AddEdge(4, 5);
graph.AddEdge(2, 8);
graph.AddEdge(8, 5);
Console.WriteLine(graph);

TopologicalSort.TopologicalSort tr = new TopologicalSort.TopologicalSort(graph, 0);

foreach (var vertex in tr.Order)
{
    Console.WriteLine($"{pecas[vertex.V]}: ({vertex.Distance} / {vertex.FinishTime})");
}
```

# Connected Component

![](/img/graph7.png)

```c#
Graph graph = new UndirectedGraph(4);
graph.AddEdge(0, 1);
graph.AddEdge(1, 2);

Console.WriteLine(graph);

ConnectedComponent cc = new ConnectedComponent(graph);

int m = cc.Count;
Console.WriteLine($"Components: {m}");

Queue<int>[] q = new Queue<int>[m];

for (int i = 0; i < m; i++)
{
    q[i] = new Queue<int>();
}

for (int i = 0; i < graph.V; i++)
{
    q[cc.GetIdByPosition(i)].Enqueue(i);
}

for (int i = 0; i < m; i++)
{
    foreach (var component in q[i])
    {
        Console.Write($"{component} ");
    }
    Console.WriteLine();
}
```

# Strongly Connected Component

Before processed (using this [file](TopologicalSortAndConnectedComponent/graphScc.txt))

![](/img/graph8.png)

Result (5 strong components)

![](/img/graph9.png)

```c#
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
```
// <copyright file="Graph.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// A module for working with an undirected graph.
/// </summary>
public class Graph
{
    private Dictionary<int, HashSet<(int Neighbor, int EdgeWeight)>> adjacencyList;

    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/> class.
    /// </summary>
    public Graph()
    {
        this.adjacencyList = new Dictionary<int, HashSet<(int, int)>>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/> class using a file.
    /// </summary>
    /// <param name="filePath">Your file path.</param>
    public Graph(string filePath)
    {
        this.adjacencyList = new Dictionary<int, HashSet<(int, int)>>();
        this.LoadFromFile(filePath);
    }

    /// <summary>
    /// Saves the graph to a file in the format "vertex: neighbor(bandwidth), ...".
    /// </summary>
    /// <param name="filePath">The path to the file to save.</param>
    public void SaveToFile(string filePath)
    {
        using var writer = new StreamWriter(filePath);

        var sortedVertices = this.adjacencyList.Keys.OrderBy(v => v);

        foreach (var vertex in sortedVertices)
        {
            var sortedNeighbors = this.adjacencyList[vertex]
                .OrderBy(connection => connection.Neighbor)
                .Select(connection => $"{connection.Neighbor} ({connection.EdgeWeight})");

            writer.WriteLine($"{vertex}: {string.Join(", ", sortedNeighbors)}");
        }
    }

    /// <summary>
    /// Generates the maximum spanning tree for a given graph.
    /// </summary>
    /// <returns>The maximum spanning tree.</returns>
    /// <exception cref="GraphNotConnectedException">If the graph is not connected, the tree cannot be distinguished.</exception>
    public Graph GetMaximumSpanningTree()
    {
        if (!this.IsConnected())
        {
            throw new GraphNotConnectedException();
        }

        var sortedEdges = this.SortEdges();

        Dictionary<int, int> parent = new();
        foreach (var vertex in this.adjacencyList.Keys)
        {
            parent[vertex] = vertex;
        }

        var mst = new Graph();
        foreach (var (from, to, edgeWeight) in sortedEdges)
        {
            var rootFrom = Find(from);
            var rootTo = Find(to);
            if (rootFrom == rootTo)
            {
                continue;
            }

            parent[rootTo] = rootFrom;
            mst.AddEdge(from, to, edgeWeight);
        }

        return mst;

        int Find(int x) => parent[x] == x ? x : (parent[x] = Find(parent[x]));
    }

    /// <summary>
    /// Adds a vertex to the graph.
    /// </summary>
    /// <param name="vertex">The vertex number.</param>
    public void AddVertex(int vertex)
    {
        if (!this.adjacencyList.ContainsKey(vertex))
        {
            this.adjacencyList[vertex] = new HashSet<(int, int)>();
        }
    }

    /// <summary>
    /// Adds an edge between two vertices (if there are no vertices in the graph yet, these vertices will be created automatically).
    /// </summary>
    /// <param name="from">First vertex.</param>
    /// <param name="to">Second vertex.</param>
    /// <param name="edgeWeight">Edge weight.</param>
    public void AddEdge(int from, int to, int edgeWeight)
    {
        if (!this.adjacencyList.ContainsKey(from))
        {
            this.AddVertex(from);
        }

        if (!this.adjacencyList.ContainsKey(to))
        {
            this.AddVertex(to);
        }

        this.adjacencyList[from].Add((to, edgeWeight));
        this.adjacencyList[to].Add((from, edgeWeight));
    }

    /// <summary>
    /// Checking if there is an edge between two vertices.
    /// </summary>
    /// <param name="firstVertex">First vertex.</param>
    /// <param name="secondVertex">Second vertex.</param>
    /// <returns>True if the edge exists.</returns>
    public bool HasEdge(int firstVertex, int secondVertex)
    {
        if (!this.adjacencyList.ContainsKey(firstVertex) || !this.adjacencyList.ContainsKey(secondVertex))
        {
            return false;
        }

        foreach (var (neighbor, _) in this.adjacencyList[firstVertex])
        {
            if (neighbor == secondVertex)
            {
                return true;
            }
        }

        return false;
    }

    private void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Graph file not found: {filePath}");
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
            {
                continue;
            }

            var parts = line.Split(':');
            if (parts.Length != 2)
            {
                throw new FormatException($"Invalid line format: {line}");
            }

            if (!int.TryParse(parts[0].Trim(), out var vertex))
            {
                throw new FormatException($"Invalid vertex number: {parts[0]}");
            }

            if (!this.adjacencyList.ContainsKey(vertex))
            {
                this.adjacencyList[vertex] = new HashSet<(int, int)>();
            }

            var connections = parts[1].Split(',');
            foreach (var connection in connections)
            {
                var trimmed = connection.Trim();
                if (string.IsNullOrEmpty(trimmed))
                {
                    continue;
                }

                var bracketStart = trimmed.IndexOf('(');
                var bracketEnd = trimmed.IndexOf(')');

                if (bracketStart < 0 || bracketEnd < 0 || bracketEnd <= bracketStart)
                {
                    throw new FormatException($"Invalid connection format: {trimmed}");
                }

                var stringNeighbor = trimmed[..bracketStart].Trim();
                var stringBandwidth = trimmed.Substring(bracketStart + 1, bracketEnd - bracketStart - 1).Trim();

                if (!int.TryParse(stringNeighbor, out var neighbor) ||
                    !int.TryParse(stringBandwidth, out var bandwidth))
                {
                    throw new FormatException($"Invalid connection values: {trimmed}");
                }

                this.AddEdge(vertex, neighbor, bandwidth);
            }
        }
    }

    private bool IsConnected()
    {
        if (this.adjacencyList.Count == 0)
        {
            return false;
        }

        HashSet<int> visited = [];
        if (visited == null)
        {
            throw new ArgumentNullException(nameof(visited));
        }

        Queue<int> queue = [];
        if (queue == null)
        {
            throw new ArgumentNullException(nameof(queue));
        }

        var startVertex = this.adjacencyList.Keys.First();

        queue.Enqueue(startVertex);
        visited.Add(startVertex);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var (neighbor, _) in this.adjacencyList[current])
            {
                if (visited.Add(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return visited.Count == this.adjacencyList.Count;
    }

    private List<(int From, int To, int EdgeWeight)> SortEdges()
    {
        List<(int From, int To, int EdgeWeight)> edges = [];

        foreach (var vertex in this.adjacencyList.Keys)
        {
            foreach (var (neighbor, edgeWeight) in this.adjacencyList[vertex])
            {
                if (vertex < neighbor)
                {
                    edges.Add((vertex, neighbor, edgeWeight));
                }
            }
        }

        edges.Sort((a, b) => b.EdgeWeight.CompareTo(a.EdgeWeight));
        return edges;
    }
}
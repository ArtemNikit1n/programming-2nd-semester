// <copyright file="GraphTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers.Tests;

/// <summary>
/// Tests for the graph.
/// </summary>
public class GraphTests
{
    private Graph normalGraph;
    private Graph disconnectedGraph;
    private Graph emptyGraph;

    /// <summary>
    /// Graph initialization.
    /// </summary>
    [SetUp]
    public void GraphInitialization()
    {
        var categories = TestContext.CurrentContext.Test.Properties["Category"];

        var enumerable = categories.ToList();
        if (enumerable.Contains("Normal graph"))
        {
            this.normalGraph = new Graph();

            this.normalGraph.AddVertex(1);
            this.normalGraph.AddVertex(2);
            this.normalGraph.AddVertex(3);

            this.normalGraph.AddEdge(1, 2, 10);
            this.normalGraph.AddEdge(1, 3, 5);
            this.normalGraph.AddEdge(2, 3, 1);
        }
        else if (enumerable.Contains("Disconnected graph"))
        {
            this.disconnectedGraph = new Graph();

            this.disconnectedGraph.AddVertex(1);
            this.disconnectedGraph.AddVertex(2);
            this.disconnectedGraph.AddVertex(3);
            this.disconnectedGraph.AddVertex(4);

            this.disconnectedGraph.AddEdge(1, 2, 10);
            this.disconnectedGraph.AddEdge(1, 3, 5);
            this.disconnectedGraph.AddEdge(2, 3, 1);
        }
        else if (enumerable.Contains("Empty graph"))
        {
            this.emptyGraph = new Graph();
        }
    }

    /// <summary>
    /// GetMaximumSpanningTree should return the maximum graph without cycles.
    /// </summary>
    [Test]
    [Category("Normal graph")]
    public void GetMaximumSpanningTree_ShouldReturnMaximumGraphWithoutCycles()
    {
        var resultGraph = this.normalGraph.GetMaximumSpanningTree();
        Assert.Multiple(() =>
        {
            Assert.That(resultGraph.HasEdge(1, 2), Is.True);
            Assert.That(resultGraph.HasEdge(1, 3), Is.True);
            Assert.That(resultGraph.HasEdge(2, 3), Is.False);
        });
    }

    /// <summary>
    /// GetMaximumSpanningTree should raise an exception for a disjoint graph.
    /// </summary>
    [Test]
    [Category("Disconnected graph")]
    public void GetMaximumSpanningTree_ShouldRaiseExceptionForDisjointGraph()
    {
        Assert.Throws<GraphNotConnectedException>(() => this.disconnectedGraph.GetMaximumSpanningTree());
    }

    /// <summary>
    /// GetMaximumSpanningTree should raise an exception for empty graph.
    /// </summary>
    [Test]
    [Category("Empty graph")]
    public void GetMaximumSpanningTree_ShouldRaiseExceptionForEmptyGraph()
    {
        Assert.Throws<GraphNotConnectedException>(() => this.emptyGraph.GetMaximumSpanningTree());
    }

    /// <summary>
    /// SaveToFile should record the same graph as when uploading.
    /// </summary>
    [Test]
    public void SaveToFile_ShouldRecordSameGraphAsWhenUploading()
    {
        const string expectedPath = "../../../TestData/Expected.txt";
        const string resultPath = "../../../TestData/Result.txt";

        Graph graph = new(expectedPath);
        graph.SaveToFile(resultPath);
        Assert.That(AreTextFilesEqual(expectedPath, resultPath), Is.True);
    }

    private static bool AreTextFilesEqual(string filePath1, string filePath2)
    {
        var lines1 = File.ReadLines(filePath1);
        var lines2 = File.ReadLines(filePath2);

        return lines1.SequenceEqual(lines2, StringComparer.Ordinal);
    }
}
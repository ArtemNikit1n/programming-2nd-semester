// <copyright file="GraphTests.cs" company="PlaceholderCompany">
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

            this.normalGraph.AddVertex(1);
            this.normalGraph.AddVertex(2);
            this.normalGraph.AddVertex(3);
            this.normalGraph.AddVertex(4);

            this.normalGraph.AddEdge(1, 2, 10);
            this.normalGraph.AddEdge(1, 3, 5);
            this.normalGraph.AddEdge(2, 3, 1);
        }
    }

    /// <summary>
    /// Get maximum spanning tree should return maximum graph without cycles.
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
}
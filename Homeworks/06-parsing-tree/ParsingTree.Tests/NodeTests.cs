// <copyright file="NodeTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: ComVisible(true)]
[assembly: CLSCompliant(true)]

namespace ParsingTree.Tests;

/// <summary>
/// Tests for tree.
/// </summary>
public class NodeTests
{
    private Node root;

    /// <summary>
    /// Creates the root of the tree.
    /// </summary>
    [SetUp]
    public void CreateTree()
    {
        this.root = new Node(0);
    }

    /// <summary>
    /// AddLeft should add left son.
    /// </summary>
    [Test]
    public void AddLeft_ShouldAddLeftSon()
    {
        const int leftSonValue = -100;
        this.root.AddLeft(new Node(leftSonValue));
        Assert.That(this.root.Left.Value, Is.EqualTo(leftSonValue));
    }

    /// <summary>
    /// AddRight should add left son.
    /// </summary>
    [Test]
    public void AddRight_ShouldAddRightSon()
    {
        const int rightSonValue = 100;
        this.root.AddRight(new Node(rightSonValue));
        Assert.That(this.root.Right.Value, Is.EqualTo(rightSonValue));
    }
}
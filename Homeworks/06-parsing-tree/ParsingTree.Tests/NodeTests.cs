// <copyright file="NodeTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
        this.root = new Node("0");
    }

    /// <summary>
    /// AddLeft should add left son.
    /// </summary>
    [Test]
    public void AddLeft_ShouldAddLeftSon()
    {
        const string leftSonValue = "123";
        this.root.AddLeft(new Node(leftSonValue));
        var rootLeft = this.root.Left;
        if (rootLeft != null)
        {
            Assert.That(rootLeft.Value, Is.EqualTo(leftSonValue));
        }
    }

    /// <summary>
    /// AddRight should add left son.
    /// </summary>
    [Test]
    public void AddRight_ShouldAddRightSon()
    {
        const string rightSonValue = "abc";
        this.root.AddRight(new Node(rightSonValue));
        var rootRight = this.root.Right;
        if (rootRight != null)
        {
            Assert.That(rootRight.Value, Is.EqualTo(rightSonValue));
        }
    }
}
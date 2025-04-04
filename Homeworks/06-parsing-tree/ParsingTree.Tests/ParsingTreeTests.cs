// <copyright file="ParsingTreeTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree.Tests;

/// <summary>
/// Tests for the parse tree.
/// </summary>
public class ParsingTreeTests
{
    /// <summary>
    /// Create should create a valid tree for a single operation.
    /// </summary>
    [Test]
    public void Create_ShouldCreateValidTreeForSingleOperation()
    {
        var root = ParsingTree.Create("1 + 3");
        Assert.Multiple(() =>
        {
            Assert.That(root.Value, Is.EqualTo("+"));
            Assert.That(root.Left!.Value, Is.EqualTo("1"));
            Assert.That(root.Right!.Value, Is.EqualTo("3"));
        });
    }

    /// <summary>
    /// Create should create a valid tree for negative operands.
    /// </summary>
    [Test]
    public void Create_ShouldCreateValidTreeForNegativeOperands()
    {
        var root = ParsingTree.Create("-1 * -3");
        Assert.Multiple(() =>
        {
            Assert.That(root.Value, Is.EqualTo("*"));
            Assert.That(root.Left!.Value, Is.EqualTo("-1"));
            Assert.That(root.Right!.Value, Is.EqualTo("-3"));
        });
    }

    /// <summary>
    /// Create should create a valid tree for an expression with parentheses.
    /// </summary>
    [Test]
    public void Create_ShouldCreateValidTreeForExpressionWithParentheses()
    {
        var root = ParsingTree.Create("(3 + 5) * (7 - 2)");
        Assert.Multiple(() =>
        {
            Assert.That(root.Value, Is.EqualTo("*"));
            Assert.That(root.Left!.Value, Is.EqualTo("+"));
            Assert.That(root.Left!.Left!.Value, Is.EqualTo("3"));
            Assert.That(root.Left!.Right!.Value, Is.EqualTo("5"));
            Assert.That(root.Right!.Value, Is.EqualTo("-"));
            Assert.That(root.Right!.Right!.Value, Is.EqualTo("2"));
            Assert.That(root.Right!.Left!.Value, Is.EqualTo("7"));
        });
    }

    /// <summary>
    /// Create should throw an exception for incorrect parenthesis placement.
    /// </summary>
    [Test]
    public void Create_ShouldThrowAnExceptionForIncorrectParenthesisPlacement()
    {
        Assert.Throws<ArgumentException>(() => ParsingTree.Create(") 2 + 3"));
        Assert.Throws<ArgumentException>(() => ParsingTree.Create("2 + 3("));
        Assert.Throws<ArgumentException>(() => ParsingTree.Create("2 + ) 3"));
        Assert.Throws<ArgumentException>(() => ParsingTree.Create("2( + 3"));
        Assert.Throws<ArgumentException>(() => ParsingTree.Create("((2) + 3"));
        Assert.Throws<ArgumentException>(() => ParsingTree.Create("2 + ))3"));
    }
}
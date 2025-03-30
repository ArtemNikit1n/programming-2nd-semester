// <copyright file="Node.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: ComVisible(true)]
[assembly: CLSCompliant(true)]

namespace ParsingTree;


    /// <summary>
    /// The node of the tree.
    /// </summary>
    /// <param name="value">The value set in the node.</param>
public class Node(int value)
{
    /// <summary>
    /// Gets or sets a field for storing information about a node.
    /// </summary>
    public int Value { get; set; } = value;

    /// <summary>
    /// Gets or sets a field for storing information about a left child.
    /// </summary>
    public Node? Left { get; set; }

    /// <summary>
    /// Gets or sets a field for storing information about a right child.
    /// </summary>
    public Node? Right { get; set; }

    /// <summary>
    /// Adds the left son to the current node.
    /// </summary>
    /// <param name="leftNode">The node to add.</param>
    public void AddLeft(Node leftNode)
        => this.Left = leftNode;

    /// <summary>
    /// Adds the right son to the current node.
    /// </summary>
    /// <param name="rightNode">The node to add.</param>
    public void AddRight(Node rightNode)
        => this.Right = rightNode;
}
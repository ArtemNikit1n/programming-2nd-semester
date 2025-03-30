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
        this.root.AddLeft(new Node(-100));
        Assert.That(this.root.Left.Value, Is.EqualTo(-100));
    }

    /// <summary>
    /// AddRight should add left son.
    /// </summary>
    [Test]
    public void AddRight_ShouldAddRightSon()
    {
        this.root.AddRight(new Node(100));
        Assert.That(this.root.Right.Value, Is.EqualTo(100));
    }
}
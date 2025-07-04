// <copyright file="PriorityQueueTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueue.Tests;

/// <summary>
/// Tests for PriorityQueue.
/// </summary>
public class PriorityQueueTests
{
    private PriorityQueue queue;

    /// <summary>
    /// Creates a queue for each test.
    /// </summary>
    [SetUp]
    public void CreateQueue()
    {
        this.queue = new PriorityQueue(4);
    }

    /// <summary>
    /// The dequeue should throw an exception for an empty queue.
    /// </summary>
    [Test]
    public void Dequeue_ShouldThrowExceptionForEmptyQueue()
    {
        Assert.Throws<InvalidOperationException>(() => this.queue.Dequeue());
    }

    /// <summary>
    /// Enqueue Should add an item to the queue.
    /// </summary>
    [Test]
    public void Enqueue_ShouldAddItemToQueue()
    {
        this.queue.Enqueue(10, 1);
        Assert.That(this.queue.Dequeue(), Is.EqualTo(10));
    }

    /// <summary>
    /// Enqueue Should add an item to the queue (multiply).
    /// </summary>
    [Test]
    public void Enqueue_ShouldAddItemToQueue_Multiply()
    {
        this.queue.Enqueue(100, 1);
        this.queue.Enqueue(200, 3);
        this.queue.Enqueue(300, 3);
        this.queue.Enqueue(400, 2);

        Assert.That(this.queue.Dequeue(), Is.EqualTo(200));
        Assert.That(this.queue.Dequeue(), Is.EqualTo(300));
        Assert.That(this.queue.Dequeue(), Is.EqualTo(400));
        Assert.That(this.queue.Dequeue(), Is.EqualTo(100));
    }

    /// <summary>
    /// Empty Should return true for an empty queue.
    /// </summary>
    [Test]
    public void Empty_ShouldReturnTrueForEmptyQueue()
    {
        Assert.That(this.queue.Empty, Is.True);
    }

    /// <summary>
    /// Empty Should return false for a non-empty queue.
    /// </summary>
    [Test]
    public void Empty_ShouldReturnFalseForNonEmptyQueue()
    {
        this.queue.Enqueue(100, 1);
        Assert.That(this.queue.Empty, Is.False);
    }
}
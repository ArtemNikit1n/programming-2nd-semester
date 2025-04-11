// <copyright file="PriorityQueue.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PriorityQueue;

/// <summary>
/// A queue with priorities.
/// If the priorities of the items are equal, they are returned in the order in which they entered the queue.
/// </summary>
public class PriorityQueue
{
    private QueueItem[] heap;
    private int size;
    private int capacity;
    private int counterTrackingOrderAdditions;

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityQueue"/> class.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity of the queue.</param>
    public PriorityQueue(int initialCapacity)
    {
        this.size = 0;
        this.capacity = initialCapacity;
        this.heap = new QueueItem[initialCapacity];
        this.counterTrackingOrderAdditions = 0;
    }

    /// <summary>
    /// Gets a value indicating whether returns true if the queue is empty.
    /// </summary>
    public bool Empty => this.size == 0;

    /// <summary>
    /// Adds a value to the queue by priority.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    /// <param name="priority">The priority of the element.</param>
    public void Enqueue(int value, int priority)
    {
        if (this.size == this.capacity)
        {
            this.Resize();
        }

        this.heap[this.size] = new QueueItem(value, priority, this.counterTrackingOrderAdditions++);
        this.SiftUp(this.size);
        this.size++;
    }

    /// <summary>
    /// Deletes the last added item with the highest priority from the queue.
    /// </summary>
    /// <returns>The value of the last added element with the highest priority.</returns>
    /// <exception cref="InvalidOperationException">An item cannot be retrieved from an empty queue.</exception>
    public int Dequeue()
    {
        if (this.Empty)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var value = this.heap[0].Value;
        this.heap[0] = this.heap[this.size - 1];
        this.size--;
        this.SiftDown(0);
        return value;
    }

    private void SiftUp(int index)
    {
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;

            if (this.heap[index].Priority < this.heap[parentIndex].Priority ||
                (this.heap[index].Priority == this.heap[parentIndex].Priority &&
                 this.heap[index].InsertionOrder > this.heap[parentIndex].InsertionOrder))
            {
                break;
            }

            this.Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void SiftDown(int index)
    {
        while (true)
        {
            var leftChild = (2 * index) + 1;
            var rightChild = (2 * index) + 2;
            var largest = index;

            if (leftChild < this.size &&
                (this.heap[leftChild].Priority > this.heap[largest].Priority ||
                 (this.heap[leftChild].Priority == this.heap[largest].Priority &&
                  this.heap[leftChild].InsertionOrder < this.heap[largest].InsertionOrder)))
            {
                largest = leftChild;
            }

            if (rightChild < this.size &&
                (this.heap[rightChild].Priority > this.heap[largest].Priority ||
                 (this.heap[rightChild].Priority == this.heap[largest].Priority &&
                  this.heap[rightChild].InsertionOrder < this.heap[largest].InsertionOrder)))
            {
                largest = rightChild;
            }

            if (largest == index)
            {
                break;
            }

            this.Swap(index, largest);
            index = largest;
        }
    }

    private void Resize()
    {
        this.capacity *= 2;
        var newHeap = new QueueItem[this.capacity];
        Array.Copy(this.heap, newHeap, this.size);
        this.heap = newHeap;
    }

    private void Swap(int i, int j)
    {
        (this.heap[i], this.heap[j]) = (this.heap[j], this.heap[i]);
    }

    private struct QueueItem(int value, int priority, int insertionOrder)
    {
        public int Value { get; private set; } = value;

        public int Priority { get; private set; } = priority;

        public long InsertionOrder { get; private set; } = insertionOrder;
    }
}
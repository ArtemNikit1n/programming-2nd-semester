// <copyright file="SkipList.cs" company="ArtemNikit1n">
// Copyright (c) ArtemNikit1n. All rights reserved.
// </copyright>

namespace SkipList;

using System.Collections;

/// <summary>
/// A probabilistic data structure that allows for O(log(n) average search complexity,
/// as well as O(log n) average insertion complexity.
/// </summary>
/// <typeparam name="T">Type of list item.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private const double Probability = 0.5;

    private readonly Random random = new();

    private SkipListNode head = new(default!, 0);
    private int maxLevel;
    private int version;

    /// <inheritdoc/>
    public int Count { get; private set; }

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var currentNode = this.head.Next[0];
            var currentIndex = 0;

            while (currentIndex != index)
            {
                if (currentNode == null)
                {
                    throw new InvalidOperationException("Unexpected null node encountered.");
                }

                currentNode = currentNode.Next[0];
                currentIndex++;
            }

            if (currentNode == null)
            {
                throw new InvalidOperationException("Unexpected null node encountered.");
            }

            return currentNode.Value;
        }

        set => throw new NotSupportedException();
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        var initialVersion = this.version;
        var currentNode = this.head.Next[0];
        while (currentNode != null)
        {
            if (initialVersion != this.version)
            {
                throw new InvalidOperationException("Collection was modified during enumeration.");
            }

            yield return currentNode.Value;
            currentNode = currentNode.Next[0];
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    /// <inheritdoc/>
    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (this.AddToEmptyList(item))
        {
            return;
        }

        var newNodeLevel = this.GetRandomLevel();
        this.TryToExpandHead(newNodeLevel);

        SkipListNode newNode = new(item, newNodeLevel);

        var currentNode = this.head;

        var needToUpdate = new SkipListNode[newNodeLevel + 1];

        for (var level = newNodeLevel; level >= 0; level--)
        {
            while (currentNode.Next[level] is { } nextNode && nextNode.Value.CompareTo(item) < 0)
            {
                currentNode = nextNode;
            }

            needToUpdate[level] = currentNode;
        }

        for (var level = 0; level <= newNodeLevel; level++)
        {
            newNode.Next[level] = needToUpdate[level].Next[level];
            needToUpdate[level].Next[level] = newNode;
        }

        this.UpdateMaxLevelAndCounterAfterSuccessfulAddition(newNodeLevel);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        this.version = 0;
        this.head = new SkipListNode(default!, 0);
        this.maxLevel = 0;
        this.Count = 0;

        this.head.Next = new SkipListNode[1];
        this.head.Next[0] = null;
    }

    /// <inheritdoc/>
    public bool Contains(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var currentNode = this.head;

        for (var level = this.maxLevel; level >= 0; level--)
        {
            while (currentNode.Next[level] is { } nextNode && nextNode.Value.CompareTo(item) < 0)
            {
                currentNode = nextNode;
            }

            if (currentNode.Next[level] is { } foundNode && foundNode.Value.CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Array index cannot be negative");
        }

        if (array.Length - arrayIndex < this.Count)
        {
            throw new ArgumentException("There is not enough space in the target array");
        }

        if (this.head.Next[0] is null)
        {
            return;
        }

        var currentNode = this.head.Next[0];
        var i = arrayIndex;

        while (currentNode != null)
        {
            array[i++] = currentNode.Value;
            currentNode = currentNode.Next[0];
        }
    }

    /// <inheritdoc/>
    public bool Remove(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (this.head.Next[0] is null)
        {
            return false;
        }

        this.TryToExpandHead(this.maxLevel);
        var currentNode = this.head;
        SkipListNode? itemToDelete = null;
        var needToUpdate = new SkipListNode[this.maxLevel + 1];

        for (var level = this.maxLevel; level >= 0; level--)
        {
            while (currentNode.Next[level] is { } nextNode && nextNode.Value.CompareTo(item) < 0)
            {
                currentNode = nextNode;
            }

            needToUpdate[level] = currentNode;

            if (currentNode.Next[level] is { } potentialMatch && potentialMatch.Value.CompareTo(item) == 0)
            {
                itemToDelete = potentialMatch;
            }
        }

        if (itemToDelete is null)
        {
            return false;
        }

        for (var level = 0; level <= itemToDelete.Next.Length - 1; level++)
        {
            needToUpdate[level].Next[level] = itemToDelete.Next[level];
        }

        this.Count--;
        this.version++;
        return true;
    }

    /// <inheritdoc/>
    public int IndexOf(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var currentNode = this.head.Next[0];
        var index = 0;

        while (currentNode != null)
        {
            if (currentNode.Value.CompareTo(item) == 0)
            {
                return index;
            }

            currentNode = currentNode.Next[0];
            index++;
        }

        return -1;
    }

    /// <summary>
    /// The operation is not supported due to the fact that the list must be sorted.
    /// </summary>
    /// <param name="index">Not supported.</param>
    /// <param name="item">This element cannot be inserted.</param>
    /// <exception cref="NotSupportedException">It is thrown in case of an attempt to use it.</exception>
    public void Insert(int index, T item)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        this.TryToExpandHead(this.maxLevel);
        var currentNode = this.head.Next[0];
        var currentIndex = 0;
        while (currentIndex < index)
        {
            if (currentNode == null)
            {
                throw new InvalidOperationException("Unexpected null node encountered.");
            }

            currentNode = currentNode.Next[0];
            currentIndex++;
        }

        if (currentNode == null)
        {
            throw new InvalidOperationException("Unexpected null node encountered.");
        }

        for (var level = 0; level < currentNode.Next.Length; level++)
        {
            var updateNode = this.head;
            while (updateNode.Next[level] != null && updateNode.Next[level] != currentNode)
            {
                updateNode = updateNode.Next[level]!;
            }

            if (updateNode.Next[level] == currentNode)
            {
                updateNode.Next[level] = currentNode.Next[level];
            }
        }

        this.Count--;
        this.version++;
    }

    private static bool IsPowerOfTwo(int number)
        => (number & (number - 1)) == 0;

    private void UpdateMaxLevelAndCounterAfterSuccessfulAddition(int newNodeLevel)
    {
        this.maxLevel = Math.Max(this.maxLevel, newNodeLevel);
        if (IsPowerOfTwo(this.Count))
        {
            this.maxLevel++;
        }

        this.version++;
        this.Count++;
    }

    private bool AddToEmptyList(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (this.head.Next[0] is not null)
        {
            return false;
        }

        this.head.Next[0] = new SkipListNode(item, 0);
        this.maxLevel = 0;
        this.Count++;
        this.version++;
        return true;
    }

    private void TryToExpandHead(int newNodeLevel)
    {
        if (this.head.Next.Length > newNodeLevel)
        {
            return;
        }

        this.head.ExpandLevel(Math.Max(this.head.Next.Length, newNodeLevel + 1));
    }

    private int GetRandomLevel()
    {
        var level = 0;
        while (this.random.NextDouble() < Probability && level < this.maxLevel)
        {
            level++;
        }

        return level;
    }

    private class SkipListNode(T value, int level)
    {
        public T Value { get; } = value;

        public SkipListNode?[] Next { get; set; } = new SkipListNode[level + 1];

        public void ExpandLevel(int newLevel)
        {
            if (newLevel < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newLevel), "Level cannot be negative");
            }

            if (newLevel < this.Next.Length)
            {
                return;
            }

            var saveNext = this.Next;
            Array.Resize(ref saveNext, newLevel + 1);
            this.Next = saveNext;
        }
    }
}
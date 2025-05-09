// <copyright file="SkipList.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
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

    private SkipListNode? head = new(default!, 0);
    private int maxLevel;

    /// <inheritdoc/>
    public int Count { get; private set; }

    /// <inheritdoc/>
    public bool IsReadOnly { get; }

    /// <inheritdoc/>
    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <inheritdoc/>
    public void Add(T item)
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException("Collection is read-only");
        }

        if (item is null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

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
            while (currentNode!.Next[level] != null && currentNode.Next[level]!.Value.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next[level]!;
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
        this.head = new SkipListNode(default!, 0);
        this.maxLevel = 0;
        this.Count = 0;

        this.head.Next = new SkipListNode[1];
        this.head.Next[0] = null;
    }

    /// <inheritdoc/>
    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
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

        this.Count++;
    }

    private bool AddToEmptyList(T item)
    {
        if (this.head!.Next[0] is not null)
        {
            return false;
        }

        this.head!.Next[0] = new SkipListNode(item, 0);
        this.maxLevel = 0;
        this.Count++;
        return true;
    }

    private void TryToExpandHead(int newNodeLevel)
    {
        if (this.head!.Next.Length > newNodeLevel)
        {
            return;
        }

        this.head.ExpandLevel(Math.Max(this.head!.Next.Length, newNodeLevel + 1));
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
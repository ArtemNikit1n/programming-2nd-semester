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

    private SkipListNode head = new(default!, 0);
    private int maxLevel;

    /// <inheritdoc/>
    public int Count { get; private set; }

    /// <inheritdoc/>
    public bool IsReadOnly { get; }

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Valid range is [0, {this.Count - 1}]");
            }

            var currentNode = this.head.Next[0];
            var currentIndex = 0;

            while (currentIndex != index)
            {
                currentNode = currentNode!.Next[0];
                currentIndex++;
            }

            return currentNode!.Value;
        }

        set => throw new NotSupportedException();
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head.Next[0];
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next[0];
        }
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
            while (currentNode.Next[level] != null && currentNode.Next[level]!.Value.CompareTo(item) < 0)
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
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        var currentNode = this.head;

        for (var level = this.maxLevel; level >= 0; level--)
        {
            while (currentNode.Next[level] != null && currentNode.Next[level]!.Value.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next[level]!;
            }

            if (currentNode.Next[level] != null && currentNode.Next[level]!.Value.CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
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

        while (currentNode!.Next[0] != null)
        {
            array[i++] = currentNode.Value;
            currentNode = currentNode.Next[0];
        }
    }

    /// <inheritdoc/>
    public bool Remove(T item)
    {
        if (this.IsReadOnly)
        {
            throw new NotSupportedException("Collection is read-only");
        }

        if (item is null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        if (this.head.Next[0] is not null)
        {
            return false;
        }

        var currentNode = this.head;
        SkipListNode? itemToDelete = null;
        var needToUpdate = new SkipListNode[this.maxLevel + 1];

        for (var level = this.maxLevel; level >= 0; level--)
        {
            while (currentNode.Next[level] != null && currentNode.Next[level]!.Value.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next[level]!;
            }

            needToUpdate[level] = currentNode;

            if (currentNode.Next[level] != null && currentNode.Next[level]!.Value.CompareTo(item) == 0)
            {
                itemToDelete = currentNode.Next[level]!;
            }
        }

        if (itemToDelete is null)
        {
            return false;
        }

        for (var level = 0; level <= itemToDelete.Next.Length; level++)
        {
            needToUpdate[level].Next[level] = itemToDelete.Next[level];
        }

        this.Count--;
        return true;
    }

    /// <inheritdoc/>
    public int IndexOf(T item)
    {
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

    /// <inheritdoc/>
    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        throw new NotSupportedException();
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
        if (this.head.Next[0] is not null)
        {
            return false;
        }

        this.head.Next[0] = new SkipListNode(item, 0);
        this.maxLevel = 0;
        this.Count++;
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
#pragma warning disable SA1638
// <copyright file="SimpleListTests.cs" company="ArtemNikit1n">
#pragma warning restore SA1638
// Licensed under the MIT License. See LICENSE in the project root for details.
// Copyright (c) 2025 ArtemNikit1n. All rights reserved.
#pragma warning disable SA1512
// </copyright>
#pragma warning restore SA1512

namespace SimpleList;

using System.Collections;

/// <summary>
/// Represents a custom singly-linked list implementation.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class SimpleList<T> : IEnumerable<T>
{
    private ListElement? head;
    private ListElement? tail;
    private int version;

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>That can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    /// <exception cref="InvalidOperationException">If the collection is modified during enumeration.</exception>
    public IEnumerator<T> GetEnumerator()
    {
        var initialVersion = this.version;
        var currentElement = this.head;
        while (currentElement != null)
        {
            if (initialVersion != this.version)
            {
                throw new InvalidOperationException("The collection was changed during the enumeration.");
            }

            yield return currentElement.Value;
            currentElement = currentElement.Next;
        }
    }

    /// <summary>
    /// Adds an item to the end of the list.
    /// </summary>
    /// <param name="item">The item to add to the list.</param>
    public void Add(T item)
    {
        ListElement newElement = new(item);

        if (this.tail == null)
        {
            this.head = newElement;
        }
        else
        {
            this.tail.Next = newElement;
        }

        this.tail = newElement;
        this.version++;
    }

    private class ListElement(T value)
    {
        public T Value { get; } = value;

        public ListElement? Next { get; set; }
    }
}
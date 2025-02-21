// <copyright file="LinkedStack.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StackCalculator;

/// <summary>
/// Стек использующий ссылки.
/// </summary>
public class LinkedStack : IStack
{
    private StackElement? head;

    /// <inheritdoc/>
    public void Push(double value)
    {
        var newElement = new StackElement { Value = value, Next = this.head };
        this.head = newElement;
    }

    /// <inheritdoc/>
    public (double Value, bool IsError) Pop()
    {
        if (this.head is null)
        {
            return (0, true);
        }

        var currentValue = this.head.Value;
        this.head = this.head.Next;
        return (currentValue, false);
    }

    /// <inheritdoc/>
    public bool IsEmpty() => this.head == null;

    private class StackElement
    {
        public double Value { get; init; }

        public StackElement? Next { get; set; }
    }
}
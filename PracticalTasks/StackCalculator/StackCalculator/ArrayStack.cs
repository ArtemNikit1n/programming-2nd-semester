// <copyright file="ArrayStack.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StackCalculator;

/// <summary>
/// Стек на массивах.
/// </summary>
public class ArrayStack : IStack
{
    private double[] array = new double[10];
    private int head = -1;

    /// <inheritdoc/>
    public void Push(double value)
    {
        ++this.head;
        if (this.head >= this.array.Length)
        {
            Array.Resize(ref this.array, this.array.Length * 2);
        }

        this.array[this.head] = value;
    }

    /// <inheritdoc/>
    public (double, bool) Pop()
    {
        if (this.head == -1)
        {
            return (0, true);
        }

        var value = this.array[this.head];
        this.array[this.head] = 0;
        --this.head;
        return (value, false);
    }

    /// <inheritdoc/>
    public bool IsEmpty()
        => this.head == -1;
}
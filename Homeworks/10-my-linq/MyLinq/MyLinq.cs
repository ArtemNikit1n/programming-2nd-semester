// <copyright file="MyLinq.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// A class with lazy methods for working with sequences (Skip, Take).
/// </summary>
public static class MyLinq
{
    /// <summary>
    /// Returns the first n elements.
    /// </summary>
    /// <param name="sequence">The sequence from which the elements will be returned.</param>
    /// <param name="n">The position to which the elements will be returned.</param>
    /// <typeparam name="T">Type elements.</typeparam>
    /// <returns>The returned sequence.</returns>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> sequence, int n)
    {
        ArgumentNullException.ThrowIfNull(sequence);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        foreach (var element in sequence)
        {
            if (n-- <= 0)
            {
                yield break;
            }

            yield return element;
        }
    }

    /// <summary>
    /// Returns all elements after n.
    /// </summary>
    /// <param name="sequence">The sequence from which the elements will be returned.</param>
    /// <param name="n">Position.</param>
    /// <typeparam name="T">Type elements.</typeparam>
    /// <returns>The returned sequence.</returns>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> sequence, int n)
    {
        ArgumentNullException.ThrowIfNull(sequence);
        ArgumentOutOfRangeException.ThrowIfNegative(n);
        foreach (var element in sequence)
        {
            if (n-- > 0)
            {
                continue;
            }

            yield return element;
        }
    }
}
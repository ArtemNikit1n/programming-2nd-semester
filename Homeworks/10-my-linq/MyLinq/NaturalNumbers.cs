// <copyright file="NaturalNumbers.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// A natural number generator.
/// </summary>
public class NaturalNumbers : ISequence
{
    /// <summary>
    /// Generates an infinite sequence of natural numbers.
    /// </summary>
    /// <returns>Infinite IEnumerable natural numbers.</returns>
    public IEnumerable<int> GetNumbers()
    {
        var i = 1;
        while (i < int.MaxValue)
        {
            yield return i;
            i++;
        }
    }
}
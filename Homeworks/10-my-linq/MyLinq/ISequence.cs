// <copyright file="ISequence.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// An infinite sequence of numbers.
/// </summary>
public interface ISequence
{
    /// <summary>
    /// Generates an infinite sequence of numbers.
    /// </summary>
    /// <returns>Enumeration of integers.</returns>
    IEnumerable<int> GetNumbers();
}
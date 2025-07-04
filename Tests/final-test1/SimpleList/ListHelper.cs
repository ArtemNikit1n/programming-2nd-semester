#pragma warning disable SA1638
// <copyright file="SimpleListTests.cs" company="ArtemNikit1n">
#pragma warning restore SA1638
// Licensed under the MIT License. See LICENSE in the project root for details.
// Copyright (c) 2025 ArtemNikit1n. All rights reserved.
#pragma warning disable SA1512
// </copyright>
#pragma warning restore SA1512

#pragma warning disable SA1638
// <copyright file="SimpleListTests.cs" company="ArtemNikit1n">
#pragma warning restore SA1638
// Licensed under the MIT License. See LICENSE in the project root for details.
// Copyright (c) 2025 ArtemNikit1n. All rights reserved.
#pragma warning disable SA1512
// </copyright>
#pragma warning restore SA1512

namespace SimpleList;

/// <summary>
/// Provides extension methods for working with SimpleList collections.
/// </summary>
public static class ListHelper
{
    /// <summary>
    /// Counts the number of null/default elements in a SimpleList.
    /// </summary>
    /// <param name="list">The SimpleList.</param>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <returns>The count of elements that are null (for reference types) or default (for value types).</returns>
    public static int CountNullElement<T>(this SimpleList<T> list)
    {
        return list.Count(item => EqualityComparer<T>.Default.Equals(item, default));
    }
}
// <copyright file="MapFilterFoldTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MapFilterFold.Tests;

/// <summary>
/// Tests for Map, Filter and Fold.
/// </summary>
public class MapFilterFoldTests
{
    /// <summary>
    /// Map should return the correct value for the correct data.
    /// </summary>
    [Test]
    public void Map_ShouldReturnCorrectValueForCorrectData()
    {
        Assert.That(MapFilterFold.Map([1, 2, 3, 4], x => x * 2), Is.EqualTo(new List<int> { 2, 4, 6, 8 }));
    }

    /// <summary>
    /// Filter should return the correct value for the correct data.
    /// </summary>
    [Test]
    public void Filter_ShouldReturnCorrectValueForCorrectData()
    {
        Assert.That(MapFilterFold.Filter([1, 2, 3, 4], x => x % 2 == 0), Is.EqualTo(new List<int> { 2, 4 }));
    }

    /// <summary>
    /// Fold should return the correct value for the correct data.
    /// </summary>
    [Test]
    public void Fold_ShouldReturnCorrectValueForCorrectData()
    {
        Assert.That(MapFilterFold.Fold([1, 2, 3, 4], 1, (x, y) => x * y), Is.EqualTo(24));
    }

    /// <summary>
    /// Map should throw an exception for null arguments.
    /// </summary>
    [Test]
    public void Map_ShouldThrowExceptionForNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Map<int, object>([1, 2, 3], null!));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Map<int, object>(null!, x => x * 2));
    }

    /// <summary>
    /// Filter should throw an exception for null arguments.
    /// </summary>
    [Test]
    public void Filter_ShouldThrowExceptionForNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Filter([1, 2, 3], null!));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Filter<string>(null!, x => x == " "));
    }

    /// <summary>
    /// Fold should throw an exception for null arguments.
    /// </summary>
    [Test]
    public void Fold_ShouldThrowExceptionForNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Fold([1, 2, 3], 1, null!));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Fold<int, int>(null!, 1, (x, y) => (x * 2) + y));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Fold<string, string>(["1", "2", "3"], null!, (x, y) => x + y));
    }
}
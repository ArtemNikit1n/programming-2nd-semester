// <copyright file="MapFilterFoldTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MapFilterFold.Tests;

#pragma warning disable SA1600
public class MapFilterFoldTests
{
    [Test]
    public void Map_ShouldReturnCorrectValueForEmptyList()
    {
        Assert.That(MapFilterFold.Map(new List<int>(), x => x * 2), Is.EqualTo(new List<int>()));
    }

    [Test]
    public void Filter_ShouldReturnCorrectValueForEmptyList()
    {
        Assert.That(MapFilterFold.Filter(new List<string>(), x => x.Length == 2), Is.EqualTo(new List<string>()));
    }

    [Test]
    public void Fold_ShouldReturnCorrectValueForEmptyList()
    {
        Assert.That(MapFilterFold.Fold(new List<object>(), 1, (x, y) => x * (int)y), Is.EqualTo(1));
    }

    [Test]
    public void Map_ShouldReturnCorrectValueForCorrectData()
    {
        Assert.That(MapFilterFold.Map([1, 2, 3, 4], x => x * 2), Is.EqualTo(new List<int> { 2, 4, 6, 8 }));
    }

    [Test]
    public void Filter_ShouldReturnCorrectValueForCorrectData()
    {
        Assert.That(MapFilterFold.Filter([1, 2, 3, 4], x => x % 2 == 0), Is.EqualTo(new List<int> { 2, 4 }));
    }

    [Test]
    public void Fold_ShouldReturnCorrectValueForCorrectData()
    {
        Assert.That(MapFilterFold.Fold([1, 2, 3, 4], 1, (x, y) => x * y), Is.EqualTo(24));
    }

    [Test]
    public void Map_ShouldReturnCorrectValueForCorrectData_ReferenceType()
    {
        Assert.That(MapFilterFold.Map(["1", "2", "3", "4"], x => x + "!"), Is.EqualTo(new List<string> { "1!", "2!", "3!", "4!" }));
    }

    [Test]
    public void Filter_ShouldReturnCorrectValueForCorrectData_ReferenceType()
    {
        Assert.That(MapFilterFold.Filter(["1", "22", "3", "44"], x => x.Length == 2), Is.EqualTo(new List<string> { "22", "44" }));
    }

    [Test]
    public void Fold_ShouldReturnCorrectValueForCorrectData_ReferenceType()
    {
        Assert.That(MapFilterFold.Fold(["1", "2", "3", "4"], "0", (x, y) => x + y), Is.EqualTo("01234"));
    }

    [Test]
    public void Map_ShouldThrowExceptionForNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Map<int, object>([1, 2, 3], null!));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Map<int, object>(null!, x => x * 2));
    }

    [Test]
    public void Filter_ShouldThrowExceptionForNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Filter([1, 2, 3], null!));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Filter<string>(null!, x => x == " "));
    }

    [Test]
    public void Fold_ShouldThrowExceptionForNullArguments()
    {
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Fold([1, 2, 3], 1, null!));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Fold<int, int>(null!, 1, (x, y) => (x * 2) + y));
        Assert.Throws<ArgumentNullException>(() => MapFilterFold.Fold<string, string>(["1", "2", "3"], null!, (x, y) => x + y));
    }
}
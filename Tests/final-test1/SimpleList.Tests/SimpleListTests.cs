#pragma warning disable SA1638
// <copyright file="SimpleListTests.cs" company="ArtemNikit1n">
#pragma warning restore SA1638
// Licensed under the MIT License. See LICENSE in the project root for details.
// Copyright (c) 2025 ArtemNikit1n. All rights reserved.
#pragma warning disable SA1512
// </copyright>
#pragma warning restore SA1512

namespace SimpleList.Tests;

#pragma warning disable SA1600
public class SimpleListTests
{
    [Test]
    public void Add_ShouldAddItemsToListInCorrectOrder()
    {
        var list = new SimpleList<int>
        {
            1,
            2,

            // ReSharper disable once ArrangeTrailingCommaInMultilineLists
            3,
        };

        Assert.That(list.ToArray(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void GetEnumerator_EnumeratesItemsInCorrectOrder()
    {
        var list = new SimpleList<string> { "A", "B", "C" };

        using var enumerator = list.GetEnumerator();
        var enumeratedItems = new List<string>();

        while (enumerator.MoveNext())
        {
            enumeratedItems.Add(enumerator.Current);
        }

        Assert.That(enumeratedItems, Is.EqualTo(new[] { "A", "B", "C" }));
    }

    [Test]
    public void List_SupportsForEachLoop()
    {
        var list = new SimpleList<char> { 'X', 'Y', 'Z' };
        var result = new List<char>();

        foreach (var item in list)
        {
            result.Add(item);
        }

        Assert.That(result, Is.EqualTo(new[] { 'X', 'Y', 'Z' }));
    }

    [Test]
    public void Enumerate_ListModifiedDuringIteration_ThrowsInvalidOperationException()
    {
        var list = new SimpleList<string> { "A", "B", "C" };

        Assert.Throws<InvalidOperationException>(() =>
        {
            foreach (var item in list)
            {
                if (item == "B")
                {
                    list.Add("D");
                }
            }
        });
    }

    [Test]
    public void GetEnumerator_EmptyList_WorksWithoutErrors()
    {
        var list = new SimpleList<double>();
        using var enumerator = list.GetEnumerator();

        Assert.That(enumerator.MoveNext(), Is.EqualTo(false));
    }
}
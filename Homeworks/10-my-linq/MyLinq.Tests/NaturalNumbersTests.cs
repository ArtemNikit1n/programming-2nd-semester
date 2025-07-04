// <copyright file="NaturalNumbersTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq.Tests;

#pragma warning disable SA1600
public class NaturalNumbersTests
{
    private static readonly int[] Expected = [1, 2];

    [Test]
    public void NaturalNumbers_ShouldReturnNaturalNumbers()
    {
        var naturalNumbers = new NaturalNumbers();
        Assert.That(naturalNumbers.GetNumbers().Take(2).ToArray(), Is.EqualTo(Expected));
    }
}
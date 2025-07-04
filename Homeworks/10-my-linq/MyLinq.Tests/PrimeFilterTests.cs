// <copyright file="PrimeFilterTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq.Tests;

#pragma warning disable SA1600
public class PrimeFilterTests
{
    private static readonly int[] Expected = [2, 3, 5, 7, 11];

    [Test]
    public void PrimeFilter_ShouldReturnPrimeNumbers()
    {
        var numbers = new NaturalNumbers();
        var primeFilter = new PrimeFilter(numbers);

        var result = primeFilter.GetNumbers().Take(5).ToArray();
        Assert.That(result, Is.EqualTo(Expected));
    }
}
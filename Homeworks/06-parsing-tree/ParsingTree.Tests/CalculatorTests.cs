// <copyright file="CalculatorTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree.Tests;

/// <summary>
/// Tests for calculator.
/// </summary>
public class CalculatorTests
{
    /// <summary>
    /// Calculate should throw an exception when dividing by zero.
    /// </summary>
    [Test]
    public void Calculate_ShouldThrowExceptionWhenDividingByZero()
    {
        Assert.Throws<DivideByZeroException>(() => Calculator.Calculate("10 / 0"));
    }

    /// <summary>
    /// Calculate should throw an exception for empty string.
    /// </summary>
    [Test]
    public void Calculate_ShouldThrowExceptionForEmptyString()
    {
        Assert.Throws<ArgumentException>(() => Calculator.Calculate(string.Empty));
    }

    /// <summary>
    /// The calculator must correctly calculate large expressions.
    /// </summary>
    [Test]
    public void Calculate_ShouldCorrectlyCalculateLargeExpression()
    {
        Assert.That(Calculator.Calculate("(((((829 * 31) - 322) / 34 + 643) * 2114) + 302990) * 3242"), Is.EqualTo(1911992720));
    }
}
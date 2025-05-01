// <copyright file="CalculatorEngineTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorCore.Tests;

#pragma warning disable SA1600
public class CalculatorEngineTests
{
    private CalculatorEngine calculatorEngine;

    [SetUp]
    public void CreatingCalculatorEngine()
    {
        this.calculatorEngine = new CalculatorEngine();
    }

    [Test]
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueFieldAfterCalculations()
    {
        this.calculatorEngine.ProcessInput("3");
        this.calculatorEngine.ProcessInput("+");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("3+"));
        this.calculatorEngine.ProcessInput("10");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("13"));
    }
}
#pragma warning restore SA1600
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
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueFieldAfterTwoNormalCalculation()
    {
        this.calculatorEngine.ProcessInput("3");
        this.calculatorEngine.ProcessInput("+");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("3 + "));
        this.calculatorEngine.ProcessInput("10");
        this.calculatorEngine.ProcessInput("-");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("13 - "));
        this.calculatorEngine.ProcessInput("-");
        this.calculatorEngine.ProcessInput("5");
        this.calculatorEngine.ProcessInput("0");
        this.calculatorEngine.ProcessInput("=");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-37"));
    }

    [Test]
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueFieldAfterOneCalculationWithNegativeNumbers()
    {
        this.calculatorEngine.ProcessInput("-3");
        this.calculatorEngine.ProcessInput("-");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-3 - "));
        this.calculatorEngine.ProcessInput("-10");
        this.calculatorEngine.ProcessInput("=");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("7"));
    }

    [Test]
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueFieldAfterDivisionByZero()
    {
        this.calculatorEngine.ProcessInput("0");
        this.calculatorEngine.ProcessInput("/");
        this.calculatorEngine.ProcessInput("0");
        this.calculatorEngine.ProcessInput("=");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("0 / "));
        this.calculatorEngine.ProcessInput("-3");
        this.calculatorEngine.ProcessInput("/");
        this.calculatorEngine.ProcessInput("0");
        this.calculatorEngine.ProcessInput("+");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("0 / "));
    }
}
#pragma warning restore SA1600
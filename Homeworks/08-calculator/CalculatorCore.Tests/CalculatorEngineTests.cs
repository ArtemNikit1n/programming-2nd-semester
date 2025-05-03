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

    [Test]
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueAfterCompleteCleaning()
    {
        this.calculatorEngine.ProcessInput("30");
        this.calculatorEngine.ProcessInput("+");
        this.calculatorEngine.ProcessInput("10");
        this.calculatorEngine.ProcessInput("C");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("0"));
    }

    [Test]
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueAfterClearingOneItem()
    {
        this.calculatorEngine.ProcessInput("-30");
        this.calculatorEngine.ProcessInput("CE");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("0"));
        this.calculatorEngine.ProcessInput("30");
        this.calculatorEngine.ProcessInput("+");
        this.calculatorEngine.ProcessInput("10");
        this.calculatorEngine.ProcessInput("CE");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("30 + "));
    }

    [Test]
    public void ProcessInput_ShouldCorrectlyFillInDisplayValueAfterClearingOneCharacter()
    {
        this.calculatorEngine.ProcessInput("-30");
        this.calculatorEngine.ProcessInput("⌫");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-3"));
        this.calculatorEngine.ProcessInput("⌫");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-"));
        this.calculatorEngine.ProcessInput("⌫");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo(string.Empty));
        this.calculatorEngine.ProcessInput("30");
        this.calculatorEngine.ProcessInput("+");
        this.calculatorEngine.ProcessInput("10");
        this.calculatorEngine.ProcessInput("⌫");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("30 + 1"));
    }

    [Test]
    public void ProcessInput_ShouldCorrectlyChangeSignOfNumber()
    {
        this.calculatorEngine.ProcessInput("-30");
        this.calculatorEngine.ProcessInput("+/-");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("30"));
        this.calculatorEngine.ProcessInput("+/-");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-30"));
        this.calculatorEngine.ProcessInput("+");
        this.calculatorEngine.ProcessInput("5");
        this.calculatorEngine.ProcessInput("+/-");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-30 + -5"));
        this.calculatorEngine.ProcessInput("+/-");
        Assert.That(this.calculatorEngine.DisplayValue, Is.EqualTo("-30 + 5"));
    }
}
#pragma warning restore SA1600
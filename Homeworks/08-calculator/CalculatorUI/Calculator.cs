// <copyright file="Calculator.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorUI;

using CalculatorCore;

/// <summary>
/// A calculator made by analogy with the calculator on Windows.
/// </summary>
public partial class Calculator : Form
{
    private readonly CalculatorEngine calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    public Calculator()
    {
        this.InitializeComponent();
        this.calculator = new CalculatorEngine();
        this.CalculatorScreen.DataBindings.Add(
            "Text",
            this.calculator,
            nameof(this.calculator.DisplayValue),
            false,
            DataSourceUpdateMode.OnPropertyChanged);

        this.SetupEventHandlers();
    }

    private void SetupEventHandlers()
    {
        this.Zero.Click += this.ButtonClick;
        this.One.Click += this.ButtonClick;
        this.Two.Click += this.ButtonClick;
        this.Three.Click += this.ButtonClick;
        this.Four.Click += this.ButtonClick;
        this.Five.Click += this.ButtonClick;
        this.Six.Click += this.ButtonClick;
        this.Seven.Click += this.ButtonClick;
        this.Eight.Click += this.ButtonClick;
        this.Nine.Click += this.ButtonClick;

        this.Division.Click += this.ButtonClick;
        this.Multiply.Click += this.ButtonClick;
        this.Subtraction.Click += this.ButtonClick;
        this.Amount.Click += this.ButtonClick;
        this.Equality.Click += this.ButtonClick;

        this.Clear.Click += this.ButtonClick;
        this.ClearElement.Click += this.ButtonClick;
        this.Backspase.Click += this.ButtonClick;
        this.ChangeSign.Click += this.ButtonClick;
    }

    private void ButtonClick(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        this.calculator.ProcessInput(button.Text);
    }
}
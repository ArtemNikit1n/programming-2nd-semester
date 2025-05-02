// <copyright file="CalculatorEngine.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorCore;

/// <summary>
/// A class for calculating values received from the user.
/// The calculator calculates the operators immediately, that is, if the user clicks "7", "+", "3", "+", the screen should display "10".
/// </summary>
public class CalculatorEngine
{
    private CalculatorState currentState = CalculatorState.FirstOperand;
    private int firstOperand;
    private int secondOperand;
    private OperationType currentOperation = OperationType.EmptyOperation;
    private string currentInput = string.Empty;

    /// <summary>
    /// An event notifying that something needs to be cleared on the display.
    /// </summary>
    public event EventHandler? DisplayChanged;

    /// <summary>
    /// Gets the value to display on the screen.
    /// </summary>
    public string DisplayValue { get; private set; } = "0";

    /// <summary>
    /// A finite state machine that simulates the behavior of a calculator.
    /// </summary>
    /// <param name="input">The entered elementary unit for calculation.</param>
    /// <exception cref="UnknownCalculatorStatusException">The exception is for an unknown calculator condition.</exception>
    public void ProcessInput(string input)
    {
        switch (this.currentState)
        {
            case CalculatorState.FirstOperand:
                this.HandleFirstNumber(input);
                break;
            case CalculatorState.Operator:
                this.HandleOperatorIsExpected(input);
                break;
            case CalculatorState.SecondOperand:
                this.HandleSecondNumber(input);
                break;
            default:
                throw new UnknownCalculatorStatusException();
        }
    }

    /// <summary>
    /// Handles special user input (clearing characters).
    /// </summary>
    /// <param name="input">Special character.</param>
    public void ProcessSpecialInput(string input)
    {
        switch (input)
        {
            case "C":
                this.Clear();
                break;
            case "CE":
                this.currentInput = string.Empty;
                this.DisplayValue = this.currentState == CalculatorState.FirstOperand ? "0" :
                    $"{this.firstOperand} {ToChar(this.currentOperation)} ";
                break;
            case "⌫":
                if (this.currentInput.Length > 0)
                {
                    this.currentInput = this.currentInput[..^1];
                    this.DisplayValue = this.currentState == CalculatorState.FirstOperand ? this.currentInput :
                        $"{this.firstOperand} {ToChar(this.currentOperation)} {this.currentInput}";
                }

                break;
            case "+/-":
                if (this.currentInput.Length == 0)
                {
                    return;
                }

                this.currentInput = this.currentInput.StartsWith('-') ? this.currentInput[1..] : $"-{this.currentInput}";
                this.DisplayValue = this.currentState == CalculatorState.FirstOperand ? this.currentInput :
                    $"{this.firstOperand} {ToChar(this.currentOperation)} {this.currentInput}";
                break;
        }

        this.OnDisplayChanged();
    }

    private static OperationType ParseOperation(string input)
        => input switch
        {
            "+" => OperationType.Add,
            "-" => OperationType.Subtract,
            "*" => OperationType.Multiply,
            "/" => OperationType.Divide,
            _ => OperationType.EmptyOperation,
        };

    private static bool IsOperation(string input)
        => input is "+" or "-" or "*" or "/";

    private static char ToChar(OperationType operation)
        => operation switch
        {
            OperationType.Add => '+',
            OperationType.Subtract => '-',
            OperationType.Multiply => '*',
            OperationType.Divide => '/',
            OperationType.EmptyOperation => '\0',
            _ => throw new UnknownOperationException(),
        };

    private void HandleFirstNumber(string input)
    {
        if (IsOperation(input))
        {
            if (!int.TryParse(this.currentInput, out this.firstOperand) && this.firstOperand != 0)
            {
                throw new UnknownOperandException();
            }

            this.DisplayValue = $"{this.firstOperand} {input} ";
            this.currentOperation = ParseOperation(input);
            this.currentState = CalculatorState.SecondOperand;
            this.currentInput = string.Empty;
        }

        if (int.TryParse(input, out _))
        {
            this.currentInput += input;
            this.DisplayValue = $"{this.currentInput} ";
        }
        else
        {
            this.ProcessSpecialInput(input);
        }
    }

    private void HandleOperatorIsExpected(string input)
    {
        if (!IsOperation(input))
        {
            return;
        }

        this.currentOperation = ParseOperation(input);
        this.DisplayValue = $"{this.firstOperand} {input} ";
        this.currentState = CalculatorState.SecondOperand;
    }

    private void HandleSecondNumber(string input)
    {
        if ((IsOperation(input) || input == "=") && this.currentInput.Length == 0)
        {
            return;
        }

        if (IsOperation(input) || input == "=")
        {
            if (!int.TryParse(this.currentInput, out this.secondOperand))
            {
                throw new UnknownOperandException();
            }

            try
            {
                this.Calculate();
            }
            catch (DivideByZeroException)
            {
                this.DisplayValue = $"{this.firstOperand} {ToChar(this.currentOperation)} ";
                this.secondOperand = 0;
                this.currentInput = string.Empty;
                return;
            }

            if (IsOperation(input))
            {
                this.DisplayValue = $"{this.firstOperand} {input} ";
                this.currentOperation = ParseOperation(input);
                this.currentState = CalculatorState.SecondOperand;
            }
            else
            {
                this.DisplayValue = this.firstOperand.ToString();
                this.currentOperation = OperationType.EmptyOperation;
                this.currentState = CalculatorState.Operator;
            }

            this.currentInput = string.Empty;
        }

        if (int.TryParse(input, out _))
        {
            this.currentInput += input;
            this.DisplayValue += input;
        }
        else
        {
            this.ProcessSpecialInput(input);
        }
    }

    private void Calculate()
    {
        switch (this.currentOperation)
        {
            case OperationType.Add:
                this.firstOperand += this.secondOperand;
                break;
            case OperationType.Subtract:
                this.firstOperand -= this.secondOperand;
                break;
            case OperationType.Multiply:
                this.firstOperand *= this.secondOperand;
                break;
            case OperationType.Divide:
                this.firstOperand /= this.secondOperand != 0 ? this.secondOperand : throw new DivideByZeroException();
                break;
            default:
                throw new UnknownOperationException();
        }
    }

    private void Clear()
    {
        this.currentState = CalculatorState.FirstOperand;
        this.firstOperand = 0;
        this.secondOperand = 0;
        this.currentOperation = OperationType.EmptyOperation;
        this.currentInput = string.Empty;
        this.DisplayValue = "0";
    }

    private void OnDisplayChanged()
    {
        this.DisplayChanged?.Invoke(this, EventArgs.Empty);
    }
}
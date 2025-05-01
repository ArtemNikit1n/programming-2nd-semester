// <copyright file="CalculatorEngine.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Gets the value to display on the screen.
    /// </summary>
    public string DisplayValue { get; private set; } = "0";

    public void ProcessInput(string input)
    {
        switch (this.currentState)
        {
            case CalculatorState.FirstOperand:
                this.HandleFirstNumber(input);
                break;
            case CalculatorState.OperatorIsExpected:
                this.HandleOperatorEntered(input);
                break;
            case CalculatorState.SecondOperandIsExpected:
                this.HandleSecondNumber(input);
                break;
            default:
                throw new UnknownCalculatorStatusException();
        }
    }

    private void HandleFirstNumber(string input)
    {
        if (int.TryParse(input, out var inputNumber))
        {
            this.DisplayValue = input;
        }

        this.firstOperand = inputNumber;
        this.currentState = CalculatorState.OperatorIsExpected;
    }

    private void HandleOperatorEntered(string input)
    {
        this.currentOperation = (OperationType)input[0];
        this.DisplayValue += input;
        this.currentState = CalculatorState.SecondOperandIsExpected;
    }

    private void HandleSecondNumber(string input)
    {
        if (int.TryParse(input, out this.secondOperand))
        {
            this.DisplayValue += input;
        }

        this.Calculate();
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
}
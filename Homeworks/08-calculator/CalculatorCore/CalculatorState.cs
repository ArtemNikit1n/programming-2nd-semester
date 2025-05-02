// <copyright file="CalculatorState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorCore;

/// <summary>
/// The status of the calculator.
/// </summary>
public enum CalculatorState
{
    /// <summary>
    /// The calculator is waiting for the input of the first operand.
    /// </summary>
    FirstOperand,

    /// <summary>
    /// The calculator is waiting for the operator input.
    /// </summary>
    Operator,

    /// <summary>
    /// The calculator is waiting for the input of the second operand.
    /// </summary>
    SecondOperand,
}
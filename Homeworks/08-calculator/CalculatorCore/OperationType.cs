// <copyright file="OperationType.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorCore;

/// <summary>
/// The type of operation for working with natural numbers.
/// </summary>
public enum OperationType
{
    /// <summary>
    /// Amount.
    /// </summary>
    Add = '+',

    /// <summary>
    /// Subtraction.
    /// </summary>
    Subtract = '-',

    /// <summary>
    /// Multiplication.
    /// </summary>
    Multiply = '*',

    /// <summary>
    /// Division.
    /// </summary>
    Divide = '/',

    /// <summary>
    /// The status until the moment of the first operation.
    /// </summary>
    EmptyOperation = '\0',
}
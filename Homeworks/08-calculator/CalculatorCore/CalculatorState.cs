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
    OperatorIsExpected,

    /// <summary>
    /// The calculator is waiting for the input of the second operand.
    /// </summary>
    SecondOperandIsExpected,
}
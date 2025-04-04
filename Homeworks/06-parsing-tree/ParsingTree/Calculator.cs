namespace ParsingTree;

/// <summary>
/// A class for calculating arithmetic expressions.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Parse tree calculation.
    /// </summary>
    /// <param name="node">The root of the parsing tree.</param>
    /// <returns>Calculated value.</returns>
    /// <exception cref="DivideByZeroException">Division by zero.</exception>
    /// <exception cref="ArgumentException">Unknown operator or operand.</exception>
    /// <exception cref="InvalidOperationException">This exception means that the parse tree is not built correctly.</exception>
    public static int Calculate(Node node)
    {
        if (int.TryParse(node.Value, out var number))
        {
            return number;
        }

        var leftValue = Calculate(node.Left ?? throw new InvalidOperationException());
        var rightValue = Calculate(node.Right ?? throw new InvalidOperationException());

        switch (node.Value)
        {
            case "+":
                return leftValue + rightValue;
            case "-":
                return leftValue - rightValue;
            case "*":
                return leftValue * rightValue;
            case "/":
                if (rightValue == 0)
                {
                    throw new DivideByZeroException("Division by zero");
                }

                return leftValue / rightValue;
            default:
                throw new ArgumentException($"Unknown operator: {node.Value}");
        }
    }

    /// <summary>
    /// Calculation based on the original expression.
    /// </summary>
    /// <param name="input">Original expression.</param>
    /// <returns>Calculated value.</returns>
    public static int Calculate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input string cannot be empty or whitespace.");
        }

        var rootOfParsingTree = ParsingTree.Create(input);
        return Calculate(rootOfParsingTree);
    }
}
// <copyright file="ParsingTree.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

using System.Text;

/// <summary>
/// This class allows you to create a parse tree.
/// </summary>
public static class ParsingTree
{
    /// <summary>
    /// Creates a parse tree using the Node class.
    /// </summary>
    /// <param name="input">The input arithmetic expression.</param>
    /// <returns>The root of the parsing tree.</returns>
    public static Node Create(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty");
        }

        var tokens = ParseInputString(input);
        Stack<string> operators = new();
        Stack<Node> operands = new();

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out _))
            {
                Node numberNode = new(token);
                operands.Push(numberNode);
            }
            else
            {
                switch (token)
                {
                    case "(":
                        operators.Push(token);
                        break;
                    case ")":
                        while (operators.Peek() != "(")
                        {
                            var currentOperator = operators.Pop();
                            BuildSubtree(currentOperator, operands);
                        }

                        operators.Pop();
                        break;
                    default:
                        if (!IsOperator(token))
                        {
                            continue;
                        }

                        while (operators.Count > 0 && !IsPriorityOfFirstOperatorLower(operators.Peek(), token) && IsOperator(operators.Peek()))
                        {
                            var currentOperator = operators.Pop();
                            BuildSubtree(currentOperator, operands);
                        }

                        operators.Push(token);
                        break;
                }
            }
        }

        while (operators.Count > 0)
        {
            var currentOperator = operators.Pop();
            BuildSubtree(currentOperator, operands);
        }

        if (operands.Count != 1)
        {
            throw new ArgumentException("Invalid expression structure - check for missing operators or extra operands");
        }

        return operands.Pop();
    }

    private static void BuildSubtree(string currentOperator, Stack<Node> operands)
    {
        if (operands.Count < 2)
        {
            throw new ArgumentException($"Not enough operands for operator '{currentOperator}'");
        }

        var rightOperand = operands.Pop();
        var leftOperand = operands.Pop();

        var subtreeRoot = new Node(currentOperator);

        subtreeRoot.AddLeft(leftOperand);
        subtreeRoot.AddRight(rightOperand);

        operands.Push(subtreeRoot);
    }

    private static List<string> ParseInputString(string input)
    {
        List<string> tokens = [];
        var currentNumber = new StringBuilder();
        var inNumber = false;
        var bracketBalance = 0;
        var previousMinusSign = false;

        for (var i = 0; i < input.Length; ++i)
        {
            var symbol = input[i];

            if (symbol == ' ')
            {
                if (inNumber)
                {
                    if (currentNumber.Length == 1)
                    {
                        if (currentNumber[0] == '-')
                        {
                            continue;
                        }
                    }

                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();

                    inNumber = false;
                }

                previousMinusSign = false;
                continue;
            }

            if (symbol == '-')
            {
                if (previousMinusSign)
                {
                    throw new ArgumentException($"Invalid operator position at position {i}.");
                }

                previousMinusSign = true;
                if (inNumber)
                {
                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();
                    inNumber = false;
                }

                if (tokens.Count > 0 && IsOperator(tokens.Last()))
                {
                    currentNumber.Append(symbol);
                    inNumber = true;
                }
                else if (tokens.Count == 0 || tokens.Last() == "(")
                {
                    currentNumber.Append(symbol);
                    inNumber = true;
                }
                else
                {
                    tokens.Add("-");
                }
            }
            else if (char.IsDigit(symbol))
            {
                currentNumber.Append(symbol);
                inNumber = true;
                previousMinusSign = false;
            }
            else if (symbol == '(')
            {
                ++bracketBalance;
                if (inNumber)
                {
                    throw new ArgumentException($"Number cannot be directly before '(' at position {i}.");
                }

                if (tokens.Count > 0 && !IsOperator(tokens.Last()) && tokens.Last() != "(")
                {
                    throw new ArgumentException($"Missing operator before '(' at position {i}.");
                }

                tokens.Add(symbol.ToString());
                inNumber = false;
                previousMinusSign = false;
            }
            else if (symbol == ')')
            {
                bracketBalance--;
                if (bracketBalance < 0)
                {
                    throw new ArgumentException($"Unmatched ')' at position {i}.");
                }

                if (inNumber)
                {
                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();
                    inNumber = false;
                }

                if (tokens.Count == 0 || IsOperator(tokens.Last()))
                {
                    throw new ArgumentException($"Invalid token before ')' at position {i}.");
                }

                tokens.Add(symbol.ToString());
                previousMinusSign = false;
            }
            else if (IsOperator(symbol))
            {
                if (inNumber)
                {
                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();
                    inNumber = false;
                }

                if (tokens.Count == 0 || IsOperator(tokens.Last()) || tokens.Last() == "(")
                {
                    throw new ArgumentException($"Invalid operator position at position {i}.");
                }

                tokens.Add(symbol.ToString());
                previousMinusSign = false;
            }
            else
            {
                throw new ArgumentException($"Invalid character '{symbol}' at position {i}.");
            }
        }

        if (bracketBalance != 0)
        {
            throw new ArgumentException("Unmatched parentheses in expression.");
        }

        if (inNumber)
        {
            tokens.Add(currentNumber.ToString());
        }

        if (IsOperator(tokens.Last()))
        {
            throw new ArgumentException("Expression cannot end with an operator.");
        }

        return tokens;
    }

    private static bool IsOperator(char token)
        => token is '+' or '-' or '*' or '/';

    private static bool IsOperator(string token)
        => token is "+" or "-" or "*" or "/";

    private static bool IsPriorityOfFirstOperatorLower(string firstOperator, string secondOperator)
    {
        if (secondOperator is not ("*" or "/"))
        {
            return false;
        }

        return firstOperator is "+" or "-";
    }
}
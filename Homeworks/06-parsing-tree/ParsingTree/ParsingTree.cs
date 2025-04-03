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
                }

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
            }
        }

        while (operators.Count > 0)
        {
            var currentOperator = operators.Pop();
            BuildSubtree(currentOperator, operands);
        }

        return operands.Pop();
    }

    private static void BuildSubtree(string currentOperator, Stack<Node> operands)
    {
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

        foreach (var symbol in input)
        {
            if (char.IsWhiteSpace(symbol))
            {
                if (inNumber)
                {
                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();
                    inNumber = false;
                }

                continue;
            }

            if (symbol == '-' || char.IsDigit(symbol))
            {
                if (symbol == '-' && (inNumber || (tokens.Count > 0 && tokens.Last() != "(")))
                {
                    if (inNumber)
                    {
                        tokens.Add(currentNumber.ToString());
                        currentNumber.Clear();
                        inNumber = false;
                    }

                    if (IsOperator(tokens.Last()))
                    {
                        currentNumber.Append(symbol);
                        inNumber = true;
                    }
                    else
                    {
                        tokens.Add("-");
                    }
                }
                else
                {
                    currentNumber.Append(symbol);
                    inNumber = true;
                }
            }
            else if (symbol == '(' || symbol == ')' || IsOperator(symbol))
            {
                if (inNumber)
                {
                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();
                    inNumber = false;
                }

                tokens.Add(symbol.ToString());
            }
        }

        if (inNumber)
        {
            tokens.Add(currentNumber.ToString());
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
// <copyright file="ParsingTree.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

using System.Text;

public static class ParsingTree
{
    public static Node CreateParseTree(string input)
    {
        var tokens = ParseInputString(input);
        return new Node("0");
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

                    tokens.Add("-");
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
}
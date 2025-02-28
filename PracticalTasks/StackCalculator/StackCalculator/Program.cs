// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using StackCalculator;

Calc calc = new(new ArrayStack());

Console.WriteLine("Input string to evaluate:");
var input = Console.ReadLine() ?? "0";

Console.WriteLine(calc.Evaluate(input));
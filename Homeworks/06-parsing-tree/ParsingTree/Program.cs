// <copyright file="Program.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ParsingTree;

Console.WriteLine("Enter an arithmetic expression using numbers and the operations +, -, *, /");
var input = Console.ReadLine();
while (string.IsNullOrEmpty(input))
{
    Console.WriteLine("Enter an arithmetic expression");
    input = Console.ReadLine();
}

try
{
    Console.WriteLine("Result: {0}", Calculator.Calculate(input));
    return 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
    return 1;
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    return 1;
}
catch (Exception ex)
{
    Console.WriteLine("Error: {0}", ex.Message);
    return 1;
}

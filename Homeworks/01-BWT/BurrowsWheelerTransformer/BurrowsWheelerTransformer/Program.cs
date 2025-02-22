// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BurrowsWheelerTransformer;

const string input = "ba$$nana$";

var (transformedString, endPosition) = BWT.Transform(input);
Console.WriteLine($"Transformed string: {transformedString}");
Console.WriteLine($"End position: {endPosition}");

var result = BWT.InverseTransform(transformedString, endPosition);
Console.WriteLine($"The original string: {result}");
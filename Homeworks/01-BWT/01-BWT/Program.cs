using System;
using BWT;

class Program
{
    private static void Main()
    {
        const string input = "banana";

        var (transformedString, endPosition) = BurrowsWheelerTransformer.Transform(input);
        Console.WriteLine($"Transformed string: {transformedString}");
        Console.WriteLine($"End position: {endPosition}");
    }
}
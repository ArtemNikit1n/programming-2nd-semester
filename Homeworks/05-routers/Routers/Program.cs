// <copyright file="Program.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

try
{
    if (args.Length != 2)
    {
        Console.Error.WriteLine("Usage: Routers <input_file> <output_file>");
        return 1;
    }

    var inputFile = args[0];
    var outputFile = args[1];

    var graph = new Graph(inputFile);
    var mst = graph.GetMaximumSpanningTree();
    mst.SaveToFile(outputFile);

    return 0;
}
catch (FileNotFoundException ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
    return 1;
}
catch (FormatException ex)
{
    Console.Error.WriteLine($"Error: Invalid input format. {ex.Message}");
    return 1;
}
catch (GraphNotConnectedException)
{
    Console.Error.WriteLine("Error: The graph is not connected.");
    return 1;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Unexpected error: {ex.Message}");
    return 1;
}
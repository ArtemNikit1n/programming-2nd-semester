namespace ParsingTree;

public static class Calculator
{
    public static int Calculate(Node rootOfParsingTree)
    {
        if (rootOfParsingTree)
    }

    public static void Calculate(string input)
    {
        var rootOfParsingTree = ParsingTree.Create(input);
        Calculate(rootOfParsingTree);
    }
}
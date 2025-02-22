// <copyright file="BWTTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BurrowsWheelerTransformer;

/// <summary>
/// A class for running BWT tests.
/// </summary>
public abstract class BWTTests
{
    /// <summary>
    /// Runs all forward and reverse conversion tests.
    /// </summary>
    /// <returns>
    /// True == test PASSED.
    /// False == test FAILED.
    /// </returns>
    public static bool RunTests()
    {
        return TestDirectTransformation() && TestReverseTransformation();
    }

    private static bool TestDirectTransformation()
    {
        var normalDataTest = BWT.Transform("ABACABA") == ("BCABAAA", 2);
        var emptyDataTest = BWT.Transform(string.Empty) == (string.Empty, -1);
        var shortLineTest = BWT.Transform("0") == ("0", 0);
        var longLineTest = BWT.Transform("Pneumonoultramicroscopicsilicovolcanoconiosis") == ("srclosiiinlmpsnsoiuauPoaonvcmcrincotciocoloeo", 0);

        return normalDataTest && shortLineTest && longLineTest && emptyDataTest;
    }

    private static bool TestReverseTransformation()
    {
        var normalDataTest = BWT.InverseTransform("BCABAAA", 2) == "ABACABA";
        var emptyDataTest = BWT.InverseTransform(string.Empty, -1) == string.Empty;
        var shortLineTest = BWT.InverseTransform("0", 0) == "0";
        var longLineTest = BWT.InverseTransform("srclosiiinlmpsnsoiuauPoaonvcmcrincotciocoloeo", 0) == "Pneumonoultramicroscopicsilicovolcanoconiosis";

        return normalDataTest && shortLineTest && longLineTest && emptyDataTest;
    }
}
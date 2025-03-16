// <copyright file="BWTTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Tests;

/// <summary>
/// BWT tests.
/// </summary>
public static class BWTTests
{
    /// <summary>
    /// The direct conversion should return the correct values (multiple).
    /// </summary>
    [Test]
    public static void BWT_Transform_ShouldReturnCorrectValues_Multiple()
    {
        Assert.Multiple(() =>
        {
            Assert.That(BWT.Transform("ABACABA"), Is.EqualTo(("BCABAAA", 2)));
            Assert.That(BWT.Transform(string.Empty), Is.EqualTo((string.Empty, -1)));
            Assert.That(BWT.Transform("0"), Is.EqualTo(("0", 0)));
            Assert.That(BWT.Transform("Pneumonoultramicroscopicsilicovolcanoconiosis"), Is.EqualTo(("srclosiiinlmpsnsoiuauPoaonvcmcrincotciocoloeo", 0)));
        });
    }

    /// <summary>
    /// The reverse conversion should return the correct values (multiple).
    /// </summary>
    [Test]
    public static void BWT_InverseTransform_ShouldReturnCorrectValues_Multiple()
    {
        Assert.Multiple(() =>
        {
            Assert.That(BWT.InverseTransform("BCABAAA", 2), Is.EqualTo("ABACABA"));
            Assert.That(BWT.InverseTransform(string.Empty, -1), Is.EqualTo(string.Empty));
            Assert.That(BWT.InverseTransform("0", 0), Is.EqualTo("0"));
            Assert.That(BWT.InverseTransform("srclosiiinlmpsnsoiuauPoaonvcmcrincotciocoloeo", 0), Is.EqualTo("Pneumonoultramicroscopicsilicovolcanoconiosis"));
        });
    }
}
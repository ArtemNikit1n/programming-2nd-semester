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
            Assert.That(BWT.Transform([1, 2, 1, 3, 1, 2, 1]), Is.EqualTo(((List<byte>)[2, 3, 1, 2, 1, 1, 1], 2)));
            Assert.That(BWT.Transform([]), Is.EqualTo(((List<byte>)[], -1)));
            Assert.That(BWT.Transform([0]), Is.EqualTo(((List<byte>)[0], 0)));
            Assert.That(BWT.Transform([255, 255, 255, 255, 255]), Is.EqualTo(((List<byte>)[255, 255, 255, 255, 255], 0)));
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
            Assert.That(BWT.InverseTransform([2, 3, 1, 2, 1, 1, 1], 2), Is.EqualTo((List<byte>)[1, 2, 1, 3, 1, 2, 1]));
            Assert.That(BWT.InverseTransform([], -1), Is.EqualTo((List<byte>)[]));
            Assert.That(BWT.InverseTransform([0], 0), Is.EqualTo((List<byte>)[0]));
            Assert.That(BWT.InverseTransform([255, 255, 255, 255, 255], 0), Is.EqualTo((List<byte>)[255, 255, 255, 255, 255]));
        });
    }
}
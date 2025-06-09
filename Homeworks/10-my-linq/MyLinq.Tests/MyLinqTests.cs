// <copyright file="MyLinqTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq.Tests;

#pragma warning disable SA1600
public class MyLinqTests
{
    private static readonly string?[] NormalSequenceReferenceType = [null, "22", "\0", "\n"];
    private static readonly string[]? NullSequenceReferenceType = null;
    private static readonly int[] NormalSequence = [1, 2, 3, 4];
    private static readonly int[] EmptySequence = [];

    [Test]
    public void Take_ShouldReturnElementsUpTo2()
        => Assert.That(NormalSequence.Take(2), Is.EqualTo(new[] { 1, 2 }));

    [Test]
    public void Take_ShouldNotReturnElementsForEmptySequence()
        => Assert.That(EmptySequence.Take(2), Is.EqualTo(EmptySequence));

    [Test]
    public void Take_ShouldReturnElementsUpTo2_ReferenceType()
        => Assert.That(NormalSequenceReferenceType.Take(2), Is.EqualTo(new[] { null, "22" }));

    [Test]
    public void Take_ThrowExceptionForNullSequence_ReferenceType()
        => Assert.Throws<ArgumentNullException>(() => { _ = NullSequenceReferenceType!.Take(2).ToList(); });

    [Test]
    public void Take_ThrowExceptionForNegativeIndex()
        => Assert.Throws<ArgumentOutOfRangeException>(() => { _ = NormalSequence.Take(-2).ToList(); });

    [Test]
    public void Skip_ShouldReturnElementsUpTo2()
        => Assert.That(NormalSequence.Skip(2), Is.EqualTo(new[] { 3, 4 }));

    [Test]
    public void Skip_ShouldNotReturnElementsForEmptySequence()
        => Assert.That(EmptySequence.Skip(2), Is.EqualTo(EmptySequence));

    [Test]
    public void Skip_ShouldReturnElementsUpTo2_ReferenceType()
        => Assert.That(NormalSequenceReferenceType.Skip(2), Is.EqualTo(new[] { "\0", "\n" }));

    [Test]
    public void Skip_ThrowExceptionForNullSequence_ReferenceType()
        => Assert.Throws<ArgumentNullException>(() => { _ = NullSequenceReferenceType!.Skip(2).ToList(); });

    [Test]
    public void Skip_ThrowExceptionForNegativeIndex()
        => Assert.Throws<ArgumentOutOfRangeException>(() => { _ = NormalSequence.Skip(-2).ToList(); });
}
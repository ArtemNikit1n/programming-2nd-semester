#pragma warning disable SA1638
// <copyright file="SimpleListTests.cs" company="ArtemNikit1n">
#pragma warning restore SA1638
// Licensed under the MIT License. See LICENSE in the project root for details.
// Copyright (c) 2025 ArtemNikit1n. All rights reserved.
#pragma warning disable SA1512
// </copyright>
#pragma warning restore SA1512

namespace SimpleList.Tests;

#pragma warning disable SA1600
public class ListHelperTests
{
    private SimpleList<int> nonReferenceTypeList;
    private SimpleList<string?> referenceTypeList;
    private SimpleList<bool> boolList;

    [SetUp]
    public void InitializeLists()
    {
        this.nonReferenceTypeList = [1, 0, 3, 0, 5];
        this.referenceTypeList = ["a", null, string.Empty, "b", null];
        this.boolList = [true, false, false, true];
    }

    [Test]
    public void CountNulls_BoolList_ReturnsCorrectCount()
    {
        Assert.That(this.boolList.CountNullElement(), Is.EqualTo(2));
    }

    [Test]
    public void CountNulls_NonReferenceTypeList_ReturnsCorrectCount()
    {
        Assert.That(this.nonReferenceTypeList.CountNullElement(), Is.EqualTo(2));
    }

    [Test]
    public void CountNulls_ReferenceTypeList_ReturnsCorrectCount()
    {
        Assert.That(this.referenceTypeList.CountNullElement(), Is.EqualTo(2));
    }
}
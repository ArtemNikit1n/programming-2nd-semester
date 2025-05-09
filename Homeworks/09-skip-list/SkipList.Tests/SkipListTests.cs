// <copyright file="SkipListTests.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList.Tests;

#pragma warning disable SA1600
public class SkipListTests
{
    private SkipList<int> listWithNonReferenceType;
    private SkipList<string> listWithReferenceType;

    [SetUp]
    public void InitializeLists()
    {
        this.listWithNonReferenceType = [];
        this.listWithReferenceType = [];
    }

    [Test]
    public void Add_ShouldAddOneItem()
    {
        this.listWithNonReferenceType.Add(1);
        Assert.That(this.listWithNonReferenceType, Has.Count.EqualTo(1));
    }

    [Test]
    public void Add_ShouldAddOneItem_ReferenceType()
    {
        this.listWithReferenceType.Add("123");
        Assert.That(this.listWithReferenceType, Has.Count.EqualTo(1));
    }

    [Test]
    public void Remove_ShouldRemoveOneItem()
    {
        this.listWithNonReferenceType.Add(1);
        this.listWithNonReferenceType.Remove(1);
        Assert.That(this.listWithNonReferenceType, Has.Count.EqualTo(0));
    }

    [Test]
    public void Remove_ShouldRemoveOneItem_ReferenceType()
    {
        this.listWithReferenceType.Add("123");
        this.listWithReferenceType.Remove("123");
        Assert.That(this.listWithReferenceType, Has.Count.EqualTo(0));
    }

    [Test]
    public void Add_ShouldBeInsertedCorrectlyInMiddleOfList()
    {
        this.listWithNonReferenceType.Add(1);
        this.listWithNonReferenceType.Add(2);
        this.listWithNonReferenceType.Add(3);
        this.listWithNonReferenceType.Add(4);
        this.listWithNonReferenceType.Add(7);
        this.listWithNonReferenceType.Add(10);
        this.listWithNonReferenceType.Add(11);
        this.listWithNonReferenceType.Add(30);
        this.listWithNonReferenceType.Add(5);
        Assert.Multiple(() =>
        {
            Assert.That(this.listWithNonReferenceType[3], Is.EqualTo(4));
            Assert.That(this.listWithNonReferenceType[4], Is.EqualTo(5));
            Assert.That(this.listWithNonReferenceType[5], Is.EqualTo(7));
        });
    }

    [Test]
    public void IndexOf_ShouldBeExecutedCorrectlyWhenTraversingForeach()
    {
        this.listWithNonReferenceType.Add(1);
        this.listWithNonReferenceType.Add(3);
        this.listWithNonReferenceType.Add(2);

        var index = 0;
        foreach (var element in this.listWithNonReferenceType)
        {
            Assert.That(this.listWithNonReferenceType.IndexOf(element), Is.EqualTo(index));
            index++;
        }
    }

    [Test]
    public void IndexOf_ShouldBeExecutedCorrectlyWhenTraversingForeach_ReferenceType()
    {
        this.listWithReferenceType.Add("1");
        this.listWithReferenceType.Add("333");
        this.listWithReferenceType.Add("22");

        var index = 0;
        foreach (var element in this.listWithReferenceType)
        {
            Assert.That(this.listWithReferenceType.IndexOf(element), Is.EqualTo(index));
            index++;
        }
    }
}
#pragma warning restore SA1600

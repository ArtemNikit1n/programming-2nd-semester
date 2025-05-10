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
        Assert.Multiple(() =>
        {
            Assert.That(this.listWithNonReferenceType.Remove(1), Is.EqualTo(true));
            Assert.That(this.listWithNonReferenceType, Has.Count.EqualTo(0));
        });
    }

    [Test]
    public void Remove_ShouldRemoveOneItem_ReferenceType()
    {
        this.listWithReferenceType.Add("123");
        Assert.Multiple(() =>
        {
            Assert.That(this.listWithReferenceType.Remove("123"), Is.EqualTo(true));
            Assert.That(this.listWithReferenceType, Has.Count.EqualTo(0));
        });
    }

    [Test]
    public void Remove_ShouldRemoveItem_ReferenceType_Multiple()
    {
        this.listWithReferenceType.Add("1");
        this.listWithReferenceType.Add("22");
        this.listWithReferenceType.Add("22");
        this.listWithReferenceType.Add("22");
        this.listWithReferenceType.Add("22");
        this.listWithReferenceType.Add("1");
        this.listWithReferenceType.Add("4444");
        Assert.That(this.listWithReferenceType, Has.Count.EqualTo(7));
        Assert.Multiple(() =>
        {
            Assert.That(this.listWithReferenceType.Remove("1"), Is.EqualTo(true));
            Assert.That(this.listWithReferenceType.Remove("22"), Is.EqualTo(true));
            Assert.That(this.listWithReferenceType.Remove("333"), Is.EqualTo(false));
        });
        Assert.That(this.listWithReferenceType, Has.Count.EqualTo(5));
    }

    [Test]
    public void Remove_ShouldRemoveItem_Multiple()
    {
        this.listWithNonReferenceType.Add(1);
        this.listWithNonReferenceType.Add(2);
        this.listWithNonReferenceType.Add(2);
        this.listWithNonReferenceType.Add(2);
        this.listWithNonReferenceType.Add(2);
        this.listWithNonReferenceType.Add(1);
        this.listWithNonReferenceType.Add(4);
        Assert.That(this.listWithNonReferenceType, Has.Count.EqualTo(7));
        Assert.Multiple(() =>
        {
            Assert.That(this.listWithNonReferenceType.Remove(1), Is.EqualTo(true));
            Assert.That(this.listWithNonReferenceType.Remove(2), Is.EqualTo(true));
            Assert.That(this.listWithNonReferenceType.Remove(3), Is.EqualTo(false));
        });
        Assert.That(this.listWithNonReferenceType, Has.Count.EqualTo(5));
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

    [Test]
    public void Insert_ShouldTrowException()
    {
        Assert.Throws<NotSupportedException>(() => this.listWithReferenceType.Insert(1, "1"));
    }

    [Test]
    public void RemoveAt_ShouldTrowException()
    {
        Assert.Throws<NotSupportedException>(() => this.listWithReferenceType.RemoveAt(1));
    }

    [Test]
    public void CopyTo_ShouldShouldThrowExceptionForInvalidIndexes()
    {
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        Assert.Throws<ArgumentOutOfRangeException>(() => this.listWithNonReferenceType.CopyTo(array, -1));
        this.listWithNonReferenceType.Add(1);
        Assert.Throws<ArgumentException>(() => this.listWithNonReferenceType.CopyTo(array, 10));
    }

    [Test]
    public void CopyTo_ShouldFillInArrayCorrectly()
    {
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        this.listWithNonReferenceType.Add(10);
        this.listWithNonReferenceType.CopyTo(array, 5);
        Assert.That(array[5], Is.EqualTo(10));
    }

    [Test]
    public void Contains_ShouldReturnTrueForAddedElement()
    {
        this.listWithNonReferenceType.Add(10);
        Assert.That(this.listWithNonReferenceType, Does.Contain(10));
    }

    [Test]
    public void Contains_ShouldReturnTrueForAddedElement_Multiple()
    {
        this.listWithNonReferenceType.Add(10);
        this.listWithNonReferenceType.Add(32);
        this.listWithNonReferenceType.Add(534);
        this.listWithNonReferenceType.Add(12);
        this.listWithNonReferenceType.Add(54);
        this.listWithNonReferenceType.Add(-65);
        this.listWithNonReferenceType.Add(5);
        this.listWithNonReferenceType.Add(0);
        this.listWithNonReferenceType.Add(0);
        this.listWithNonReferenceType.Add(143);
        this.listWithNonReferenceType.Add(1243);
        this.listWithNonReferenceType.Add(54);

        Assert.That(this.listWithNonReferenceType, Does.Contain(0));
    }

    [Test]
    public void Contains_ShouldReturnFalseForRemovedElement()
    {
        this.listWithNonReferenceType.Add(10);
        this.listWithNonReferenceType.Remove(10);
        Assert.That(this.listWithNonReferenceType, Does.Not.Contain(10));
        Assert.That(this.listWithNonReferenceType, Does.Not.Contain(11));
    }

    [Test]
    public void Clear_ShouldClearAllElements()
    {
        this.listWithNonReferenceType.Add(143);
        this.listWithNonReferenceType.Add(1243);
        this.listWithNonReferenceType.Add(54);

        this.listWithNonReferenceType.Clear();
        Assert.That(this.listWithNonReferenceType, Does.Not.Contain(54));
        Assert.That(this.listWithNonReferenceType, Does.Not.Contain(1243));
        Assert.That(this.listWithNonReferenceType, Does.Not.Contain(143));
        Assert.That(this.listWithNonReferenceType, Has.Count.EqualTo(0));
    }
}
#pragma warning restore SA1600

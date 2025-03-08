// <copyright file="TrieTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Tests;

/// <summary>
/// Tests for trie.
/// </summary>
public class TrieTests
{
    private const string NormalString = "apple";
    private const string PrefixNormalString = "app";
    private const string LongString = "applesAndBananas";
    private const string WithoutCommonPrefix = "bananas";
    private readonly string emptyString = string.Empty;

    private readonly Trie.Trie trie = new();

    /// <summary>
    /// Trie contains should return false for empty string.
    /// </summary>
    [Test]
    public void Trie_Contains_ShouldReturnFalseForEmptyString()
    {
        Assert.That(this.trie.Contains(this.emptyString), Is.False);
    }

    /// <summary>
    /// Trie add should return false for empty string.
    /// </summary>
    [Test]
    public void Trie_Add_ShouldReturnFalseForEmptyString()
    {
        Assert.That(this.trie.Add(this.emptyString), Is.False);
    }

    /// <summary>
    /// Trie size should equal null for empty trie.
    /// </summary>
    [Test]
    public void Trie_Size_ShouldEqualNullForEmptyTrie()
    {
        this.trie.Add(this.emptyString);
        Assert.That(this.trie.Size, Is.EqualTo(0));
    }

    /// <summary>
    /// Trie add should return true for non-empty string.
    /// </summary>
    [Test]
    public void Trie_Add_ShouldReturnTrueForNonEmptyString()
    {
        Assert.That(this.trie.Add(TrieTests.LongString), Is.True);
    }

    /// <summary>
    /// Trie size should equal one for trie with one word.
    /// </summary>
    [Test]
    public void Trie_Size_ShouldEqualOneForTrieWithOneWord()
    {
        this.trie.Add(NormalString);
        Assert.That(this.trie.Size, Is.EqualTo(1));
    }

    /// <summary>
    /// Trie add should return true for non-empty string (multiple).
    /// </summary>
    [Test]
    public void Trie_Add_ShouldReturnTrueForNonEmptyString_Multiple()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Add(TrieTests.NormalString), Is.True);
            Assert.That(this.trie.Add(TrieTests.PrefixNormalString), Is.True);
            Assert.That(this.trie.Add(TrieTests.LongString), Is.True);
            Assert.That(this.trie.Add(TrieTests.WithoutCommonPrefix), Is.True);
        });
    }

    /// <summary>
    /// Trie size should equals correct value after add (multiple).
    /// </summary>
    [Test]
    public void Trie_Size_ShouldEqualsCorrectValueAfterAdd_Multiple()
    {
        this.trie.Add(NormalString);
        Assert.That(this.trie.Size, Is.EqualTo(1));
        this.trie.Add(PrefixNormalString);
        Assert.That(this.trie.Size, Is.EqualTo(2));
        this.trie.Add(LongString);
        Assert.That(this.trie.Size, Is.EqualTo(3));
        this.trie.Add(WithoutCommonPrefix);
        Assert.That(this.trie.Size, Is.EqualTo(4));
    }

    /// <summary>
    /// Trie contains should return true for added string (multiple).
    /// </summary>
    [Test]
    public void Trie_Contains_ShouldReturnTrueForAddedString_Multiple()
    {
        this.trie.Add(NormalString);
        this.trie.Add(PrefixNormalString);
        this.trie.Add(LongString);
        this.trie.Add(WithoutCommonPrefix);

        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Contains(WithoutCommonPrefix), Is.True);
            Assert.That(this.trie.Contains(NormalString), Is.True);
            Assert.That(this.trie.Contains(PrefixNormalString), Is.True);
            Assert.That(this.trie.Contains(LongString), Is.True);
            Assert.That(this.trie.Contains(this.emptyString), Is.False);
        });
    }

    /// <summary>
    /// Trie size should equals correct value after remove (multiple).
    /// </summary>
    [Test]
    public void Trie_Size_ShouldEqualsCorrectValueAfterRemove_Multiple()
    {
        this.trie.Add(NormalString);
        this.trie.Remove(NormalString);
        Assert.That(this.trie.Size, Is.EqualTo(0));
        this.trie.Add(PrefixNormalString);
        this.trie.Add(LongString);
        Assert.That(this.trie.Size, Is.EqualTo(2));
        this.trie.Remove(LongString);
        Assert.That(this.trie.Size, Is.EqualTo(1));
        this.trie.Remove(PrefixNormalString);
        Assert.That(this.trie.Size, Is.EqualTo(0));
    }

    /// <summary>
    /// Trie contains should return true for removed string (multiple).
    /// </summary>
    [Test]
    public void Trie_Contains_ShouldReturnTrueForRemovedString_Multiple()
    {
        this.trie.Add(NormalString);
        this.trie.Add(PrefixNormalString);
        this.trie.Add(LongString);
        this.trie.Add(WithoutCommonPrefix);

        this.trie.Remove(NormalString);
        this.trie.Remove(LongString);
        this.trie.Remove(PrefixNormalString);
        this.trie.Remove(WithoutCommonPrefix);

        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Contains(WithoutCommonPrefix), Is.False);
            Assert.That(this.trie.Contains(NormalString), Is.False);
            Assert.That(this.trie.Contains(PrefixNormalString), Is.False);
            Assert.That(this.trie.Contains(LongString), Is.False);
            Assert.That(this.trie.Contains(string.Empty), Is.False);
            Assert.That(this.trie.Contains("a non-existent string"), Is.False);
        });
    }

    /// <summary>
    /// Trie remove should return true for non-empty string.
    /// </summary>
    [Test]
    public void Trie_Remove_ShouldReturnTrueForNonEmptyString()
    {
        this.trie.Add(NormalString);
        this.trie.Add(PrefixNormalString);
        this.trie.Add(LongString);
        this.trie.Add(WithoutCommonPrefix);

        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Remove(TrieTests.NormalString), Is.True);
            Assert.That(this.trie.Remove(TrieTests.PrefixNormalString), Is.True);
            Assert.That(this.trie.Remove(TrieTests.LongString), Is.True);
            Assert.That(this.trie.Remove(TrieTests.WithoutCommonPrefix), Is.True);
        });
    }

    /// <summary>
    /// Trie remove should return false for empty string.
    /// </summary>
    [Test]
    public void Trie_Remove_ShouldReturnFalseForEmptyString()
    {
        Assert.That(this.trie.Remove(this.emptyString), Is.False);
    }

    /// <summary>
    /// Trie how many starts with prefix should equals correct value after add and remove (multiple).
    /// </summary>
    [Test]
    public void Trie_HowManyStartsWithPrefix_ShouldEqualsCorrectValueAfterAddAndRemove_Multiple()
    {
        this.trie.Add(NormalString);

        Assert.Multiple(() =>
        {
            Assert.That(this.trie.HowManyStartsWithPrefix("123"), Is.EqualTo(0));
            Assert.That(this.trie.HowManyStartsWithPrefix("ap"), Is.EqualTo(1));
        });

        this.trie.Add(LongString);

        Assert.That(this.trie.HowManyStartsWithPrefix("app"), Is.EqualTo(2));

        this.trie.Add(WithoutCommonPrefix);
        this.trie.Remove(NormalString);

        Assert.That(this.trie.HowManyStartsWithPrefix("ap"), Is.EqualTo(1));

        this.trie.Remove(PrefixNormalString);
        this.trie.Remove(LongString);

        Assert.That(this.trie.HowManyStartsWithPrefix("ap"), Is.EqualTo(0));
    }
}
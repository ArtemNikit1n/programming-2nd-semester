// <copyright file="TrieTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Tests;

/// <summary>
/// Tests for trie.
/// </summary>
public class TrieTests
{
    private static readonly List<byte> NormalData = [255, 32, 54, 123, 43];
    private static readonly List<byte> PrefixNormalData = [255, 32];
    private static readonly List<byte> LongData = [255, 32, 54, 123, 43, 23, 0, 54, 20, 4];
    private static readonly List<byte> WithoutCommonPrefix = [0, 32, 54, 123, 43, 23, 0, 54];
    private readonly List<byte> emptyData = [];

    private readonly Trie trie = new();

    /// <summary>
    /// Trie contains should return false for empty strig.
    /// </summary>
    [Test]
    public void Trie_Contains_ShouldReturnFalseForEmptyString()
    {
        Assert.That(this.trie.Contains(this.emptyData), Is.False);
    }

    /// <summary>
    /// Trie add should return false for empty string.
    /// </summary>
    [Test]
    public void Trie_Add_ShouldReturnFalseForEmptyString()
    {
        Assert.That(this.trie.Add(this.emptyData), Is.False);
    }

    /// <summary>
    /// Trie add should return true for non-empty string.
    /// </summary>
    [Test]
    public void Trie_Add_ShouldReturnTrueForNonEmptyString()
    {
        Assert.That(this.trie.Add(TrieTests.LongData), Is.True);
    }

    /// <summary>
    /// Trie add should return true for non-empty string (multiple).
    /// </summary>
    [Test]
    public void Trie_Add_ShouldReturnTrueForNonEmptyString_Multiple()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Add(TrieTests.NormalData), Is.True);
            Assert.That(this.trie.Add(TrieTests.PrefixNormalData), Is.True);
            Assert.That(this.trie.Add(TrieTests.LongData), Is.True);
            Assert.That(this.trie.Add(TrieTests.WithoutCommonPrefix), Is.True);
        });
    }

    /// <summary>
    /// Trie contains should return true for added string (multiple).
    /// </summary>
    [Test]
    public void Trie_Contains_ShouldReturnTrueForAddedString_Multiple()
    {
        this.trie.Add(NormalData);
        this.trie.Add(PrefixNormalData);
        this.trie.Add(LongData);
        this.trie.Add(WithoutCommonPrefix);

        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Contains(WithoutCommonPrefix), Is.True);
            Assert.That(this.trie.Contains(NormalData), Is.True);
            Assert.That(this.trie.Contains(PrefixNormalData), Is.True);
            Assert.That(this.trie.Contains(LongData), Is.True);
            Assert.That(this.trie.Contains(this.emptyData), Is.False);
        });
    }
}
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
    private static readonly List<byte>[] AllData = [NormalData, PrefixNormalData, LongData, WithoutCommonPrefix];
    private readonly List<byte> emptyData = [];

    private Trie trie;

    /// <summary>
    /// Creates trie.
    /// </summary>
    [SetUp]
    public void CreateTrie()
    {
        this.trie = new Trie();
    }

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
    /// <param name="data">A set of test data.</param>
    [Test]
    public void Trie_Add_ShouldReturnTrueForNonEmptyString([ValueSource(nameof(AllData))] List<byte> data)
    {
        Assert.That(this.trie.Add(data), Is.True);
    }

    /// <summary>
    /// Trie add should return true for non-empty string (multiple).
    /// </summary>
    /// <param name="data">A set of test data.</param>
    [Test]
    public void Trie_Add_ShouldReturnTrueForNonEmptyString_Multiple([ValueSource(nameof(AllData))] List<byte> data)
    {
        Assert.That(this.trie.Add(data), Is.True);
    }

    /// <summary>
    /// Trie contains should return true for added string (multiple).
    /// </summary>
    /// <param name="data">A set of test data.</param>
    [Test]
    public void Trie_Contains_ShouldReturnTrueForAddedString_Multiple([ValueSource(nameof(AllData))] List<byte> data)
    {
        this.trie.Add(data);
        Assert.That(this.trie.Contains(data), Is.True);
    }
}
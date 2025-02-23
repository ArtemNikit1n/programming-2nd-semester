// <copyright file="TrieTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trie;

/// <summary>
/// A class for running trie tests.
/// </summary>
public static class TrieTests
{
    /// <summary>
    /// Runs all trie tests.
    /// </summary>
    /// <returns>
    /// True == test PASSED.
    /// False == test FAILED.
    /// </returns>
    public static bool RunTests()
    {
        return TestAddAndContains();
    }

    private static bool TestAddAndContains()
    {
        Trie trie = new();

        var emptyString = string.Empty;
        const string normalString = "apple";
        const string prefixNormalString = "app";
        const string longString = "applesAndBananas";
        const string withoutCommonPrefix = "bananas";

        trie.Add(emptyString);
        trie.Add(normalString);
        trie.Add(prefixNormalString);
        trie.Add(longString);
        trie.Add(withoutCommonPrefix);

        return trie.Contains(withoutCommonPrefix) &&
               trie.Contains(normalString) &&
               trie.Contains(prefixNormalString) &&
               trie.Contains(longString) &&
               !trie.Contains(emptyString);
    }
}
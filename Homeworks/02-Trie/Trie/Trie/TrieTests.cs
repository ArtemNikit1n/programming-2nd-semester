// <copyright file="TrieTests.cs" company="ArtemNikit1n">
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
        return TestAddAndContains() && TestRemoveAndHowManyStartsWithPrefix();
    }

    private static bool TestAddAndContains()
    {
        Trie trie = new();

        var emptyString = string.Empty;
        const string normalString = "apple";
        const string prefixNormalString = "app";
        const string longString = "applesAndBananas";
        const string withoutCommonPrefix = "bananas";

        var hasStringBeenAdded = trie.Add(emptyString);
        if (hasStringBeenAdded && trie.Size != 0)
        {
            return false;
        }

        hasStringBeenAdded = trie.Add(normalString);
        if (!hasStringBeenAdded && trie.Size != 1)
        {
            return false;
        }

        hasStringBeenAdded = trie.Add(normalString);
        if (hasStringBeenAdded && trie.Size != 1)
        {
            return false;
        }

        trie.Add(prefixNormalString);
        trie.Add(longString);
        hasStringBeenAdded = trie.Add(withoutCommonPrefix);
        if (hasStringBeenAdded && trie.Size != 4)
        {
            return false;
        }

        return trie.Contains(withoutCommonPrefix) &&
               trie.Contains(normalString) &&
               trie.Contains(prefixNormalString) &&
               trie.Contains(longString) &&
               !trie.Contains(emptyString);
    }

    private static bool TestRemoveAndHowManyStartsWithPrefix()
    {
        Trie trie = new();

        var emptyString = string.Empty;
        const string normalString = "apple";
        const string prefixNormalString = "app";
        const string longString = "applesAndBananas";
        const string withoutCommonPrefix = "bananas";

        trie.Add(normalString);
        if (trie.HowManyStartsWithPrefix("123") != 0 && trie.HowManyStartsWithPrefix("ap") != 1)
        {
            return false;
        }

        trie.Add(prefixNormalString);
        if (trie.HowManyStartsWithPrefix("app") != 2 && trie.HowManyStartsWithPrefix(string.Empty) != 0)
        {
            return false;
        }

        trie.Add(longString);
        if (trie.HowManyStartsWithPrefix("app") != 3)
        {
            return false;
        }

        trie.Add(withoutCommonPrefix);

        var hasStringBeenDeleted = trie.Remove(emptyString);
        if (hasStringBeenDeleted && trie.Size != 4)
        {
            return false;
        }

        hasStringBeenDeleted = trie.Remove(normalString);
        if (!hasStringBeenDeleted && trie.Size != 3 && trie.HowManyStartsWithPrefix("ap") != 2)
        {
            return false;
        }

        hasStringBeenDeleted = trie.Remove(normalString);
        if (hasStringBeenDeleted && trie.Size != 3)
        {
            return false;
        }

        trie.Remove(prefixNormalString);
        trie.Remove(longString);

        hasStringBeenDeleted = trie.Remove(withoutCommonPrefix);
        if (!hasStringBeenDeleted && trie.Size != 0 && trie.HowManyStartsWithPrefix("ap") != 0)
        {
            return false;
        }

        return !trie.Contains(withoutCommonPrefix) &&
               !trie.Contains(normalString) &&
               !trie.Contains(prefixNormalString) &&
               !trie.Contains(longString) &&
               !trie.Contains(emptyString) &&
               !trie.Contains("a non-existent string");
    }
}
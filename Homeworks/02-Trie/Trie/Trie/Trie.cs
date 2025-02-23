// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trie;

/// <summary>
/// A data structure for storing a set of strings, which is a suspended tree with symbols on the edges.
/// </summary>
public class Trie
{
    private readonly TrieNode root = new();

    /// <summary>
    /// Gets you to find out the number of words inside the trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Adds an element to the trie.
    /// </summary>
    /// <param name="element">The string to be stored in the structure.</param>
    /// <returns>Returns true if there has not been such a row yet.</returns>
    public bool Add(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;
        foreach (var symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var nextNode))
            {
                nextNode = new TrieNode();
                currentNode.Children[symbol] = nextNode;
            }

            currentNode = nextNode;
        }

        if (currentNode.IsEndOfWord)
        {
            return false;
        }

        currentNode.IsEndOfWord = true;
        ++this.Size;
        return true;
    }

    /// <summary>
    /// Checks whether the string is contained in the trie.
    /// </summary>
    /// <param name="element">The desired string.</param>
    /// <returns>True means that the string is contained.</returns>
    public bool Contains(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;
        foreach (var symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var nextNode))
            {
                return false;
            }

            currentNode = nextNode;
        }

        return currentNode.IsEndOfWord;
    }

    public bool Remove(string element)
    {
        return false;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        return 0;
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new();
        public bool IsEndOfWord;
    }
}
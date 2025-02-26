// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trie;

/// <summary>
/// A data structure for storing a set of strings, which is a suspended tree with symbols on the edges.
/// </summary>
public class Trie
{
    private readonly TrieNode root = new(0, false);

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
                nextNode = new TrieNode(0, false);
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

        currentNode = this.root;
        foreach (var symbol in element)
        {
            currentNode = currentNode.Children[symbol];
            ++currentNode.WordCount;
        }

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

    /// <summary>
    /// Removes an element from the trie.
    /// </summary>
    /// <param name="element">The element to delete.</param>
    /// <returns>Returns true if the element was actually in the village.</returns>
    public bool Remove(string element)
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

        if (!currentNode.IsEndOfWord)
        {
            return false;
        }

        currentNode.IsEndOfWord = false;
        --this.Size;

        currentNode = this.root;
        foreach (var symbol in element)
        {
            currentNode = currentNode.Children[symbol];
            --currentNode.WordCount;
        }

        return true;
    }

    /// <summary>
    /// The function allows you to find out how many lines start with a given prefix.
    /// </summary>
    /// <param name="prefix">The prefix of the string.</param>
    /// <returns>The number of lines with the given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
        {
            return 0;
        }

        var currentNode = this.root;
        foreach (var symbol in prefix)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var nextNode))
            {
                return 0;
            }

            currentNode = nextNode;
        }

        return currentNode.WordCount;
    }

    private class TrieNode(int wordCount, bool isEndOfWord)
    {
        public readonly Dictionary<char, TrieNode> Children = new();
        public bool IsEndOfWord = isEndOfWord;
        public int WordCount = wordCount;
    }
}
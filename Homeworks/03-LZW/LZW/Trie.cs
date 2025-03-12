// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// This data structure allows you to store byte sequences and their unique codes.
/// </summary>
public class Trie
{
    private readonly TrieNode root = new(0, false);

    private int Size { get; set; }

    /// <summary>
    /// Adds a sequence to the trie.
    /// </summary>
    /// <param name="sequence">The sequence to be stored in the structure.</param>
    /// <returns>Returns true if there has not been such a row yet.</returns>
    public bool Add(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            return false;
        }

        var currentNode = this.root;
        foreach (var element in sequence)
        {
            if (!currentNode.Children.TryGetValue(element, out var nextNode))
            {
                nextNode = new TrieNode(0, false);
                currentNode.Children[element] = nextNode;
            }

            currentNode = nextNode;
        }

        if (currentNode.IsEndOfWord)
        {
            return false;
        }

        currentNode.IsEndOfWord = true;
        currentNode.Code = this.Size;
        ++this.Size;
        return true;
    }

    /// <summary>
    /// Checks whether the sequence is contained in the trie.
    /// </summary>
    /// <param name="sequence">The desired sequence.</param>
    /// <returns>True means that the sequence is contained.</returns>
    public bool Contains(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            return false;
        }

        var currentNode = this.root;
        foreach (var element in sequence)
        {
            if (!currentNode.Children.TryGetValue(element, out var nextNode))
            {
                return false;
            }

            currentNode = nextNode;
        }

        return currentNode.IsEndOfWord;
    }

    /// <summary>
    /// Allows you to find out the unique sequence code.
    /// </summary>
    /// <param name="sequence">The desired sequence.</param>
    /// <returns>-1 means that the sequence was not found.</returns>
    public int GetCode(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            return -1;
        }

        var currentNode = this.root;
        foreach (var element in sequence)
        {
            if (!currentNode.Children.TryGetValue(element, out var nextNode))
            {
                return -1;
            }

            currentNode = nextNode;
        }

        if (!currentNode.IsEndOfWord)
        {
            return -1;
        }

        return currentNode.Code;
    }

    private class TrieNode(int wordCount, bool isEndOfWord)
    {
        public readonly Dictionary<byte, TrieNode> Children = new();
        public bool IsEndOfWord = isEndOfWord;
        public int Code = 0;
    }
}
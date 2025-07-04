// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Trie;

if (!TrieTests.RunTests())
{
    Console.WriteLine("Tests FAILED.");
    return 1;
}

Console.WriteLine("Tests PASSED.");
return 0;
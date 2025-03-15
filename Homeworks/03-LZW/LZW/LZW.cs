// <copyright file="LZW.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// You can use this class to encode and decode files.
/// </summary>
public static class LZW
{
    /// <summary>
    /// Creates a compressed file with the extension ".zipped".
    /// </summary>
    /// <param name="filePath">The path to the file you want to compress.</param>
    /// <returns>True means that the file has been compressed successfully.</returns>
    public static (bool IsCompressionSuccessful, string OriginalExtension) Compress(string filePath)
    {
        if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath))
        {
            return (false, string.Empty);
        }

        var fileBytes = File.ReadAllBytes(filePath);
        var originalExtension = Path.GetExtension(filePath);
        List<ushort> compressedData = [];

        var trie = AddAlphabetToTrie();

        List<byte> currentBytes = [];
        foreach (var element in fileBytes)
        {
            currentBytes.Add(element);

            if (trie.Contains(currentBytes))
            {
                continue;
            }

            trie.Add(currentBytes);

            currentBytes.RemoveAt(currentBytes.Count - 1);
            if (trie.Size >= ushort.MaxValue || trie.GetCode(currentBytes) >= ushort.MaxValue)
            {
                return (false, originalExtension);
            }

            compressedData.Add((ushort)trie.GetCode(currentBytes));

            currentBytes = [element];
        }

        if (currentBytes.Count > 0)
        {
            if (trie.Size >= ushort.MaxValue || trie.GetCode(currentBytes) >= ushort.MaxValue)
            {
                return (false, originalExtension);
            }

            compressedData.Add((ushort)trie.GetCode(currentBytes));
        }

        CreateCompressedFile(compressedData, filePath);
        return (true, originalExtension);
    }

    /// <summary>
    /// Creates a decoded file with the original extension.
    /// </summary>
    /// <param name="filePath">The path to the compressed file.</param>
    /// <param name="fileExtension">Original extension.</param>
    /// <returns>True means that the file has been decompressed successfully.</returns>
    public static bool Decompress(string filePath, string fileExtension)
    {
        if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(fileExtension))
        {
            return false;
        }

        var compressedData = ReadCompressedFile(filePath);
        var dictionary = AddAlphabetToDictionary();
        List<byte> decompressedData = [];

        var startCode = compressedData[0];
        List<byte> currentSequence = new(dictionary[startCode]);

        for (var i = 1; i < compressedData.Count; ++i)
        {
            var nextCode = compressedData[i];
            List<byte> newSequence;

            if (dictionary.TryGetValue(nextCode, out var value))
            {
                var nextSequence = new List<byte>(value);

                newSequence =
                [
                    ..currentSequence,
                    nextSequence[0]
                ];

                if (!dictionary.ContainsValue(newSequence))
                {
                    decompressedData.AddRange(currentSequence);
                }

                if (dictionary.Count > ushort.MaxValue)
                {
                    return false;
                }

                dictionary.Add((ushort)dictionary.Count, newSequence);

                currentSequence = nextSequence;
            }
            else
            {
                newSequence =
                [
                    ..currentSequence,
                    currentSequence[0]
                ];

                if (!dictionary.ContainsValue(newSequence))
                {
                    decompressedData.AddRange(currentSequence);
                }

                if (dictionary.Count > ushort.MaxValue)
                {
                    return false;
                }

                dictionary.Add((ushort)dictionary.Count, newSequence);

                currentSequence = newSequence;
            }
        }

        decompressedData.AddRange(currentSequence);

        CreateDecompressedFile(decompressedData, filePath, fileExtension);
        return true;
    }

    private static List<ushort> ReadCompressedFile(string filePath)
    {
        List<ushort> compressedData = [];

        using var reader = new BinaryReader(File.Open(filePath, FileMode.Open));
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            compressedData.Add(reader.ReadUInt16());
        }

        return compressedData;
    }

    private static void CreateDecompressedFile(List<byte> decompressedData, string filePath, string fileExtension)
    {
        var outputPath = Path.ChangeExtension(filePath, fileExtension);
        File.WriteAllBytes(outputPath, decompressedData.ToArray());
    }

    private static void CreateCompressedFile(List<ushort> compressedData, string filePath)
    {
        var outputPath = Path.ChangeExtension(filePath, ".zipped");
        using var writer = new BinaryWriter(File.Open(outputPath, FileMode.Create));
        foreach (var code in compressedData)
        {
            writer.Write(code);
        }
    }

    private static Trie AddAlphabetToTrie()
    {
        var trie = new Trie();
        for (var i = 0; i < 256; ++i)
        {
            List<byte> currentByte = [(byte)i];
            trie.Add(currentByte);
        }

        return trie;
    }

    private static Dictionary<ushort, List<byte>> AddAlphabetToDictionary()
    {
        Dictionary<ushort, List<byte>> dictionary = [];
        for (ushort i = 0; i < 256; i++)
        {
            dictionary.Add(i, [(byte)i]);
        }

        return dictionary;
    }
}
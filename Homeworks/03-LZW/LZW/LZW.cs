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
    public static bool Compress(string filePath)
    {
        if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath))
        {
            return false;
        }

        var fileBytes = File.ReadAllBytes(filePath);
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
                return false;
            }

            compressedData.Add((ushort)trie.GetCode(currentBytes));

            currentBytes = [element];
        }

        if (currentBytes.Count > 0)
        {
            if (trie.Size >= ushort.MaxValue || trie.GetCode(currentBytes) >= ushort.MaxValue)
            {
                return false;
            }

            compressedData.Add((ushort)trie.GetCode(currentBytes));
        }

        CreateCompressedFile(compressedData, filePath);
        return true;
    }

    /// <summary>
    /// Creates a decoded file with the original extension.
    /// </summary>
    /// <param name="filePath">The path to the compressed file.</param>
    /// <returns>True means that the file has been decompressed successfully.</returns>
    public static bool Decompress(string filePath)
    {
        if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath))
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

        CreateDecompressedFile(decompressedData, filePath);
        return true;
    }

    /// <summary>
    /// Compresses files with and without BWT and calculates the compression ratio.
    /// </summary>
    /// <param name="filePath">The path to the file you want to compress.</param>
    /// <returns>Compression Ratio With BWT and without BWT.</returns>
    public static (double BWTCompressionRatio, double CompressionRatio) CalculateCompressionRatioWithAndWithoutBWT(
        string filePath)
    {
        var fileBytes = File.ReadAllBytes(filePath);
        var (transformedSequence, endPosition) = BWT.Transform(fileBytes.ToList());

        var fileName = Path.GetFileName(filePath);
        var bwtPath = Path.Combine(Path.GetDirectoryName(filePath)!, fileName + ".BWT");
        File.WriteAllBytes(bwtPath, transformedSequence.ToArray());

        Compress(bwtPath);
        Compress(filePath);

        return (CalculateCompressionRatio(bwtPath), CalculateCompressionRatio(filePath));
    }

    private static double CalculateCompressionRatio(string filePath)
    {
        FileInfo fileInfo = new(filePath);
        FileInfo compressedFileInfo = new(filePath + ".zipped");
        if (compressedFileInfo.Length == 0)
        {
            return -1;
        }

        return (double)fileInfo.Length / compressedFileInfo.Length;
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

    private static void CreateDecompressedFile(List<byte> decompressedData, string filePath)
    {
        var outputPath = Path.ChangeExtension(filePath, string.Empty);
        File.WriteAllBytes(outputPath, decompressedData.ToArray());
    }

    private static void CreateCompressedFile(List<ushort> compressedData, string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var newFileName = fileName + ".zipped";
        var outputPath = Path.Combine(Path.GetDirectoryName(filePath)!, newFileName);

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
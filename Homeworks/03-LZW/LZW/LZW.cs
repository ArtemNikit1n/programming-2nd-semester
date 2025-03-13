namespace LZW;

public static class LZW
{
    /// <summary>
    /// The function compresses the file and adds an extension to it ".zipped".
    /// </summary>
    /// <param name="filePath">The path to the file you want to compress.</param>
    public static void Compress(string filePath)
    {
        var fileBytes = File.ReadAllBytes(filePath);
        List<int> compressedData = [];

        var trie = AddAlphabetToDictionary();

        List<byte> currentBytes = [];
        for (var i = 0; i < fileBytes.Length; ++i)
        {
            currentBytes.Add(fileBytes[i]);

            if (trie.Contains(currentBytes))
            {
                continue;
            }

            trie.Add(currentBytes);
            compressedData.Add(trie.GetCode(currentBytes));

            currentBytes = [fileBytes[i]];
        }

        if (currentBytes.Count > 0 && !trie.Contains(currentBytes))
        {
            trie.Add(currentBytes);
            compressedData.Add(trie.GetCode(currentBytes));
        }

        var compressedBytes = compressedData.SelectMany(BitConverter.GetBytes).ToArray();
        var outputPath = Path.ChangeExtension(filePath, ".zipped");
        File.WriteAllBytes(outputPath, compressedBytes);
    }

    public static void Decompress(string compressedString)
    {
        Console.WriteLine(compressedString);
    }

    private static Trie AddAlphabetToDictionary()
    {
        var trie = new Trie();
        for (byte i = 0; i != 255; ++i)
        {
            List<byte> currentByte = [i];
            trie.Add(currentByte);
        }

        return trie;
    }
}
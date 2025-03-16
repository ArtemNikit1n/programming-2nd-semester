// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

Console.WriteLine("Hello ^_^! It is LZW algorithm.\n<filePath> <-c> compress the file\n<filePath> <-u> decompress the file");

if (args.Length != 2)
{
    Console.WriteLine("Using: LZW.exe <filePath> <-c or -u>");
    return 0;
}

var filePath = args[0];
var operation = args[1];

if (!File.Exists(filePath))
{
    Console.WriteLine("File not found: " + filePath);
    return 1;
}

switch (operation)
{
    case "-c":
        if (!LZW.LZW.Compress(filePath))
        {
            return 1;
        }

        FileInfo fileInfo = new(filePath);
        FileInfo compressedFileInfo = new(filePath + ".zipped");
        if (compressedFileInfo.Length != 0)
        {
            var compressionRatio = (double)fileInfo.Length / compressedFileInfo.Length;
            Console.WriteLine(
                "File compressed successfully" +
                "\nCompression ratio: {0}",
                compressionRatio);
        }
        else
        {
            Console.WriteLine("File is empty");
        }

        return 0;
    case "-u":
        if (!LZW.LZW.Decompress(filePath))
        {
            return 1;
        }

        Console.WriteLine("File Decompressed successfully");
        return 0;
    default:
        Console.WriteLine("Invalid key. Use -c for compression or -u for decompression.");
        break;
}

return 0;

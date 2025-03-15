// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

Console.WriteLine("Hello ^_^! It is LZW algorithm.");

var (isCompressionSuccessful, originalExtension) = LZW.LZW.Compress(@"..\..\..\Data.txt");
if (!isCompressionSuccessful)
{
    return 1;
}

return !LZW.LZW.Decompress(@"..\..\..\Data.zipped", originalExtension) ? 1 : 0;
// <copyright file="LZWTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Tests;

/// <summary>
/// Tests for LZW.
/// </summary>
public class LZWTests
{
    private const string NormalDataPath = @"..\..\..\TestData\NormalData.txt";
    private const string CompressedNormalDataPath = @"..\..\..\TestData\NormalData.txt.zipped";
    private const string BWTCompressedNormalDataPath = @"..\..\..\TestData\NormalData.txt.BWT.zipped";
    private const string EmptyDataPath = @"..\..\..\TestData\EmptyData.txt";
    private const string CompressedEmptyDataPath = @"..\..\..\TestData\EmptyData.txt.zipped";
    private const string BinaryFilePath = @"..\..\..\TestData\LZW.exe";
    private const string CompressedBinaryFilePath = @"..\..\..\TestData\LZW.exe.zipped";
    private const string BWTCompressedBinaryFilePath = @"..\..\..\TestData\LZW.exe.BWT.zipped";

    /// <summary>
    /// This test is needed to verify that all files are being created correctly (it is also used to compare compression ratios with and without BWT).
    /// </summary>
    [Test]
    public void LZW_CalculateCompressionRatioWithAndWithoutBWT_ShouldCompressFileUsingBWT_Multiple()
    {
        var (bwtCompressionRatioNormalData, compressionRatioNormalData) = LZW.CalculateCompressionRatioWithAndWithoutBWT(NormalDataPath);
        var (bwtCompressionRatioBinaryFile, compressionRatioBinaryFile) = LZW.CalculateCompressionRatioWithAndWithoutBWT(BinaryFilePath);
        Assert.Multiple(() =>
        {
            Assert.That(File.Exists(BWTCompressedNormalDataPath), Is.True);
            Assert.That(File.Exists(BWTCompressedBinaryFilePath), Is.True);
        });
    }

    /// <summary>
    /// LZW should compress and decompress binary file correctly.
    /// </summary>
    [Test]
    public void LZW_ShouldCompressAndDecompressBinaryFileCorrectly()
    {
        var expectedData = File.ReadAllBytes(BinaryFilePath);
        Assert.Multiple(() =>
        {
            Assert.That(LZW.Compress(BinaryFilePath), Is.True);
            Assert.That(LZW.Decompress(CompressedBinaryFilePath), Is.True);
            Assert.That(File.ReadAllBytes(BinaryFilePath), Is.EqualTo(expectedData));
        });
    }

    /// <summary>
    /// LZW should compress and decompress normal data correctly.
    /// </summary>
    [Test]
    public void LZW_ShouldCompressAndDecompressNormalDataCorrectly()
    {
        var expectedData = File.ReadAllBytes(NormalDataPath);
        Assert.Multiple(() =>
        {
            Assert.That(LZW.Compress(NormalDataPath), Is.True);
            Assert.That(LZW.Decompress(CompressedNormalDataPath), Is.True);
            Assert.That(File.ReadAllBytes(NormalDataPath), Is.EqualTo(expectedData));
        });
    }

    /// <summary>
    /// LZW compress should correctly process empty data.
    /// </summary>
    [Test]
    public void LZW_Compress_ShouldCorrectlyProcessEmptyData()
    {
        Assert.That(LZW.Compress(EmptyDataPath), Is.True);
        var compressedEmptyDataBytes = ReadCompressedFile(CompressedEmptyDataPath);
        List<ushort> expectedEmptyDataBytes = [];
        Assert.That(compressedEmptyDataBytes, Is.EqualTo(expectedEmptyDataBytes));
    }

    /// <summary>
    /// LZW compress should create file with correct compressed data.
    /// </summary>
    [Test]
    public void LZW_Compress_ShouldCreateFileWithCorrectCompressedData()
    {
        Assert.That(LZW.Compress(NormalDataPath), Is.True);
        var compressedNormalDataBytes = ReadCompressedFile(CompressedNormalDataPath);
        List<ushort> expectedNormalDataBytes = [65, 66, 256, 258];
        Assert.That(compressedNormalDataBytes, Is.EqualTo(expectedNormalDataBytes));
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
}
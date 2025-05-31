// <copyright file="BWT.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BurrowsWheelerTransformer;

using System.Text;

/// <summary>
/// This is a class for applying the forward and reverse Burrows-Wheeler transformations to a string.
/// </summary>
public static class BWT
{
    /// <summary>
    /// Performs a direct Barrows-Wheeler transformation.
    /// </summary>
    /// <param name="input">The string that the conversion is being performed on.</param>
    /// <returns>The first parameter returns the converted string, and the second parameter returns the index of the last character in that string.</returns>
    public static (string TransformedString, int EndPosition) Transform(string input)
    {
        if (input == string.Empty)
        {
            return (string.Empty, -1);
        }

        var rotations = GenerateRotations(input);
        Array.Sort(rotations);
        var lastColumn = GetLastColumn(rotations);
        return (lastColumn.Permutation, lastColumn.EndPosition);
    }

    /// <summary>
    /// Builds the original version of the transformed string.
    /// </summary>
    /// <param name="transformedString">The string after the conversion.</param>
    /// <param name="endPosition">The index of the last character.</param>
    /// <returns>The original line.</returns>
    public static string InverseTransform(string transformedString, int endPosition)
    {
        if (transformedString == string.Empty)
        {
            return string.Empty;
        }

        var (frequencies, rank) = CountNumberOfEachSymbolAndItsRank(transformedString);
        var firstOccurrence = GetDictionaryOfFirstOccurrences(frequencies);

        return string.Create(transformedString.Length, (transformedString, endPosition), (span, state) =>
        {
            var index = state.endPosition;

            for (var i = state.transformedString.Length - 1; i >= 0; --i)
            {
                var symbol = state.transformedString[index];
                span[i] = symbol;
                index = firstOccurrence[symbol] + rank[index];
            }
        });
    }

    /// <summary>
    /// A method for calling InverseTransform via a tuple.
    /// </summary>
    /// <param name="transformedString">A pair consisting of a string and an end position.</param>
    /// <returns>The original line.</returns>
    public static string InverseTransform((string TransformedString, int EndPosition) transformedString)
    {
        return InverseTransform(transformedString.TransformedString, transformedString.EndPosition);
    }

    private static Rotation GetLastColumn(Rotation[] rotations)
    {
        var lastColumn = new StringBuilder(new string('\0', rotations.Length));
        var endPosition = 0;

        for (var i = 0; i < rotations.Length; ++i)
        {
            var rotation = rotations[i];
            if (rotation.EndPosition == 0)
            {
                endPosition = i;
            }

            lastColumn[i] = rotation.Permutation[((rotation.EndPosition - 1) + rotations.Length) % rotations.Length];
        }

        var resultingRotation = new Rotation(lastColumn.ToString(), endPosition);

        return resultingRotation;
    }

    private static Rotation[] GenerateRotations(string input)
    {
        var rotations = new Rotation[input.Length];

        for (var i = 0; i < input.Length; ++i)
        {
            rotations[i] = new Rotation(input, i);
        }

        return rotations;
    }

    private static Dictionary<char, int> GetDictionaryOfFirstOccurrences(Dictionary<char, int> frequencies)
    {
        var sortedSymbols = new List<char>(frequencies.Keys);
        sortedSymbols.Sort();

        var firstOccurrence = new Dictionary<char, int>();
        var cumulativeCount = 0;

        foreach (var symbol in sortedSymbols)
        {
            firstOccurrence[symbol] = cumulativeCount;
            cumulativeCount += frequencies[symbol];
        }

        return firstOccurrence;
    }

    private static (Dictionary<char, int> Frequencies, int[] Rank) CountNumberOfEachSymbolAndItsRank(string input)
    {
        var rank = new int[input.Length];
        var frequencies = new Dictionary<char, int>();
        for (var i = 0; i < input.Length; i++)
        {
            var symbol = input[i];

            if (!frequencies.TryAdd(symbol, 1))
            {
                rank[i] = frequencies[symbol];
                frequencies[symbol]++;
            }
            else
            {
                rank[i] = 0;
            }
        }

        return (frequencies, rank);
    }

    private readonly struct Rotation(string stringForCyclicShifts, int endPosition) : IComparable<Rotation>
    {
        public string Permutation { get; } = stringForCyclicShifts;

        public int EndPosition { get; } = endPosition;

        public int CompareTo(Rotation other)
        {
            if (string.IsNullOrEmpty(this.Permutation))
            {
                return string.IsNullOrEmpty(other.Permutation) ? 0 : -1;
            }

            if (string.IsNullOrEmpty(other.Permutation))
            {
                return 1;
            }

            var i = this.EndPosition % this.Permutation.Length;
            var j = other.EndPosition % other.Permutation.Length;

            foreach (var _ in this.Permutation)
            {
                if (this.Permutation[i] != other.Permutation[j])
                {
                    return this.Permutation[i].CompareTo(other.Permutation[j]);
                }

                i = (i + 1) % this.Permutation.Length;
                j = (j + 1) % other.Permutation.Length;
            }

            return 0;
        }
    }
}
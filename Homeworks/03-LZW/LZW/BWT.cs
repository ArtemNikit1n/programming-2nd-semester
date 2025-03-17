// <copyright file="BWT.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW
{
    /// <summary>
    /// This is a class for applying the forward and reverse Burrows-Wheeler transformations to a byte sequence.
    /// </summary>
    public static class BWT
    {
        /// <summary>
        /// Performs a direct Barrows-Wheeler transformation.
        /// </summary>
        /// <param name="input">The byte sequence that the conversion is being performed on.</param>
        /// <returns>The first parameter returns the converted byte sequence, and the second parameter returns the index of the last byte in that byte sequence.</returns>
        public static (List<byte> TransformedSequence, int EndPosition) Transform(List<byte> input)
        {
            if (input.Count == 0)
            {
                return (input, -1);
            }

            var rotations = GenerateRotations(input);
            Array.Sort(rotations);
            var lastColumn = GetLastColumn(rotations);
            return (lastColumn.Permutation, lastColumn.EndPosition);
        }

        /// <summary>
        /// Builds the original version of the transformed byte sequence.
        /// </summary>
        /// <param name="transformedSequence">The byte sequence after the conversion.</param>
        /// <param name="endPosition">The index of the last byte.</param>
        /// <returns>The original sequence.</returns>
        public static List<byte> InverseTransform(List<byte> transformedSequence, int endPosition)
        {
            if (transformedSequence.Count == 0)
            {
                return transformedSequence;
            }

            var (frequencies, rank) = CountNumberOfEachSymbolAndItsRank(transformedSequence);
            var firstOccurrence = GetDictionaryOfFirstOccurrences(frequencies);

            List<byte> result = [];
            var currentPosition = endPosition;

            foreach (var currentSymbol in transformedSequence.Select(element => transformedSequence[currentPosition]))
            {
                result.Add(currentSymbol);

                currentPosition = firstOccurrence[currentSymbol] + rank[currentPosition];
            }

            result.Reverse();
            return result;
        }

        private static Rotation GetLastColumn(Rotation[] rotations)
        {
            List<byte> lastColumn = new(rotations.Length);

            var endPosition = 0;

            for (var i = 0; i < rotations.Length; ++i)
            {
                var rotation = rotations[i];
                if (rotation.EndPosition == 0)
                {
                    endPosition = i;
                }

                lastColumn.Add(rotation.Permutation[(((rotation.EndPosition - 1) % rotations.Length) + rotations.Length) % rotations.Length]);
            }

            return new Rotation(lastColumn, endPosition);
        }

        private static Rotation[] GenerateRotations(List<byte> input)
        {
            var rotations = new Rotation[input.Count];

            for (var i = 0; i < input.Count; ++i)
            {
                rotations[i] = new Rotation(input, i);
            }

            return rotations;
        }

        private static Dictionary<byte, int> GetDictionaryOfFirstOccurrences(Dictionary<byte, int> frequencies)
        {
            List<byte> sortedSymbols = new(frequencies.Keys);
            sortedSymbols.Sort();

            Dictionary<byte, int> firstOccurrence = new();
            var cumulativeCount = 0;

            foreach (var symbol in sortedSymbols)
            {
                firstOccurrence[symbol] = cumulativeCount;
                cumulativeCount += frequencies[symbol];
            }

            return firstOccurrence;
        }

        private static (Dictionary<byte, int> Frequencies, int[] Rank) CountNumberOfEachSymbolAndItsRank(List<byte> input)
        {
            var rank = new int[input.Count];
            var frequencies = new Dictionary<byte, int>();
            for (var i = 0; i < input.Count; i++)
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

        private readonly struct Rotation(List<byte> sequenceForCyclicShifts, int endPosition) : IComparable<Rotation>
        {
            public List<byte> Permutation { get; } = sequenceForCyclicShifts;

            public int EndPosition { get; } = endPosition;

            public int CompareTo(Rotation other)
            {
                if (this.Permutation.Count == 0)
                {
                    return other.Permutation.Count == 0 ? 0 : -1;
                }

                if (other.Permutation.Count == 0)
                {
                    return 1;
                }

                var i = this.EndPosition % this.Permutation.Count;
                var j = other.EndPosition % other.Permutation.Count;

                foreach (var unused in this.Permutation)
                {
                    if (this.Permutation[i] != other.Permutation[j])
                    {
                        return this.Permutation[i].CompareTo(other.Permutation[j]);
                    }

                    i = (i + 1) % this.Permutation.Count;
                    j = (j + 1) % other.Permutation.Count;
                }

                return 0;
            }
        }
    }
}
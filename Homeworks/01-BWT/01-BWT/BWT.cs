using System.Text;

namespace BWT
{
    public abstract class BurrowsWheelerTransformer
    {
        private readonly struct Rotation(string permutation, int endPosition) : IComparable<Rotation>
        {
            public string Permutation { get; } = permutation;
            public int EndPosition { get; } = endPosition;

            public int CompareTo(Rotation other)
            {
                for (var i = 0; i < Permutation.Length; i++)
                {
                    var currentChar = Permutation[i];
                    var otherChar = other.Permutation[i];

                    if (i == EndPosition && i != other.EndPosition)
                        return 1;
                    if (i == other.EndPosition && i != EndPosition)
                        return -1;

                    if (currentChar != otherChar)
                        return currentChar.CompareTo(otherChar);
                }
                return 0;
            }
        }

        private static Rotation[] GenerateRotations(string input)
        {
            var rotations = new Rotation[input.Length];

            for (var i = 0; i < input.Length; ++i)
            {
                var permutation = string.Concat(input.AsSpan(i), input.AsSpan(0, i));
                rotations[i] = new Rotation(permutation, i);
            }
            return rotations;
        }

        private static Rotation GetLastColumn(Rotation[] rotations)
        {
            var lastColumn = new StringBuilder();
            var endPosition = 0;

            for (var i = 0; i < rotations.Length; ++i)
            {
                var rotation = rotations[i];
                if (rotation.EndPosition == 0)
                {
                    endPosition = i;
                }
                lastColumn.Append(rotation.Permutation[^1]);
            }
            var resultingRotation = new Rotation(lastColumn.ToString(), endPosition);

            return resultingRotation;
        }

        public static (string transformedString, int endPosition) Transform(string input)
        {
            var rotations = GenerateRotations(input);
            Array.Sort(rotations);
            var lastColumn = GetLastColumn(rotations);
            return (lastColumn.Permutation, lastColumn.EndPosition);
        }

        private static (Dictionary<char, int>, int[]) CountNumberOfEachSymbolAndItsRank(string input)
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

        private static Dictionary<char, int> GetDictionaryOfFirstOccurrences(Dictionary<char, int> frequencies)
        {
            var sortedSymbols = new List<char>(frequencies.Keys);
            sortedSymbols.Sort();
            
            var firstOccurrence = new Dictionary<char, int>();
            var cumulativeCount = 0;
            
            foreach (char symbol in sortedSymbols)
            {
                firstOccurrence[symbol] = cumulativeCount;
                cumulativeCount += frequencies[symbol];
            }
            
            return firstOccurrence;
        }

        public static string InverseTransform(string transformedString, int endPosition)
        {
            var (frequencies, rank) = CountNumberOfEachSymbolAndItsRank(transformedString);
            var firstOccurrence = GetDictionaryOfFirstOccurrences(frequencies);
            return transformedString[endPosition..];
        }
    }
}
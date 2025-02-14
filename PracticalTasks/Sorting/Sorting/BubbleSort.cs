using System;

namespace Sorting
{
    internal static class BubbleSort
    {
        private static void Main(string[] args)
        {
            if (!Tests.RunTests())
            {
                Console.WriteLine("Test FAILED");
                return;
            }
            Console.WriteLine("Test PASSED");
        }

        public static void BubbleSortArray(int[] array)
        {
            var isArraySorted = true;
            for (var i = 0; i < array.Length - 1; ++i)
            {
                for (var j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] <= array[j + 1])
                    {
                        continue;
                    }
                    Swap(array, j, j + 1);
                    isArraySorted = false;
                }
                if (isArraySorted) 
                {
                    break;
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    internal static class Tests
    {
        private static bool IsArraySorted(int[] array)
        {
            for (var i = 0; i < array.Length - 1; ++i)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool RunTests()
        {
            int[] regularArray = [5, 3, -8, 4, 2];
            BubbleSort.BubbleSortArray(regularArray);
            if (!IsArraySorted(regularArray))
            {
                return false;
            }
            int[] sortedArray = [-1, 2, 3, 4, 5];
            BubbleSort.BubbleSortArray(regularArray);
            if (!IsArraySorted(regularArray))
            {
                return false;
            }
            
            int[] nullArray = [0];
            BubbleSort.BubbleSortArray(regularArray);
            return IsArraySorted(regularArray);
        }
    }
}

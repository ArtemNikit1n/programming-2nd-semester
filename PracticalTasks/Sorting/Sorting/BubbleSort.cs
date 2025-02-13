using System;

namespace Sorting
{
    internal static class BubbleSort
    {
        private static void Main(string[] args)
        {
            int[] array = [5, 3, 8, 4, 2];

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            BubbleSortArray(array);

            Console.WriteLine("\nОтсортированный массив:");
            PrintArray(array);
        }

        private static void BubbleSortArray(int[] array)
        {
            var arrayLength = array.Length;
            var isArraySorted = true;
            for (var i = 0; i < arrayLength - 1; ++i)
            {
                for (var j = 0; j < arrayLength - i - 1; ++j)
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

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

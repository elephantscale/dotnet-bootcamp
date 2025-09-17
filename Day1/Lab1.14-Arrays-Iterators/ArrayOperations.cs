using System;
using System.Linq;

namespace Lab1_14
{
    public static class ArrayOperations
    {
        public static void Run()
        {
            Basics();
            MultidimensionalAndJagged();
            MethodsAndSearching();
            IterationPatterns();
        }

        static void Basics()
        {
            Console.WriteLine("=== Array Basics ===\n");

            int[] numbers = { 5, 3, 9, 1, 4 };
            Console.WriteLine($"numbers.Length = {numbers.Length}");
            Console.WriteLine($"First = {numbers[0]}, Last = {numbers[^1]}");

            // Bounds check demo (safe)
            int idx = 10;
            Console.WriteLine($"Index {idx} inside bounds? {idx >= 0 && idx < numbers.Length}\n");
        }

        static void MultidimensionalAndJagged()
        {
            Console.WriteLine("=== Multidimensional & Jagged Arrays ===\n");

            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine($"matrix.Rank = {matrix.Rank}, size = {matrix.GetLength(0)}x{matrix.GetLength(1)}");
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                    Console.Write($"{matrix[r, c],3}");
                Console.WriteLine();
            }

            Console.WriteLine();
            int[][] jagged =
            [
                new[] { 1, 2, 3 },
                new[] { 10, 20 },
                new[] { 7 }
            ];
            for (int r = 0; r < jagged.Length; r++)
                Console.WriteLine($"Row {r} (len {jagged[r].Length}): [{string.Join(", ", jagged[r])}]");

            Console.WriteLine();
        }

        static void MethodsAndSearching()
        {
            Console.WriteLine("=== Array Methods & Searching ===\n");

            int[] data = { 5, 3, 9, 1, 4, 9 };
            Console.WriteLine($"Original:  [{string.Join(", ", data)}]");

            var copy = (int[])data.Clone();
            Array.Sort(copy);               // In-place sort
            Console.WriteLine($"Sorted:    [{string.Join(", ", copy)}]");

            Array.Reverse(copy);            // Reverse
            Console.WriteLine($"Reversed:  [{string.Join(", ", copy)}]");

            int firstIndex = Array.IndexOf(data, 9);
            Console.WriteLine($"First 9 in original at index {firstIndex}");

            Array.Sort(copy);               // BinarySearch requires sorted
            int found = Array.BinarySearch(copy, 4);
            Console.WriteLine($"BinarySearch 4 in sorted -> index {found}");

            // Array.Copy
            int[] bigger = new int[10];
            Array.Copy(data, 0, bigger, 0, data.Length);
            Console.WriteLine($"Copied to bigger: [{string.Join(", ", bigger)}]");

            // Linear search (manual)
            int target = 1;
            int i = LinearSearch(data, target);
            Console.WriteLine($"LinearSearch({target}) -> {i}\n");
        }

        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target) return i;
            return -1;
        }

        static void IterationPatterns()
        {
            Console.WriteLine("=== Iteration Patterns ===\n");
            int[] values = { 2, 4, 6, 8, 10 };

            Console.WriteLine("for:");
            for (int i = 0; i < values.Length; i++)
                Console.Write($"{values[i]} ");
            Console.WriteLine();

            Console.WriteLine("foreach:");
            foreach (var v in values) Console.Write($"{v} ");
            Console.WriteLine();

            Console.WriteLine("while:");
            int k = 0; while (k < values.Length) { Console.Write($"{values[k]} "); k++; }
            Console.WriteLine("\n");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_14
{
    public static class PracticalArrayExamples
    {
        public static void Run()
        {
            StudentGradeManager();
            InventorySystem();
            MatrixOperations();
        }

        // --- 1) Student Grade Manager (parallel + jagged arrays) ---
        static void StudentGradeManager()
        {
            Console.WriteLine("=== Student Grade Manager ===\n");

            string[] students = { "Alice", "Bob", "Cara", "Diego" };
            int[][] scores =
            [
                new[] { 90, 84, 88 },      // Alice
                new[] { 72, 70 },          // Bob
                new[] { 100, 98, 97, 96 }, // Cara
                new[] { 80, 82, 78 }       // Diego
            ];

            double[] avgs = scores.Select(arr => arr.Average()).ToArray();

            // Ranking via index array sorted by average (desc)
            int[] order = Enumerable.Range(0, students.Length).ToArray();
            Array.Sort(order, (i, j) => avgs[j].CompareTo(avgs[i]));

            Console.WriteLine("Averages:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine($"  {students[i],-6} : {avgs[i]:F1}");

            Console.WriteLine("\nRanking:");
            for (int rank = 0; rank < order.Length; rank++)
            {
                int i = order[rank];
                Console.WriteLine($"  #{rank + 1}: {students[i]} (avg {avgs[i]:F1})");
            }
            Console.WriteLine();
        }

        // --- 2) Inventory system (Dictionary) ---
        static void InventorySystem()
        {
            Console.WriteLine("=== Inventory System ===\n");

            var inventory = new Dictionary<string, (decimal Price, int Stock)>
            {
                ["Keyboard"] = (49.99m, 8),
                ["Mouse"] = (19.99m, 3),
                ["Monitor"] = (199.99m, 5),
                ["Cable"] = (9.99m, 20),
            };
            const int threshold = 5;

            var orders = new (string Item, int Qty)[] { ("Mouse", 2), ("Monitor", 6), ("Cable", 7) };

            foreach (var (item, qty) in orders)
            {
                if (!inventory.TryGetValue(item, out var entry))
                {
                    Console.WriteLine($"  Unknown item '{item}' (skipped)");
                    continue;
                }

                if (entry.Stock < qty)
                {
                    Console.WriteLine($"  Not enough stock for {item}: have {entry.Stock}, need {qty}");
                    continue;
                }

                entry.Stock -= qty;
                inventory[item] = entry;
                Console.WriteLine($"  Sold {qty} x {item} @ {entry.Price:C} -> remaining {entry.Stock}");
                if (entry.Stock <= threshold) Console.WriteLine($"    ⚠ Low stock: {item} (<= {threshold})");
            }

            Console.WriteLine("\nCurrent inventory:");
            foreach (var kv in inventory)
                Console.WriteLine($"  {kv.Key,-8} | {kv.Value.Price,8:C} | stock {kv.Value.Stock}");
            Console.WriteLine();
        }

        // --- 3) Matrix operations (2D arrays) ---
        static void MatrixOperations()
        {
            Console.WriteLine("=== Matrix Operations (2D arrays) ===\n");

            int[,] A = { { 1, 2 }, { 3, 4 } };
            int[,] B = { { 5, 6 }, { 7, 8 } };

            var sum = Add(A, B);
            var prod = Multiply(A, B);
            var tA = Transpose(A);

            Console.WriteLine("A:"); PrintMatrix(A);
            Console.WriteLine("B:"); PrintMatrix(B);
            Console.WriteLine("A + B:"); PrintMatrix(sum);
            Console.WriteLine("A * B:"); PrintMatrix(prod);
            Console.WriteLine("Transpose(A):"); PrintMatrix(tA);
            Console.WriteLine();
        }

        static int[,] Add(int[,] x, int[,] y)
        {
            int r = x.GetLength(0), c = x.GetLength(1);
            var z = new int[r, c];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    z[i, j] = x[i, j] + y[i, j];
            return z;
        }

        static int[,] Multiply(int[,] x, int[,] y)
        {
            int r = x.GetLength(0), n = x.GetLength(1), c = y.GetLength(1);
            var z = new int[r, c];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    for (int k = 0; k < n; k++)
                        z[i, j] += x[i, k] * y[k, j];
            return z;
        }

        static int[,] Transpose(int[,] m)
        {
            int r = m.GetLength(0), c = m.GetLength(1);
            var t = new int[c, r];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    t[j, i] = m[i, j];
            return t;
        }

        static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    Console.Write($"{m[i, j],4}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
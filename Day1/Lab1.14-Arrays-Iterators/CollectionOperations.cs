using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_14
{
    public static class CollectionOperations
    {
        public static void Run()
        {
            Lists();
            Dictionaries();
            HashSets();
            QueuesAndStacks();
            LinkedLists();
        }

        static void Lists()
        {
            Console.WriteLine("=== List<T> ===\n");
            var list = new List<int> { 1, 2, 3 };
            list.Add(4);
            list.Insert(0, 0);
            Console.WriteLine($"List: [{string.Join(", ", list)}]");
            list.Remove(2);
            list.RemoveAt(list.Count - 1);
            Console.WriteLine($"After removes: [{string.Join(", ", list)}]");
            Console.WriteLine($"Contains 3? {list.Contains(3)}\n");
        }

        static void Dictionaries()
        {
            Console.WriteLine("=== Dictionary<TKey,TValue> ===\n");
            var prices = new Dictionary<string, decimal>
            {
                ["apple"] = 0.99m,
                ["banana"] = 0.59m,
                ["orange"] = 0.79m
            };

            prices["banana"] = 0.69m; // update
            if (prices.TryGetValue("orange", out var p))
                Console.WriteLine($"orange -> {p:C}");

            Console.WriteLine("All items:");
            foreach (var kv in prices)
                Console.WriteLine($"  {kv.Key} = {kv.Value:C}");
            Console.WriteLine();
        }

        static void HashSets()
        {
            Console.WriteLine("=== HashSet<T> (sets) ===\n");
            var a = new HashSet<int> { 1, 2, 3, 4 };
            var b = new HashSet<int> { 3, 4, 5 };

            var union = new HashSet<int>(a); union.UnionWith(b);
            var inter = new HashSet<int>(a); inter.IntersectWith(b);
            var diff = new HashSet<int>(a); diff.ExceptWith(b);

            Console.WriteLine($"A:     {{ {string.Join(", ", a)} }}");
            Console.WriteLine($"B:     {{ {string.Join(", ", b)} }}");
            Console.WriteLine($"Union: {{ {string.Join(", ", union)} }}");
            Console.WriteLine($"Inter: {{ {string.Join(", ", inter)} }}");
            Console.WriteLine($"Diff:  {{ {string.Join(", ", diff)} }}\n");
        }

        static void QueuesAndStacks()
        {
            Console.WriteLine("=== Queue<T> (FIFO) / Stack<T> (LIFO) ===\n");

            var q = new Queue<string>();
            q.Enqueue("A"); q.Enqueue("B"); q.Enqueue("C");
            Console.WriteLine($"Queue peek: {q.Peek()}");
            while (q.Count > 0) Console.Write($"{q.Dequeue()} ");
            Console.WriteLine("\n");

            var s = new Stack<string>();
            s.Push("A"); s.Push("B"); s.Push("C");
            Console.WriteLine($"Stack peek: {s.Peek()}");
            while (s.Count > 0) Console.Write($"{s.Pop()} ");
            Console.WriteLine("\n");
        }

        static void LinkedLists()
        {
            Console.WriteLine("=== LinkedList<T> ===\n");
            var ll = new LinkedList<string>();
            var n1 = ll.AddFirst("start");
            var n3 = ll.AddLast("end");
            var n2 = ll.AddAfter(n1, "middle");
            ll.AddBefore(n3, "almost-end");
            ll.Remove(n2);

            foreach (var v in ll) Console.WriteLine($"  {v}");
            Console.WriteLine();
        }
    }
}
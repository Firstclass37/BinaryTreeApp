using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
           Remove();
           Console.ReadKey();
        }


        private static void Remove()
        {
            var tree = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            tree.Add(new[] { 7, 4, 9, 1, 3, -1, 8, 2, 11 });
            Console.WriteLine($"{tree:inx}");
            tree.Remove(1);
            Console.WriteLine($"{tree:inx}");
        }

        private static void ShowTree()
        {
            var tree = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            tree.Add(new[] { 7, 4, 9, 1, 3, -1, 8, 2, 11 });
            do
            {
                Console.WriteLine("Show: prefix - 1, postfix - 2, infix - 3");
                Console.Write("Choice : ");
                var answer = Console.ReadKey();
                Console.WriteLine();
                if (answer.Key == ConsoleKey.D1)
                    Console.WriteLine($"{tree:prx}");
                else if (answer.Key == ConsoleKey.D2)
                    Console.WriteLine($"{tree:psx}");
                else if (answer.Key == ConsoleKey.D3)
                    Console.WriteLine($"{tree:inx}");
                else
                    Console.WriteLine(":(");
                //needNext = UiManager.AskBool("Continue");
            } while (true);
        }
    }
}

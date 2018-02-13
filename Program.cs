using System;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var needNext = true;
            var ints = UiManager.AskIntArray("Input numbers (min 1)");
            var tree = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            tree.Add(ints);
            do
            {
                var number = UiManager.AskInt("Number for check");
                Console.WriteLine($"Contains : {tree.Contains(number)}");
                //needNext = UiManager.AskBool("Continue");
            } while (true);
        }
    }
}

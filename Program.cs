using System;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            tree1.Add(new []{ 7 ,3 ,6 ,1 ,2});
            tree1.Remove(3);


            //var needNext = true;
            var ints = ConsoleExtentions.AskIntArray("Input numbers (min 1)");
            var tree = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            tree.Add(ints);
            do
            {
                var number = ConsoleExtentions.AskInt("Number for check");
                Console.WriteLine($"Contains : {tree.Contains(number)}");
                //needNext = UiManager.AskBool("Continue");
            } while (true);
        }
    }
}

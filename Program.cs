using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tree1 = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            //tree1.Add(new []{ 7, 4 , 9 , 1 , 3 , -1, 8 , 2 , 11});
            
            //(1,2,(1, 2, ()))
            //  
            //
            //
            //
            //

            //var needNext = true;
            //var ints = ConsoleExtentions.AskIntArray("Input numbers (min 1)");
            var tree = new BinaryTree<int>(Comparer<int>.Create((x, y) => Math.Sign(x - y)));
            tree.Add(new []{ 7, 4 , 9 , 1 , 3 , -1, 8 , 2 , 11});
            do
            {
                Console.WriteLine("Show: prefix - 1, postfix - 2, infix - 3");
                Console.Write("Choice : ");
                var answer = Console.ReadKey();
                if (answer.Key == ConsoleKey.D1)
                    Console.WriteLine(tree.Show(ShowType.Prefix));
                else if (answer.Key == ConsoleKey.D2)
                    Console.WriteLine(tree.Show(ShowType.Postfix));
                else if (answer.Key == ConsoleKey.D3)
                    Console.WriteLine(tree.Show(ShowType.Infix));
                else
                    Console.WriteLine(":(");
                
                //needNext = UiManager.AskBool("Continue");
            } while (true);
        }
    }
}

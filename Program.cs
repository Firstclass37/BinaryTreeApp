using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var needNext = true;
            var ints = UiManager.AskIntArray("Input numbers (min 1)");
            var tree = new BinaryTree();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create and populate tree
            AVL_Tree myTree = new AVL_Tree();
            myTree.InsertRandomNums(10);

            // Print results
            Console.WriteLine(myTree.PrintInOrder(myTree.root));
            Console.ReadLine();

            // Create and populate tree
            myTree.InsertRandomNums(100);

            // Print results
            Console.WriteLine(myTree.PrintPreOrder(myTree.root));
            Console.ReadLine();

        }
    }
}

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

            // Create Tree
            AVL_Tree myTree = new AVL_Tree();

            // Print Header
            Console.WriteLine("AVL Tree");

            int selection = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("[1] Insert multiple Random Numbers");
                Console.WriteLine("[2] Insert an Item");
                Console.WriteLine("[3] Delete an Item");
                Console.WriteLine("[4] Print Tree Pre-Order");
                Console.WriteLine("[5] Print Tree In-Order");
                Console.WriteLine("[6] Reset Tree");
                Console.WriteLine("[7] Quit Application");
                Console.Write("Enter Selection: ");
                selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.Write("Enter the amount of random numbers to populate the tree with: ");
                        myTree.InsertRandomNums(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 2:
                        Console.Write("Enter the value that you want to insert: ");
                        myTree.Insert(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Write("Enter the value of the item you want to delete: ");
                        myTree.Delete(ref myTree.root, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 4:
                        Console.WriteLine("\n" + myTree.PrintPreOrder(myTree.root));
                        break;
                    case 5:
                        Console.WriteLine("\n" + myTree.PrintInOrder(myTree.root));
                        break;
                    case 6:
                        myTree = new AVL_Tree();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a value from 1 - 6...");
                        break;
                }

            } while (selection != 7) ;



            /*

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

            */

        }
    }
}

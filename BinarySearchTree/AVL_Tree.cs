using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class AVL_Tree : Tree
    {
        // Inserts the amount of numbers specified in the arguments
        public void InsertRandomNums(int amount)
        {
            Random randNum = new Random();
            for (int i = 0; i < amount; i++)
            {
                Insert(randNum.Next(0, 100));
            }
        }

        // Rotate Left - Used in RR, RL, and LR cases
        private void RotateLeft(ref Node N)
        {
            // Rotate with right child
            Node newN = N.right;
            N.right = N.right.left;
            newN.left = N;

            // Set heights
            setHeight(ref N);
            setHeight(ref newN);

            // Set N to New N
            N = newN;
        }

        // Rotate Right - Used in LL, LR, and RL cases
        private void RotateRight(ref Node N)
        {
            // Rotate with right child
            Node newN = N.left;
            N.left = N.left.right;
            newN.right = N;

            // Set heights
            setHeight(ref N);
            setHeight(ref newN);

            // Set N to New N 
            N = newN;
        }

        // Sets the height equal to 1 + max height of child nodes
        private void setHeight(ref Node N)
        {
            if (N == null)
                N.height = 0;
            N.height = 1 + Math.Max(height(N.left), height(N.right));
        }

        // Gets the height of the provided Node
        private int height(Node N)
        {
            return (N == null) ? 0 : N.height;
        }

        // Standard Insert - Uses InsertRecursive
        public override void Insert(int theValue)
        {
            InsertRecursive(ref root, theValue);
        }

        // The insertRecursive Method (N = current Node)
        public void InsertRecursive(ref Node N, int theValue)
        {
            // if you have reached an empty node reference, add new node
            if (N == null)
                N = new Node(theValue);

            // if new balue less than current node, go to left node
            else if (N.value > theValue)
                InsertRecursive(ref N.left, theValue);

            // if new value greater/equal than current node, go to right node
            else
                InsertRecursive(ref N.right, theValue);

            // Balance the Tree
            int balance = height(N.left) - height(N.right);
            if (balance > 1)
            {
                // LL
                if (height(N.left.left) >= height(N.left.right))
                    RotateRight(ref N);
                // LR
                else
                {
                    RotateLeft(ref N.left);
                    RotateRight(ref N);
                }
            }
            else if (balance < -1)
            {
                // RR
                if (height(N.right.right) >= height(N.right.left))
                    RotateLeft(ref N);
                // RL
                else
                {
                    RotateRight(ref N.right);
                    RotateLeft(ref N);
                }
            }
            else
                // Set the new height
                setHeight(ref N);


        }

        // Print In Order (N = current Node)
        public string PrintInOrder(Node N)
        {
            if (N == null)
                return "";
            return
                PrintInOrder(N.left) +
                N.value + ":" + N.height + " " +
                PrintInOrder(N.right);
        }

        // Print In Order (N = current Node)
        public string PrintPreOrder(Node N)
        {
            if (N == null)
                return "";
            return
                N.value + ":" + N.height + " " +
                PrintInOrder(N.left) +
                PrintInOrder(N.right);
        }

    }
}

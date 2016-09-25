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
                Insert(randNum.Next(0, 100));
        }

        // Rotate Left - Used in RR, RL, and LR cases
        private void RotateLeft(ref Node N)
        {
            // Rotate with right child
            Node newN = N.right;
            N.right = N.right.left;
            newN.left = N;

            // Set heights
            SetHeight(ref N);           // set height of new left
            SetHeight(ref newN);        // set height of new root

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
            SetHeight(ref N);
            SetHeight(ref newN);

            // Set N to New N 
            N = newN;
        }

        // Sets the height equal to 1 + max height of child nodes
        private void SetHeight(ref Node N)
        {
            if (N != null)
                N.height = 1 + Math.Max(Height(N.left), Height(N.right));
        }

        // Gets the height of the provided Node
        private int Height(Node N)
        {
            return (N == null) ? 0 : N.height;
        }

        // Balance The tree from the provided Node 
        private void Balance(ref Node N)
        {
            if (N != null)
            { 
                int balance = Height(N.left) - Height(N.right);
                if (balance > 1)
                {
                    // LL
                    if (Height(N.left.left) >= Height(N.left.right))
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
                    if (Height(N.right.right) >= Height(N.right.left))
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
                    SetHeight(ref N);
            }
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

            // if new value less than current node, go to left node
            else if (N.value > theValue)
                InsertRecursive(ref N.left, theValue);

            // if new value greater/equal than current node, go to right node
            else
                InsertRecursive(ref N.right, theValue);

            // Balance the tree
            Balance(ref N);
            
        }

        // Delete the Node containing the specified data
        public Node Delete(ref Node N, int theValue)
        {
            // if Current Node is null
            if (N == null) return N;

            // else iterate down (left or right)
            else if (theValue < N.value) N.left = Delete(ref N.left, theValue);
            else if (theValue > N.value) N.right = Delete(ref N.right, theValue);

            // else Node has been found
            else
            {
                // Case 1: No Children
                if (N.left == null && N.right == null)
                    N = null;

                // Case 2: One Child
                else if (N.left == null)
                    N = N.right;
                else if (N.right == null)
                    N = N.left;

                // Case 3: Two Children
                else
                {
                    Node temp = FindMin(N.right);
                    N.value = temp.value;
                    N.right = Delete(ref N.right, temp.value);
                }
            }
            Balance(ref N); // Set the new height
            return N;
        }

        // Find the Node with the lowest value
        public Node FindMin(Node N)
        {
            return (N.left == null) ? N : FindMin(N.left);
        }

        // Returns a string with the printed Tree [INORDER] (N = current Node)
        public string PrintInOrder(Node N)
        {
            if (N == null)
                return "";
            return
                PrintInOrder(N.left) +
                N.value + ":" + N.height + " " +
                PrintInOrder(N.right);
        }

        // Returns a string with the printed Tree [PREORDER] (N = current Node)
        public string PrintPreOrder(Node N)
        {
            if (N == null)
                return "";
            return
                N.value + ":" + N.height + " " +
                PrintPreOrder(N.left) +
                PrintPreOrder(N.right);
        }

    }
}

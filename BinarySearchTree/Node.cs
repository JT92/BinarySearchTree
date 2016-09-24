using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node
    {
        // Fields
        public int value;
        public int height;
        public Node left;
        public Node right;

        // Constructors
        public Node(int theValue)
        {
            value = theValue;
            height = 0;
            left = null;
            right = null;
        }

    }

}

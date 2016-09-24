using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    abstract class Tree
    {
        // fields
        public Node root;

        // constructors
        public Tree()
        {
            root = null;
        }
        public Tree(int theValue)
        {
            root = new Node(theValue);
        }

        // methods
        public abstract void Insert(int theValue);
    }

}

# BinarySearchTree
C# Minimal AVL Tree Implementation

This is just a basic implementation of an AVL Binary Search Tree. 
NOTE: This is not production code, just an excercise in implementing an algorithm.

### Right Right Case ###
The RR case will require a single __left-rotation__ on the (3) Node to balance:

     3                  5
      \                / \
       5    -->       3   7
        \              
         7              

### Right Left Case ###
The RL case requires a __right-rotation__ on the (5) Node and a __right-rotation__ on the (3) Node:

     3                  3                  4
      \                  \                / \
       5    -->           4    -->       3   5            
      /                    \
     4                      5
     
### Left Left Case ###
The LL case will require a single __right-rotation__ on the (5) Node to balance:

         5              3
        /              / \
       3    -->       2   5
      /              
     2              

### Left Right Case ###
The LR case requires a __left-rotation__ on the (3) Node and a __right-rotation__ on the (5) Node:

       5                    5                4
      /                    /                / \
     3      -->           4    -->         3   5            
      \                  / 
       4                3 


### Complexity Analysis ###
 In terms of the depth of an AVL tree on both sides, it differs at most by 1 level. At any other time where difference in height/depth is greater than 1 or less than -1, rebalancing occurs. In terms of space it has a O(n) complexity. With time complexity it has O(log n).

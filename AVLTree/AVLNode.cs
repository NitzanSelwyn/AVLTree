using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class AVLNode
    {
        public int Value { get; set; }
        public AVLNode LeftChild { get; set; }
        public AVLNode RightChild { get; set; }
        public int Hight { get; set; }
            
        public AVLNode(int value)
        {
            Value = value;
        }
    }
}

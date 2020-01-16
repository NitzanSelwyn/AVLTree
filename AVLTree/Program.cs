using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(20);
        }
    }
}

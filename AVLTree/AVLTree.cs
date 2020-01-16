using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class AVLTree
    {
        private AVLNode root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private AVLNode Insert(AVLNode root, int value)
        {
            if (root == null)
                return new AVLNode(value);

            if (value < root.Value)
                root.LeftChild = Insert(root.LeftChild, value);
            else
                root.RightChild = Insert(root.RightChild, value);

            root.Hight = SetHight(root);

            return Balance(root);
        }

        private AVLNode RotateRight(AVLNode root)
        {
            var newRoot = root.LeftChild;

            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            root.Hight = SetHight(root);
            newRoot.Hight = SetHight(newRoot);

            return newRoot;
        }

        private AVLNode RotateLeft(AVLNode root)
        {
            var newRoot = root.RightChild;

            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            root.Hight = SetHight(root);
            newRoot.Hight = SetHight(newRoot);

            return newRoot;
        }

        private int SetHight(AVLNode node)
        {
            return Math.Max(
                    GetHight(node.LeftChild),
                    GetHight(node.RightChild)) + 1;
        }

        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (GetBalanceFactor(root.LeftChild) < 0)
                {
                    root.LeftChild = RotateLeft(root.LeftChild);
                    Console.WriteLine($"Left Rotate - {root.LeftChild.Value}");
                }
                Console.WriteLine($"Right Rotate - {root.Value}");
                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (GetBalanceFactor(root.RightChild) > 0)
                {
                    root.RightChild = RotateRight(root.RightChild);
                    Console.WriteLine($"Right Rotate - {root.RightChild.Value}");
                }
                Console.WriteLine($"Left Rotate - {root.Value}");
                return RotateLeft(root);
            }

            return root;
        }

        private bool IsLeftHeavy(AVLNode root)
        {
            return (GetBalanceFactor(root) > 1);
        }
        private bool IsRightHeavy(AVLNode root)
        {
            return (GetBalanceFactor(root) < -1);
        }

        private int GetHight(AVLNode node)
        {
            return (node == null) ? -1 : node.Hight;
        }

        private int GetBalanceFactor(AVLNode root)
        {
            return GetHight(root.LeftChild) - GetHight(root.RightChild);
        }
    }
}

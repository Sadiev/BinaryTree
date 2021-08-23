using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;

namespace BinaryTree
{
    public class Tree
    {
        private class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int? Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public override string ToString() {
                return "Node=" + Value;
            }
        }
        private Node Root { get; set; }       
        public void Insert(int val) {
            var node = new Node(val);
            if (Root == null) {
                Root = node;
                return;
            }
            var current = Root;

            while (true)
            {
                if (val < current.Value)
                {
                    if (current.LeftChild == null) {
                        current.LeftChild = node;
                        break;
                    }
                    current = current.LeftChild;
                }
                else {
                    if (current.RightChild == null) {
                        current.RightChild = node;
                        break;
                    }
                    current = current.RightChild;
                }
            }
        }
        public bool Find(int val) {
            var current = Root;
            while (current!=null)
            {
                if (val == current.Value)
                    return true;
                if (val < current.Value)
                {
                    current = current.LeftChild;
                }
                else {
                    current = current.RightChild;
                }
            }
            return false;
        }
        public void TraversePreOrder() {
            Console.WriteLine("Print pre order traversing");
            TraversePreOrder(Root);
        }
        private void TraversePreOrder(Node root) {
            //Base condition
            if (root == null)
                return;
            //Root
            Console.WriteLine(root.Value);
            //Left
            TraversePreOrder(root.LeftChild);
            //Right
            TraversePreOrder(root.RightChild);
        }
        public void TraverseInOrder() {
            Console.WriteLine("Print in order traversing");
            TraverseInOrder(Root);
        }
        private void TraverseInOrder(Node root) {
            if (root == null) {
                return;
            }
            //Left
            TraverseInOrder(root.LeftChild);
            //Root
            Console.WriteLine(root.Value);
            //Right
            TraverseInOrder(root.RightChild);
        }
        public void TraversePostOrder() {
            Console.WriteLine("Print post order traversing");
            TraversePostOrder(Root);
        }
        private void TraversePostOrder(Node root)
        {
            if (root == null) {
                return;
            }
            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }
        public int Height() {
            return Height(Root);
        }
        private int Height(Node root) {
            if (root==null)
            {
                return -1;
            }
            if (isLeaf(root))
            {
                return 0;
            }
            var result = 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
            return result;
        }
        private bool isLeaf(Node root) {
            return root.LeftChild == null && root.RightChild == null;
        }
        public int Min() {
            if (Root == null)
                throw new InvalidOperationException();
            return Min(Root);
            //Search binary tree O(log n)
            //var current = Root;
            //var last = current;
            //while (current!=null)
            //{
            //    last = current;
            //    current = current.LeftChild;
            //}
            //return last.Value.Value;            
        }
        //O(n)
        private int Min(Node root) {
            if (isLeaf(root))
            {
                return root.Value.Value;
            }
            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);
            return Math.Min(Math.Min(left, right), root.Value.Value);
        }

        public bool isEquals(Tree other) {
            if (other==null)
            {
                return false;
            }
            return isEquals(Root, other.Root);
        }

        private bool isEquals(Node first, Node second) {
            if (first==null && second==null)
            {
                return true;
            }
            if (first!=null && second!=null)
            {
                return first.Value == first.Value
                    && isEquals(first.LeftChild, second.LeftChild)
                    && isEquals(first.RightChild, second.RightChild);
            }
            return false;
        }
        public bool isBinarySearchTree()
        {            
            return isBinarySearchTree(Root, int.MinValue, int.MaxValue);
        }
        private bool isBinarySearchTree(Node root, int min, int max) {
            if (root == null)
                return true;
            if (root.Value < min || root.Value > max)
                return false;
            return isBinarySearchTree(root.LeftChild, min, root.Value.Value-1)
                && isBinarySearchTree(root.RightChild, root.Value.Value+1, max);
        }

        public void swapRoot() {
            var temp = Root.LeftChild;
            Root.LeftChild = Root.RightChild;
            Root.RightChild = temp;
        }
    }
}

﻿using System;
using System.Collections.Generic;
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
            if (root.LeftChild==null && root.RightChild==null)
            {
                return 0;
            }
            var result = 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
            return result;
        }
    }
}

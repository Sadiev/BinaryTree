using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);
            var tree2 = new Tree();
            tree2.Insert(7);
            tree2.Insert(4);
            tree2.Insert(9);
            tree2.Insert(1);
            tree2.Insert(6);
            tree2.Insert(8);
            //tree2.Insert(10);
            //tree.TraversePreOrder();
            //tree.TraverseInOrder();
            //Console.WriteLine("Result:"+tree.Find(55));
            Console.WriteLine("Level Order Traversal");
            tree.traverseLevelOrder();
            Console.WriteLine("Get Nodes At Distance Two");
            var nodes = tree.getNodesAtDistance(2);
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("Tree Height is: "+tree.Height());
            Console.WriteLine("Tree min value is: " + tree.Min());
            Console.WriteLine("tree and tree2 are equals: " + tree.isEquals(tree2));
            tree.swapRoot();
            Console.WriteLine("Chcek Validating Binary Search Trees: " + tree.isBinarySearchTree());
        }
    }
}

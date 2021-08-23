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
            //tree.TraversePreOrder();
            //tree.TraverseInOrder();
            //Console.WriteLine("Result:"+tree.Find(55));

            Console.WriteLine("Tree Height is: "+tree.Height());
        }
    }
}

using System;

namespace Lab10
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

    }
    class BinaryTree<T>
    {
        public Node<T> Root { get; init; }
        public void PreorderTraversal(Action<T> action)
        {

        }
        private void Preorder(Node<T> node, Action<Node<T>> action)
        {
            if(node == null)
            {
                return;
            }
            action.Invoke(node);
            Preorder(node.Left, action);
            Preorder(node.Right, action);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "aaa" };
            node.Left = new Node<string>() { Value = "BBB" };
            node.Right = new Node<string>() { Value = "CCC"};
            
        }
    }
}

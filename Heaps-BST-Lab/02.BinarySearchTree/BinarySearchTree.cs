namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree()
        {
        }

        public bool Contains(T element)
        {
            return this.FindNode(element, this.root) != null;
        }

        private Node FindNode(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node = this.FindNode(element, node.Right);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node = this.FindNode(element, node.Left);
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.Right);
        }

        public void Insert(T value)
        {
            this.root = this.Insert(value, this.root);
        }

        private Node Insert(T value, Node node)
        {
            if (node == null)
            {
                node = new Node(value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(value, node.Right);
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(value, node.Left);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
    }
}

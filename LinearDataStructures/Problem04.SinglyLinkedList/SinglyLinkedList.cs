namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
                : this(element, null)
            {
                this.Element = element;
            }

            public T Element { get; set; }

            public Node Next { get; set; }
        }

        private Node head;

        public int Count {  get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
            }
            else
            {
                var node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new Node(item);
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.CheckIfEmpty();
            return this.head.Element;
        }

        public T GetLast()
        {
            this.CheckIfEmpty();

            var node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            this.CheckIfEmpty();

            T element = this.head.Element;
            var newHead = this.head.Next;
            this.head = newHead;
            this.Count--;

            return element;
        }

        public T RemoveLast()
        {
            this.CheckIfEmpty();

            T element;

            if (this.Count == 1)
            {
                element = this.head.Element;
                this.head = null;
            }
            else
            {
                var node = this.head;

                for (int i = 1; i <= this.Count - 2; i++)
                {
                    node = node.Next;
                }

                element = node.Next.Element;
                node.Next = null;
            }

            this.Count--;
            return element;
        }

        private void CheckIfEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
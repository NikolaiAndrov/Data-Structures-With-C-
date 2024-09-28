namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
            }

            public T Element { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node node = new Node(item);

            if(this.tail == null)
            {
                this.tail = node;
                this.head = node;
            }
            else
            {
                this.tail.Next = node;
                node.Previous = this.tail;
                this.tail = node;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.CheckAndThrowIfEmpty();
            return this.head.Element;
        }

        public T GetLast()
        {
            this.CheckAndThrowIfEmpty();
            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            this.CheckAndThrowIfEmpty();
            T element = this.head.Element;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                Node newHead = this.head.Next;
                this.head = newHead;
                this.head.Previous = null;
            }

            this.Count--;
            return element;
        }

        public T RemoveLast()
        {
            this.CheckAndThrowIfEmpty();
            T element = this.tail.Element;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                Node newTail = this.tail.Previous;
                this.tail = newTail;
                this.tail.Next = null;
            }

            this.Count--;
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckAndThrowIfEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
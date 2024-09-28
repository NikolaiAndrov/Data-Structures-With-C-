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
            throw new NotImplementedException();
        }

        public T RemoveLast()
        {
            throw new NotImplementedException();
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
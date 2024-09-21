namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        public int Count { get; private set; }

        public void Enqueue(T item)
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

        public T Dequeue()
        {
            this.CheckIfQueueIsEmpty();

            var node = this.head;
            this.head = node.Next;
            this.Count--;
            return node.Element;
        }

        public T Peek()
        {
            this.CheckIfQueueIsEmpty();
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            bool found = false;
            var node = this.head;

            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    found = true;
                    break;
                }

                node = node.Next;
            }

            return found;
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

        private void CheckIfQueueIsEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
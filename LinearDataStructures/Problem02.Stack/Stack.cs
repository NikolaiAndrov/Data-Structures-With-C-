namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

            public T Element {  get; set; }

            public Node Next { get; set; }
        }        

        private Node top;

        public int Count {  get; private set; }

        public void Push(T item)
        {
            var newNode = new Node(item, this.top);
            this.top = newNode;
            this.Count++;
        }

        public T Pop()
        {
            this.CheckIfStackIsEmpty();

            T element = this.top.Element;
            var newTop = this.top.Next;
            this.top = newTop;  
            this.Count--;
            return element;
        }

        public T Peek()
        {
            this.CheckIfStackIsEmpty();
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            bool found = false;

            var node = this.top;
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
            var node = this.top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckIfStackIsEmpty()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
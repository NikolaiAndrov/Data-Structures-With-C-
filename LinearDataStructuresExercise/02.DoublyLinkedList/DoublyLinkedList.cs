﻿namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node()
            {
            }

            protected T Element { get; set; }

            protected Node Next { get; set; }

            protected Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            throw new NotImplementedException();
        }

        public T GetLast()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
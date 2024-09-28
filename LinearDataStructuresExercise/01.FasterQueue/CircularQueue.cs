namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int startIndex;
        private int endIndex;

        public CircularQueue()
            : this(DefaultCapacity)
        {
        }

        public CircularQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.items.Length)
            {
                this.Grow();
            }

            this.items[endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.items.Length;
            this.Count++;
        }

        public T Peek()
        {
            this.CheckIfEmpty();
            return this.items[this.startIndex];
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                int index = (this.startIndex + i) % this.items.Length;
                yield return this.items[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            T[] newArray = new T[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                int index = (this.startIndex + i) % this.items.Length;
                newArray[i] = this.items[index];
            }

            this.items = newArray;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

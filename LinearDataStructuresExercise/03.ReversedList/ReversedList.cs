namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            bool found = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    index = this.Count - 1 - i; 
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            index = this.Count - 1 - index;

            for (int i = this.Count - 1; i > index; i--)
            {
                this.items[i + 1] = this.items[i];
            }

            this.items[index + 1] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            index = this.Count - 1 - index;

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
            this.Shrink();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            if (this.items.Length == this.Count)
            {
                T[] newArray = new T[this.Count * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    newArray[i] = this.items[i];
                }

                this.items = newArray;
            }
        }

        private void Shrink()
        {
            if (this.Count < this.items.Length / 2)
            {
                T[] newArray = new T[this.Count + 1];

                for (int i = 0; i < this.Count; i++)
                {
                    newArray[i] = this.items[i];
                }

                this.items = newArray;
            }
        }
    }
}
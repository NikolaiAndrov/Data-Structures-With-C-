namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T element = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = element;
        }

        private int GetParentIndex(int index)
            => (index - 1) / 2;

        public T ExtractMax()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }
    }
}

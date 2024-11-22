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

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            int biggerChildIndex = this.GetBiggerChildIndex(index);

            if (biggerChildIndex == -1 || this.elements[0].CompareTo(this.elements[biggerChildIndex]) > 0)
            {
                return;
            }

            while (biggerChildIndex > 0 && this.elements[index].CompareTo(this.elements[biggerChildIndex]) < 0)
            {
                this.Swap(index, biggerChildIndex);
                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        private int GetParentIndex(int index)
            => (index - 1) / 2;

        private int GetLeftChildIndex(int index)
            => (index * 2) + 1;

        private int GetRightChildIndex(int index)
            => (index * 2) + 2;

        private int GetBiggerChildIndex(int index)
        {
            int leftChildIndex = this.GetLeftChildIndex(index);
            int rightChildIndex = this.GetRightChildIndex(index);

            if (leftChildIndex > this.elements.Count - 1)
            {
                return -1;
            }

            if (rightChildIndex > this.elements.Count - 1)
            {
                return leftChildIndex;
            }

            if (this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) > 0)
            {
                return leftChildIndex;
            }

            return rightChildIndex;
        }
    }
}

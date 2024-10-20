namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private List<Tree<T>> children;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children) 
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> OrderBfs()
        {
            var queueTree = new Queue<Tree<T>>();
            queueTree.Enqueue(this);

            var result = new List<T>();

            while (queueTree.Count > 0)
            {
                var currentTree = queueTree.Dequeue();
                result.Add(currentTree.value);

                foreach (var child in currentTree.children)
                {
                    queueTree.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var stackTree = new Stack<Tree<T>>();
            stackTree.Push(this);

            var result = new Stack<T>();

            while (stackTree.Count > 0)
            {
                var currentTree = stackTree.Pop();
                result.Push(currentTree.value);

                foreach (var child in currentTree.children)
                {
                    stackTree.Push(child);
                }
            }

            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}

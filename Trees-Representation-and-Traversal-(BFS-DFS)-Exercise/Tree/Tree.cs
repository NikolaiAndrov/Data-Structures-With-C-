namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {  
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();
            DfsAsString(sb, this, 0);
            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            var keys = new List<T>();
            var stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var currentTree = stack.Pop();

                if (currentTree.Parent != null)
                {
                    keys.Add(currentTree.Key);
                }

                foreach(var child in currentTree.children)
                {
                    if (child.children.Count > 0)
                    {
                        stack.Push(child);
                    }
                }
            }

            return keys;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var leafKeys = new List<T>();
            this.DfsLeafKeys(this, leafKeys);
            return leafKeys;
        }

        private void DfsLeafKeys(Tree<T> tree, ICollection<T> result)
        {
            if (tree.children.Count == 0)
            {
                result.Add(tree.Key);
            }

            foreach (var child in tree.children)
            {
                this.DfsLeafKeys(child, result);
            }
        }

        public T GetDeepestKey()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}

namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var leafNodes = new List<Tree<int>>();
            this.DfsLeafNodes(this, leafNodes);
            var result = new List<IEnumerable<int>>();

            foreach (var node in leafNodes)
            {
                var currentPath = this.GetPathWithGivenSum(node, sum);

                if (currentPath != null)
                {
                    result.Add(currentPath);
                }
            }

            return result;
        }

        private IEnumerable<int> GetPathWithGivenSum(Tree<int> node, int sum)
        {
            var path = new Stack<int>();

            while (node != null)
            {
                path.Push(node.Key);
                node = node.Parent;
            }

            if (sum == path.Sum())
            {
                return path;
            }

            return null;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}

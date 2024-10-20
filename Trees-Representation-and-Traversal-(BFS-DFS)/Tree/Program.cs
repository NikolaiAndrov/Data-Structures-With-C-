namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree<int>(10, new Tree<int>(100), new Tree<int>(1000));
            IEnumerable<int> dfs = tree.OrderDfs();
            Console.WriteLine(string.Join(", ", dfs));
        }
    }
}

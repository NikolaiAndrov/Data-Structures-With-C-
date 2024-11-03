namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73" };
            string[] input = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" };
            var treeFactory = new IntegerTreeFactory();
            var tree = treeFactory.CreateTreeFromStrings(input);
            Console.WriteLine(string.Join(" ", tree.GetPathsWithGivenSum(27)));
        }
    }
}

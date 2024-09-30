namespace ReverseNumbersWithAStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()!
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .AsEnumerable();

            var reversedNumbers = new Stack<int>();

            foreach (int number in inputNumbers)
            {
                reversedNumbers.Push(number);
            }

            Console.WriteLine(string.Join(" ", reversedNumbers));
        }
    }
}

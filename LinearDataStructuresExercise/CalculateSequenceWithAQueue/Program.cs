namespace CalculateSequenceWithAQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            Queue<int> nums = new Queue<int>();
            nums.Enqueue(n);

            for (int i = 1; i <= 50; i++)
            {
                nums.Enqueue(nums.Peek() + 1);
                nums.Enqueue(2 * nums.Peek() + 1);
                nums.Enqueue(nums.Peek() + 2);

                Console.Write($"{nums.Dequeue()} ");
            }
        }
    }
}

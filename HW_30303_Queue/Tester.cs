namespace HW_30303_Queue
{
    internal class Tester
    {
        public static void TestMyQueue()
        {
            MyQueue<int> queue = new MyQueue<int>();

            for (int i = 0; i < 8; i++)
            {
                Console.Write(i);
                queue.Enqueue(i);
            }
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.Write(queue.Dequeue());
            }
            Console.WriteLine();

            for (int i = 0; i < 15; i++)
            {
                Console.Write(i);
                queue.Enqueue(i);
            }
            Console.WriteLine();

            for (int i = 0; i < 16; i++)
            {
                Console.Write(queue.Dequeue());
            }
            Console.WriteLine();
        }
    }
}

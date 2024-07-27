using System.Drawing;

namespace HW_30302_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
            int interval;
            int.TryParse(Console.ReadLine(), out size);
            int.TryParse(Console.ReadLine(), out interval);

            var result = MyCalculator.JosephusPermutation(size, interval);
            foreach(int value in result)
            {
                Console.Write($"{value}, ");
            }
        }

        public static class MyCalculator
        {
            /// <summary>
            /// 요세푸스 순열을 계산합니다.
            /// </summary>
            /// <param name="size">순열의 길이입니다(사람 수).</param>
            /// <param name="interval">뽑아내는 순번입니다.</param>
            /// <returns>순열을 반환합니다. 입력에 0 이하 숫자가 포함될 경우 null을 반환합니다.</returns>
            public static List<int>? JosephusPermutation(int size, int interval)
            {
                // 입력 예외
                if (size <= 0 || interval <= 0)
                    return null;

                // 초기 데이터 준비
                List<int> result = new List<int>(size);
                LinkedList<int> cycle = new LinkedList<int>();
                
                for (int i = 0; i < size; i++)
                {
                    cycle.AddLast(i + 1);
                }

                // 순열 계산
                LinkedListNode<int> buffer = cycle.Last;
                while (cycle.Count > 0)
                {
                    for (int i = 0; i < interval; i++)
                    {
                        buffer = buffer.Next;
                        if (buffer == null)
                            buffer = cycle.First;
                    }

                    result.Add(buffer.Value);
                    LinkedListNode<int> nextNode = buffer;
                    cycle.Remove(buffer);
                    buffer = nextNode;
                }

                return result;
            }
        }
    }
}

namespace HW_30302_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
            int interval;

            Console.WriteLine("요세푸스 순열의 길이를 입력 해 주세요.");
            size = ConsoleGetInt(true);

            Console.WriteLine("요세푸스 순열의 간격을 입력 해 주세요.");
            interval = ConsoleGetInt(true);

            var result = MyCalculator.JosephusPermutation(size, interval);
            foreach (int value in result)
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
                List<int> result = new(size); // 미리 입력된 순열의 길이로 예약해서 재할당을 예방한다.
                LinkedList<int> cycle = new();

                for (int i = 0; i < size; i++)
                {
                    cycle.AddLast(i + 1);
                }

                // 순열 계산
                LinkedListNode<int> buffer = cycle.First;
                while (cycle.Count > 0)
                {
                    for (int i = 0; i < interval - 1; i++)
                    {
                        buffer = buffer.Next;
                        // 다음 노드가 없다면(꼬리였다면) 머리로 연결
                        if (buffer == null)
                            buffer = cycle.First;
                    }

                    // 원에서 제거할 번호를 순열에 저장
                    result.Add(buffer.Value);

                    // buffer를 다음 노드로 이동 후 이전 노드 제거
                    buffer = buffer.Next;
                    if (buffer == null) 
                    {
                        // 다음 노드가 없다면 머리로 이동 후 꼬리 제거
                        // 환형 연결 리스트처럼 동작시키기
                        cycle.RemoveLast();
                        buffer = cycle.First;
                    }
                    else
                    {
                        cycle.Remove(buffer.Previous);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 콘솔 입력으로 정수를 입력받아 반환합니다.
        /// 정수 이외의 문자열 입력시 사용자가 정수를 입력할 때 까지 반복해서 정수 입력을 요청합니다.
        /// </summary>
        /// <param name="isPositiveOnly">참일 경우 양의 정수만을 입력받습니다.</param>
        /// <returns>사용자가 입력한 정수값</returns>
        public static int ConsoleGetInt(bool isPositiveOnly = false)
        {
            int getInt = 0;
            bool isInteger = false;
            while (true)
            {
                isInteger = int.TryParse(Console.ReadLine(), out getInt);
                if (isInteger == false)
                {
                    Console.WriteLine("숫자를 입력 해 주세요.");
                }
                else if (isPositiveOnly && (getInt <= 0))
                {
                    Console.WriteLine("양의 정수를 입력 해 주세요.");

                }
                else
                {
                    return getInt;
                }
            }
        }
    }
}

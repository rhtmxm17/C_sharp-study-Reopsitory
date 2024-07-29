namespace HW_30303_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> schadule = new List<int>() { 4, 4, 12, 10, 2, 10 };
            int workTime = 8;

            List<int> dates = ScheduleDayChecker(schadule, workTime);

            Console.WriteLine($"입력: [{ string.Join(", ", schadule) }]");
            Console.WriteLine($"출력: [{ string.Join(", ", dates) }]");
        }

        /// <summary>
        /// 여러 작업의 작업 소요 시간과 일일 작업 수행 시간을 입력받아 각 작업의 완료 날짜를 계산합니다.
        /// </summary>
        /// <param name="requireTimeData">작업 소요 시간 목록입니다. 앞에서부터 작업을 수행하는것으로 보고 계산합니다.</param>
        /// <param name="dailyWorkTime">일일 작업 수행 시간입니다.</param>
        /// <returns>각 작업의 완료 날짜입니다. 순서는 requireTimeData로 입력받은 순서와 동일합니다.</returns>
        public static List<int> ScheduleDayChecker(List<int> requireTimeData, int dailyWorkTime)
        {
            if (dailyWorkTime <= 0)
                return new List<int>();

            List<int> completeDays = new(requireTimeData.Count);
            Queue<int> workQueue = new Queue<int>(requireTimeData);

            int day = 1;
            int remainTime = dailyWorkTime;

            // 남은 작업이 있는 동안 반복
            while (workQueue.Count > 0)
            {
                remainTime -= workQueue.Dequeue();

                // 작업시간이 남은 시간보다 크다면 날짜 진행 및 시간 보충
                while (remainTime < 0) 
                {
                    day++;
                    remainTime += dailyWorkTime;
                }

                completeDays.Add(day);
            }

            return completeDays;
        }
    }
}

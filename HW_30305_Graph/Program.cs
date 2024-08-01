namespace HW_30305_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionGraph graph = new ListConnectionGraph(8);

            // 0 에서
            graph.Connect(0, 1);

            // 1 에서
            graph.Connect(1, 0);
            graph.Connect(1, 5);
            graph.Connect(1, 6);

            // 2 에서

            // 3 에서
            graph.Connect(3, 7);

            // 4 에서

            // 5 에서
            graph.Connect(5, 3);
            graph.Connect(5, 6);

            // 6 에서
            graph.Connect(6, 2);
            graph.Connect(6, 4);
            graph.Connect(6, 5);
            graph.Connect(6, 7);

            // 7 에서

            // 그래프 읽기 및 출력
            for (int i = 0; i < graph.Vertex; i++)
            {
                var connections = graph.GetConnectionFrom(i);

                Console.WriteLine($"{i}번 정점:");

                if (connections.Count == 0)
                {
                    Console.WriteLine("    (연결 없음)");
                }

                foreach (var connection in connections)
                {
                    Console.WriteLine($"    {connection}번 정점");
                }
            }
        }
    }
}

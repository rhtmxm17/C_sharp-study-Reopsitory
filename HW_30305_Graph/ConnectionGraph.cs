namespace HW_30305_Graph
{
    public abstract class ConnectionGraph
    {
        public abstract int Vertex { get; }
        public abstract int Edge { get; }

        public abstract void Connect(int from, int to);
        public abstract void Disconnect(int from, int to);
        public abstract bool GetConnection(int from, int to);
        public abstract List<int> GetConnectionFrom(int from);
    }

    public class ListConnectionGraph : ConnectionGraph
    {
        // 행렬 대신 리스트 그래프를 사용한다는 점에서
        // 간선의 조회와 삽입 삭제가 드물거나 평균적인 간선의 수가
        // 적다고 가정하고 간선 정보를 담는데에 List를 사용
        List<List<int>> graph;
        int edge = 0;

        public ListConnectionGraph(int vertex)
        {
            graph = new(vertex);
            for (int i = 0; i < vertex; i++)
            {
                graph.Add(new List<int>());
            }
        }

        public override int Vertex { get => graph.Count; }
        public override int Edge { get => edge; }

        public override void Connect(int from, int to)
        {
            if (false == graph[from].Contains(to))
            {
                graph[from].Add(to);
                edge++;
            }
        }

        public override void Disconnect(int from, int to)
        {
            if (graph[from].Remove(to))
                edge--;
        }

        public override bool GetConnection(int from, int to)
        {
            return graph[from].Contains(to);
        }

        public override List<int> GetConnectionFrom(int from)
        {
            return new List<int>(graph[from]);
        }
    }
}

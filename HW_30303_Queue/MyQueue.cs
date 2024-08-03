using HW_30302_List;

namespace HW_30303_Queue
{
    public class MyQueue<T>
    {
        private MyList<T> list = new MyList<T>();
        private int head = 0; // 저장할 위치, 기본적으로 비어있어야 함
        private int tail = 0; // 반환할 위치, list가 비어있지 않는 한 데이터가 있어야 함
        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => (head == tail); }

        public MyQueue()
        {
            list.FillDefault();
        }

        public MyQueue(T[] array)
        {
            list = new MyList<T>(array);
            head = array.Length;
            tail = 0;
            Count = array.Length;

            int newCapacity = array.Length * 2;
            if (newCapacity < 10)
                newCapacity = 10;
            list.Capacity = newCapacity;
            list.FillDefault();
        }

        public void Enqueue(T element)
        {
            list[head] = element;
            head = Next(head);
            Count++;
            CheckFullList();
        }

        public T Dequeue()
        {
            T element = list[tail];
            list[tail] = default(T);
            tail = Next(tail);
            Count--;
            return element;
        }

        public T Peek()
        {
            return list[tail];
        }

        public void Clear()
        {
            list.Clear();
            head = 0;
            tail = 0;
            Count = 0;
        }

        // 하나 더 들어오면 가득 찰 상태라면 저장 공간을 늘린다
        private void CheckFullList()
        {
            if (Next(head) != tail)
                return;

            MyList<T> newList = new MyList<T>(list.Capacity * 2);
            for (int i = tail; i != head; i = Next(i))
            {
                newList.Add(list[i]);
            }
            newList.FillDefault();

            tail = 0;
            head = Count;
            list = newList;
        }

        private int Next(int index)
        {
            if (index + 1 == list.Capacity)
                return 0;
            else
                return index + 1;
        }
    }
}

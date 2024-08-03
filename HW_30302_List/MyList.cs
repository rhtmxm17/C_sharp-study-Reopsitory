namespace HW_30302_List
{
    public class MyList<T>
    {
        private const int DefaultCapacity = 10;

        // 현재 원소의 개수
        public int Count { get; private set; } = 0;

        public int Capacity 
        {
            get { return list.Length; }
            set 
            {
                if(Capacity == value)
                    return;

                T[] myArray = new T[value];
                list.CopyTo(myArray, 0);
                list = myArray;
            }
        }

        // []의 연산자 오버로딩은 인덱서 사용
        // https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/indexers/
        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public MyList()
        {
            list = new T[DefaultCapacity];
        }

        public MyList(int capacity)
        {
            list = new T[capacity];
        }

        public void Add(T element)
        {
            // 배열의 크기를 넘어서 데이터를 추가할 경우,
            // 현재 배열의 크기의 2배만큼 재할당
            if (Count >= list.Length)
            {
                if(Capacity == 0) // 사용자가 0으로 만든 상황이라면 2배 해도 0이므로 예외
                    Capacity = DefaultCapacity;
                else
                    Capacity *= 2;
            }

            // Count는 현재 원소의 개수, 곧 다음에 추가할 인덱스 번호를 의미한다.
            list[Count] = element;
            Count++;
        }

        public bool Remove(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if(Equals(list[i], element))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            // 일치하는 것을 발견하지 못하면 false
            return false;
        }

        public void RemoveAt(int index)
        {
            Count--;

            // 재배치 해야 할 원소 개수
            int replaceElements = Count - index;
            T[] temp = new T[replaceElements];
            Array.Copy(list, index + 1, temp, 0, replaceElements);
            Array.Copy(temp, 0, list, index, replaceElements);

            // 참조 타입이라면 더이상 쓰지 않을 위치의 참조를 풀어줄 필요가 있어보인다
            // 이러면 nullable로 선언하는게 맞나?
            list[Count] = default(T);
        }

        public void Clear()
        {
            list = new T[DefaultCapacity];
            Count = 0;
        }

        private T[] list;
    }
}

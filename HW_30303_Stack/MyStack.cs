using HW_30302_List;

namespace HW_30303_Stack
{
    public class MyStack<T>
    {
        private MyList<T> list = new MyList<T>();

        public int Count { get { return list.Count; } }

        public void Push(T element) => list.Add(element);

        public T Peek() => list[list.Count - 1];

        public void Clear() => list.Clear();

        public T Pop()
        {
            T element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;
        }

        public bool TryPop(out T element)
        {
            element = default(T);

            if (list.Count == 0)
                return false;

            element = Pop();

            return true;
        }
    }
}

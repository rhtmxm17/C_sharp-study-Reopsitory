namespace HW_30302_LinkedList
{
    public class MyLinkedListNode<T>
    {
        // 프로퍼티 Next, Previous를 통해 링크를 변경할 경우 
        // 1. 이미 링크되있던 상대 노드쪽의 참조도 자동적으로 null이 되도록 설정
        // 2. 새로 링크될 상대 노드의 링크도 연결

        private MyLinkedListNode<T>? nextNode = null;
        public MyLinkedListNode<T>? Next
        {
            get { return nextNode; }
            private set
            {
                if (nextNode == value)
                    return;

                if (nextNode is not null)
                    nextNode.prevNode = null; // 상호 호출로 인한 무한루프를 방지하기 위해 여기서만 Previous 대신 원본 사용

                nextNode = value;
                if (value is not null)
                {
                    if (this.List != value?.List)
                        throw new Exception();

                    value.Previous = this;
                }
            }
        }

        private MyLinkedListNode<T>? prevNode;
        public MyLinkedListNode<T>? Previous
        {
            get { return prevNode; }
            private set
            {
                if(prevNode == value)
                    return;

                if (prevNode is not null)
                    prevNode.nextNode = null; // 상호 호출로 인한 무한루프를 방지하기 위해 여기서만 Next 대신 원본 사용

                prevNode = value;
                if (value is not null)
                {
                    if (this.List != value?.List)
                        throw new Exception();

                    value.Next = this;
                }
            }
        }
        public MyLinkedList<T> List { get; private set; }
        public T Value { get; set; }
        
        public MyLinkedListNode(MyLinkedList<T> list, T element)
        {
            this.List = list;
            this.Value = element;
        }

        public void SetNextNode(MyLinkedListNode<T>? other)
        {
            if (other is null)
            {
                Next = null;
                return;
            }

            // 다른 리스트의 노드라면 잘못된 입력
            if (this.List != other.List)
                return;

            Next = other;
            other.Previous = this;
        }

        public void CutNextNode()
        {
            this.Next = null;
        }
    }

    public class MyLinkedList<T>
    {
        public int Count { get; private set; } = 0;
        public MyLinkedListNode<T>? First { get => firstNode; }
        public MyLinkedListNode<T>? Last { get => lastNode; }


        private MyLinkedListNode<T>? firstNode;
        private MyLinkedListNode<T>? lastNode;

        public MyLinkedListNode<T> AddFirst(T element)
        {
            MyLinkedListNode<T> newFirst = new(this, element);

            if (firstNode is null) // 비어있는 리스트의 첫 노드일 경우
            {
                lastNode = newFirst;
            }
            else
            {
                newFirst.SetNextNode(firstNode);
            }

            firstNode = newFirst;
            Count++;

            return newFirst;
        }

        public MyLinkedListNode<T> AddLast(T element)
        {
            MyLinkedListNode<T> newLast = new(this, element);

            if (lastNode is null) // 비어있는 리스트의 첫 노드일 경우
            {
                firstNode = newLast;
            }
            else
            {
                lastNode.SetNextNode(newLast);
            }

            lastNode = newLast;
            Count++;

            return newLast;
        }

        public void RemoveFirst()
        {
            if (firstNode is null)
                return;

            var newFirst = firstNode.Next;
            if (newFirst is null) // 유일한 노드였을 경우
            {
                firstNode = null;
                lastNode = null;
            }
            else
            {
                firstNode.CutNextNode();
                firstNode = newFirst;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (lastNode is null)
                return;

            var newLast = lastNode.Previous;
            if (newLast is null) // 유일한 노드였을 경우
            {
                firstNode = null;
                lastNode = null;
            }
            else
            {
                newLast.CutNextNode();
                lastNode = newLast;
            }

            Count--;
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            // 이 리스트의 노드가 맞는지 검사
            if (node.List != this)
                return;

            var prev = node.Previous;
            if(prev is null) // first였을경우
            {
                RemoveFirst();
                return;
            }

            prev.SetNextNode(node.Next);
            Count--;
        }
    }
}

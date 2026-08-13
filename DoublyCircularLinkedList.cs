namespace DSA
{
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyCircularLinkedList<T> : IEnumerable<T>
    {
        private DLLNode<T>? tail;
        private DLLNode<T>? head;
        public DLLNode<T>? Tail { get => tail; set => tail = value; }
        public DLLNode<T>? Head { get => head; set => head = value; }
        public int Count { get; private set; }

        public DoublyCircularLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void DeleteFromFront()
        {
            DeletListNode(1);
        }

        public void DeleteFromRear()
        {
            DeletListNode(Count);
        }

        public void AppendList(T data)
        {
            if (Head == null)
            {
                DLLNode<T> node = new DLLNode<T>(data);
                node.Next = node;
                node.Prev = node;
                Head = node;
                Tail = node;
                ++Count;
            }
            else
            {
                DLLNode<T> newNode = new DLLNode<T>(data);
                newNode.Prev = Tail;
                newNode.Next = Head;
                Tail!.Next = newNode;
                Head!.Prev = newNode;
                Tail = newNode;
                ++Count;
            }
        }

        // Enumerates forward from Head
        public IEnumerator<T> GetEnumerator()
        {
            if (Head == null)
                yield break;

            var iterator = Head!;
            for (int i = 0; i < Count; ++i)
            {
                yield return iterator.Data;
                iterator = iterator.Next!;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Backward enumeration starting from Tail
        public IEnumerable<T> EnumerateBackward()
        {
            if (Tail == null)
                yield break;

            var iterator = Tail!;
            for (int i = 0; i < Count; ++i)
            {
                yield return iterator.Data;
                iterator = iterator.Prev!;
            }
        }

        public void PrependList(T data)
        {
            if (Head == null)
            {
                DLLNode<T> node = new DLLNode<T>(data);
                node.Next = node;
                node.Prev = node;
                Head = node;
                Tail = node;
                ++Count;
            }
            else
            {
                DLLNode<T> oldHead = Head;
                DLLNode<T> node = new DLLNode<T>(data);
                node.Next = oldHead;
                node.Prev = Tail;
                oldHead.Prev = node;
                Tail!.Next = node;
                Head = node;
                ++Count;
            }
        }

        public void InsertInList(T data, int pos)
        {
            if (pos < 1 || pos > Count + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pos));
            }

            if (pos == 1)
            {
                PrependList(data);
                return;
            }

            if (pos == Count + 1)
            {
                AppendList(data);
                return;
            }

            var iterator = Head!;
            for (int i = 1; i < pos - 1; ++i)
            {
                iterator = iterator.Next!;
            }
            var next = iterator.Next!;
            var newNode = new DLLNode<T>(data);
            iterator.Next = newNode;
            newNode.Prev = iterator;
            newNode.Next = next;
            next.Prev = newNode;
            ++Count;
        }

        public void RotateForward(int pos)
        {
            if (Head == null || Count <= 1)
            {
                return;
            }

            pos = pos % Count;
            for (int i = 0; i < pos; ++i)
            {
                Head = Head!.Next;
            }
            Tail = Head!.Prev;
        }

        public void RotateBackward(int pos)
        {
            if (Head == null || Count <= 1)
            {
                return;
            }

            pos = (pos % Count + Count) % Count;
            for (int i = 0; i < pos; ++i)
            {
                Head = Head!.Prev;
            }
            Tail = Head!.Prev;
        }

        public void DeletListNode(int pos)
        {
            if (Head == null || pos < 1 || pos > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(pos));
            }

            if (Count == 1 && pos == 1)
            {
                Head = null;
                Tail = null;
                --Count;
                return;
            }

            if (pos == 1)
            {
                var newHead = Head!.Next!;
                Tail!.Next = newHead;
                newHead.Prev = Tail;
                Head = newHead;
                --Count;
                return;
            }

            if (pos == Count)
            {
                var newTail = Tail!.Prev!;
                newTail.Next = Head;
                Head!.Prev = newTail;
                Tail = newTail;
                --Count;
                return;
            }

            var iterator = Head!;
            for (int i = 1; i < pos - 1; ++i)
            {
                iterator = iterator.Next!;
            }
            var toDelete = iterator.Next!;
            iterator.Next = toDelete.Next;
            toDelete.Next!.Prev = iterator;
            --Count;
        }

        public bool UpdateNode(T data, int pos)
        {
            if (Head == null)
                return false;

            if (pos < 1 || pos > Count)
                return false;

            var temp = Head!;
            for (int i = 0; i < pos - 1; ++i)
            {
                temp = temp.Next!;
            }
            temp.Data = data;
            return true;
        }
    }
}

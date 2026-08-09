namespace DSA
{
    public class DoublyCircularLinkedList
    {
        private static int count = 0;
        private DLLNode? temp;
        private DLLNode? head;
        public DLLNode? Temp { get => temp; set => temp = value; }
        public DLLNode? Head { get => head; set => head = value; }
        public static int Count { get => count; set => count = value; }
        public DoublyCircularLinkedList()
        {
            Head = null;
            Temp = null;
        }
        public void DeleteFromFront()
        {
            // delete first node
            DeletListNode(1);
        }

        public void DeleteFromRear()
        {
            // delete last node
            DeletListNode(Count);
        }
        public void AppendList(int data)
        {
            // Append to a circular doubly linked list
            if (Head == null)
            {
                DLLNode node = new DLLNode(data);
                // single node points to itself
                node.Next = node;
                node.Prev = node;
                Head = node;
                Temp = node; // tail
                ++Count;
            }
            else
            {
                DLLNode newNode = new DLLNode(data);
                // link between tail(Temp), newNode and head
                newNode.Prev = Temp;
                newNode.Next = Head;
                Temp.Next = newNode;
                Head.Prev = newNode;
                Temp = newNode; // update tail
                ++Count;
            }
        }
        public void DisplayList()
        {
            if (Head != null)
            {
                // forward traversal starting at head
                DLLNode? iterator = this.Head;
                for (int i = 0; i < Count; ++i)
                {
                    Console.Write($"{iterator.Data}-");
                    iterator = iterator.Next;
                }
                Console.WriteLine();

                // backward traversal starting at tail (Temp)
                iterator = Temp;
                for (int i = 0; i < Count; ++i)
                {
                    Console.Write($"{iterator.Data}-");
                    iterator = iterator.Prev;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("List Is Empty");
            }
        }
        public void PrependList(int data)
        {
            // Prepend node as new head in circular list
            if (Head == null)
            {
                DLLNode node = new DLLNode(data);
                node.Next = node;
                node.Prev = node;
                Head = node;
                Temp = node;
                ++Count;
            }
            else
            {
                DLLNode oldHead = Head;
                DLLNode node = new DLLNode(data);
                node.Next = oldHead;
                node.Prev = Temp;
                oldHead.Prev = node;
                Temp.Next = node;
                Head = node;
                ++Count;
            }
        }
        public void InsertInList(int data, int pos)
        {
            if (pos < 1 || pos > Count + 1)
            {
                Console.WriteLine("Invalid Position");
                return;
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

            // insert somewhere in the middle
            DLLNode iterator = Head;
            for (int i = 1; i < pos - 1; ++i)
            {
                iterator = iterator.Next;
            }
            DLLNode next = iterator.Next;
            DLLNode newNode = new DLLNode(data);
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

            // normalize rotations
            pos = pos % Count;
            for (int i = 0; i < pos; ++i)
            {
                // move head forward by one node
                Head = Head.Next; // in circular list tail is Head.Prev
            }
            Temp = Head.Prev;
        }
        public void RotateBackward(int pos)
        {
            if (Head == null || Count <= 1)
            {
                return;
            }

            pos = pos % Count;
            for (int i = 0; i < pos; ++i)
            {
                // move first element to tail
                Head = Head.Next;
            }
            Temp = Head.Prev;
        }
        public void DeletListNode(int pos)
        {
            if (Head == null || pos < 1 || pos > Count)
            {
                Console.WriteLine("Out Of Bound");
                return;
            }

            // deleting the only node
            if (Count == 1 && pos == 1)
            {
                Head = null;
                Temp = null;
                --Count;
                return;
            }

            if (pos == 1)
            {
                // remove head
                DLLNode newHead = Head.Next;
                Temp.Next = newHead;
                newHead.Prev = Temp;
                Head = newHead;
                --Count;
                return;
            }

            if (pos == Count)
            {
                // remove tail (Temp)
                DLLNode newTail = Temp.Prev;
                newTail.Next = Head;
                Head.Prev = newTail;
                Temp = newTail;
                --Count;
                return;
            }

            // remove middle node
            DLLNode iterator = Head;
            for (int i = 1; i < pos - 1; ++i)
            {
                iterator = iterator.Next;
            }
            DLLNode toDelete = iterator.Next;
            iterator.Next = toDelete.Next;
            toDelete.Next.Prev = iterator;
            --Count;
        }
        public void UpdateNode(int data, int pos)
        {
            if (Head != null)
            {
                DLLNode temp = Head;
                if (pos <= Count)
                {

                    for (int i = 0; i < pos - 1; ++i)
                    {
                        // Console.Write($"{i + 1}. {temp.Data}");
                        Console.ReadKey();
                        temp = temp.Next;
                    }
                    temp.Data = data;
                    Console.WriteLine("Data updated successfully.....");
                }
                else
                {
                    Console.WriteLine("List is out of bound");
                }
            }
            else
            {
                Console.WriteLine("List Is Empty");
                Console.ReadKey();
            }
        }
    }
}
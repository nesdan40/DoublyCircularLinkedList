namespace DSA
{
    public class DLLNode<T>
    {
        // Generic doubly-linked list node
        public T Data { get; set; }
        public DLLNode<T>? Next { get; set; }
        public DLLNode<T>? Prev { get; set; }
        public DLLNode(T data)
        {
            Data = data;
        }
    }
}
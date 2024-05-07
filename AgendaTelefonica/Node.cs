namespace AgendaTelefonica
{
    internal class Node<T>
    {
        Node<T>? next = null;
        Node<T>? previous = null;
        T data;

        public Node(T data)
        {
            this.data = data;
        }

        public Node<T>? Next()
        {
            return this.next;
        }

        public Node<T>? Previous()
        {
            return this.previous;
        }

        public void SetNext(Node<T>? next)
        {
            this.next = next;
        }

        public void SetPrevious(Node<T>? previous)
        {
            this.previous = previous;
        }

        public T GetData()
        {
            return this.data;
        }
    }
}

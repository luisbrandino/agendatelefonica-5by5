namespace AgendaTelefonica
{
    internal class List<T> where T : IComparable
    {
        protected Node<T>? head = null;
        protected Node<T>? rear = null;
        protected int count = 0;

        public bool Empty() { return head == null; }

        public virtual void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            if (this.head == null)
            {
                InsertBeforeHead(node);
                return;
            }

            InsertAfter(rear, node);
            this.rear = node;
        }

        protected void InsertAfter(Node<T> node, Node<T> newNode)
        {
            count++;

            newNode.SetNext(node.Next());
            node.SetNext(newNode);
        }

        protected void InsertBeforeHead(Node<T> newNode)
        {
            count++;

            newNode.SetNext(head);
            head = newNode;
            rear = rear == null ? newNode : rear;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
                return;

            Node<T> node = new Node<T>(item);

            if (index == 0)
            {
                InsertBeforeHead(node);
                return;
            }

            if (this.Empty())
                return;

            Node<T>? current = this.head;
            int currentIndex = 1;

            while (current.Next() != null)
            {
                if (currentIndex == index)
                {
                    InsertAfter(current, node);

                    return;
                }

                currentIndex++;
                current = current.Next();
            }

            InsertAfter(this.rear, node);
            this.rear = node;
        }

        protected void RemoveAfter(Node<T> previous)
        {
            count--;

            Node<T>? node = previous == null ? head : previous.Next();

            if (node == this.head)
                this.head = node.Next();

            if (node == this.rear)
                this.rear = previous;

            previous?.SetNext(node.Next());
        }

        public void Remove(int index)
        {
            if (index < 0)
                return;

            Node<T>? current = this.head;
            Node<T>? previous = null;

            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex != index)
                {
                    currentIndex++;
                    previous = current;
                    current = current.Next();
                    continue;
                }

                RemoveAfter(previous);

                break;
            }
        }

        public void Remove(T item)
        {
            Node<T>? current = this.head;
            Node<T>? previous = null;

            while (current != null)
            {
                if (current.GetData().CompareTo(item) != 0)
                {
                    previous = current;
                    current = current.Next();
                    continue;
                }

                RemoveAfter(previous);

                break;
            }
        }

        public int Count()
        {
            return count;
        }

        public void Display()
        {
            Node<T>? current = this.head;

            while (current != null)
            {
                Console.Write($"{current.GetData()} ");

                current = current.Next();
            }
        }
    }
}

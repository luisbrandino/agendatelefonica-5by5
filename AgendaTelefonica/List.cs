namespace AgendaTelefonica
{
    internal class List<T>
    {
        protected Node<T>? head = null;
        protected Node<T>? rear = null;
        public int Count { get; private set; }

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
            Count++;

            newNode.SetNext(node.Next());
            node.SetNext(newNode);
        }

        protected void InsertBeforeHead(Node<T> newNode)
        {
            Count++;

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
            Count--;

            Node<T>? node = previous == null ? head : previous.Next();

            if (node == this.head)
                this.head = node.Next();

            if (node == this.rear)
                this.rear = previous;

            previous?.SetNext(node.Next());
        }

        public T? Find(int index)
        {
            if (index < 0)
                return default(T);

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

                return current.GetData();
            }

            return default(T);
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
                if (current.GetData().Equals(item))
                {
                    previous = current;
                    current = current.Next();
                    continue;
                }

                RemoveAfter(previous);

                break;
            }
        }

        public T[] ToVector()
        {
            T[] vector = new T[Count];

            Node<T>? current = this.head;
            int currentIndex = 0;

            while (current != null)
            {
                vector[currentIndex++] = current.GetData();
                current = current.Next();
            }

            return vector;
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

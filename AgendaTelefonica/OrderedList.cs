namespace AgendaTelefonica
{
    internal class OrderedList<T> : List<T> where T : IComparable
    {
        public override void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            if (this.head == null)
            {
                InsertBeforeHead(node);
                return;
            }

            int comparison = this.head.GetData().CompareTo(item);

            if (comparison >= 0)
            {
                InsertBeforeHead(node);
                return;
            }

            Node<T> current = this.head;

            while (current.Next() != null)
            {
                comparison = current.Next().GetData().CompareTo(item);

                if (comparison >= 0)
                {
                    InsertAfter(current, node);
                    return;
                }

                current = current.Next();
            }

            InsertAfter(rear, node);
            this.rear = node;
        }

    }
}

namespace AgendaTelefonica
{
    internal class Minimal<T> where T : IComparable, IFormattable, IConvertible
    {
        T value;

        public Minimal(T value)
        {
            this.value = value;
        }

        bool Verify(T value)
        {
            return this.value.CompareTo(value) >= 0;
        }
    }

    internal class Maximum<T> where T : IComparable, IFormattable, IConvertible
    {
        T value;

        public Maximum(T value)
        {
            this.value = value;
        }

        bool Verify(T value)
        {
            return this.value.CompareTo(value) <= 0;
        }
    }

    internal class NumberInput<T> where T : IComparable, IFormattable, IConvertible
    {
        private string _InvalidMessage(T? min, T? max)
        {
            if (min.Equals(default(T)))
                return $"Valor precisa ser menor ou igual à {max}";
            
            if (max.Equals(default(T)))
                return $"Valor precisa ser maior ou igual à {min}";

            return $"Valor precisa ser maior ou igual à {min} e menor ou igual à {max}";
        }

        public T? Get(string message, T? min, T? max)
        {
            Console.Write(message);
            T? value = (T?) Convert.ChangeType(Console.ReadLine(), typeof(T));

            if (min.Equals(default(T)) && max.Equals(default(T)))
                return value;

            if (min.CompareTo(max) >= 0 && !max.Equals(default(T)))
                return value;

            while (true)
            {
                bool correctValue = value?.CompareTo(min) >= 0 && value?.CompareTo(max) <= 0;

                if (correctValue)
                    break;

                Console.Write(this._InvalidMessage(min, max) + ": ");
                value = (T?)Convert.ChangeType(Console.ReadLine(), typeof(T));
            }

            return value;
        }
    }
}

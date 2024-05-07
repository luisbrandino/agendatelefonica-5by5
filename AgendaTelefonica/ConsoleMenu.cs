namespace AgendaTelefonica
{
    internal class ConsoleMenu
    {
        protected NumberInput<int> _input = new NumberInput<int>();
        protected string[] _options;

        public ConsoleMenu(params string[] options)
        {
            this._options = options;
        }

        public void Display()
        {
            for (int i = 0; i < _options.Length; i++)
                Console.WriteLine($"[ {i + 1} ] {_options[i]}");
        }
    }
    
}

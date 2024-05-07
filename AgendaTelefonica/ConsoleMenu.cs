namespace AgendaTelefonica
{
    internal class Option
    {
        public string Description { get; private set; }
        private Action? _action = null;

        public Option(string description)
        {
            Description = description;
        }

        public Option(string description, Action action)
        {
            Description = description;
            _action = action;
        }

        public void SetAction(Action action) { this._action = action; }

        public void Execute()
        {
            _action?.Invoke();
        }

        public override string ToString() { return Description; }

    }

    internal class ConsoleMenu
    {
        protected NumberInput<int> _input;
        protected List<Option> _options;

        public ConsoleMenu(params string[] options)
        {
            _input = new NumberInput<int>();
            _options = new List<Option>();

            foreach (string option in options)
                AddOption(option);
        }

        public void AddOption(string description)
        {
            _options.Add(new Option(description));
        }

        public void AddOption(string description, Action action)
        {
            _options.Add(new Option(description, action));
        }

        public void SetActionForOption(int option,  Action action)
        {
            _options.Find(option - 1)?.SetAction(action);
        }

        public void Execute(int option)
        {
            _options.Find(option - 1)?.Execute();
        }

        public int Ask()
        {
            _Display();
            return _input.Get("Sua opção: ", min: 1, max: _options.Count);
        }

        private void _Display()
        {
            Option[] options = _options.ToVector();
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine($"[ {i + 1} ] {options[i]}");
        }
        
    }
    
}

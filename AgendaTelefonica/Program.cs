using AgendaTelefonica;

OrderedList<Contact> contacts = new OrderedList<Contact>();

ConsoleMenu menu = new ConsoleMenu("Adicionar contato", "Remover contato", "Editar contato", "Exibir contato");

NumberInput<float> input = new NumberInput<float>();

float v = input.Get("Digite uma opção: ", 2, 6);
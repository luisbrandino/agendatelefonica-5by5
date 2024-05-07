using AgendaTelefonica;

ContactManager contacts = new ContactManager();

ConsoleMenu createMainMenu()
{
    ConsoleMenu menu = new ConsoleMenu("Adicionar contato", "Remover contato", "Editar contato", "Exibir contato");
    menu.SetActionForOption(1, addContact);
    menu.SetActionForOption(2, removeContact);
    menu.SetActionForOption(3, editContact);
    menu.SetActionForOption(4, displayContact);
    menu.AddOption("Sair", () => Environment.Exit(0));

    return menu;
}

void addContact()
{
    Console.WriteLine("Adicionar contato");
    Console.ReadKey();
}

void removeContact()
{

}

void editContact()
{

}

void displayContact()
{

}

while (true)
{
    Console.Clear();

    ConsoleMenu menu = createMainMenu();

    menu.Execute(menu.Ask());
}
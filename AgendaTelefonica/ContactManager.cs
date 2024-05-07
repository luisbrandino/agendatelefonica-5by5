namespace AgendaTelefonica
{
    internal class ContactManager
    {
        private OrderedList<Contact> _contacts;

        public ContactManager()
        {
            _contacts = new OrderedList<Contact>();
        }

        /**
         *  Adds to the manager's internal list
         */
        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }
        
        /**
         *  Removes from the manager's internal list
         */
        public void Remove(Contact contact)
        {
            _contacts.Remove(contact);
        }

        /**
         *  @param  contactToEdit   Contact the contact in the list to edit
         *  @param  newContact      Contact the object to copy to the real object in the list
         */
        public void Edit(Contact contactToEdit, Contact newContact)
        {
            Remove(contactToEdit);

            contactToEdit.SetPhones(newContact.GetPhones());
            contactToEdit.SetFullName(newContact.GetFullName());
            contactToEdit.SetAddress(newContact.GetAddress());
            contactToEdit.SetEmail(newContact.GetEmail());

            Add(contactToEdit);
        }

        /**
         *  Overloads the actual Edit method to accept the name instead of the contact object itself 
         */
        public void Edit(string name, Contact newContact)
        {
            Contact? contactToEdit = FindByName(name);

            if (contactToEdit == null)
                return;

            Edit(contactToEdit, newContact);
        }

        /**
         *  Finds the object in the list based on the contact's name
         *  
         *  @param  name    string  the contact's name
         */
        public Contact? FindByName(string name)
        {
            Contact[] contacts = _contacts.ToVector();

            for (int i = 0; i < contacts.Length; i++)
                if (contacts[i].GetFullName().Equals(name))
                    return contacts[i];

            return null;
        }

        /**
         *  Displays specified contact
         */
        public void Display(Contact contact)
        {

        }

        /**
         *  Display all contacts
         */
        public void Display()
        {

        }
    }
}

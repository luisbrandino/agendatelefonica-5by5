namespace AgendaTelefonica
{
    internal class Contact : IComparable
    {
        List<string> phones;
        string fullName;
        Address address;
        string email;

        public Contact(string fullName, Address address, string email, List<string> phones)
        {
            this.phones = phones;
            this.fullName = fullName;
            this.address = address;
            this.email = email;
        }

        List<string> GetPhones() { return this.phones; }

        string GetFullName() { return this.fullName; }  

        Address GetAddress() { return this.address; }

        string GetEmail() { return this.email; }

        void SetFullName(string fullName) { this.fullName = fullName; }

        void SetAddress(Address address) { this.address = address; }

        void SetEmail(string email) { this.email = email; }

        public int CompareTo(object? obj)
        {
            Contact? contact = obj as Contact;

            return string.Compare(fullName, contact?.fullName);
        }
    }
}

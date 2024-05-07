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

        public List<string> GetPhones() { return this.phones; }

        public string GetFullName() { return this.fullName; }  

        public Address GetAddress() { return this.address; }

        public string GetEmail() { return this.email; }

        public void SetPhones(List<string> phones) { this.phones = phones; }

        public void SetFullName(string fullName) { this.fullName = fullName; }

        public void SetAddress(Address address) { this.address = address; }

        public void SetEmail(string email) { this.email = email; }

        public int CompareTo(object? obj)
        {
            Contact? contact = obj as Contact;

            return string.Compare(fullName, contact?.fullName);
        }
    }
}

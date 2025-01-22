using System.Collections.Generic;

namespace Pair4.Client.Models
{
    public class ContactList
    {
        public List<string> Contacts { get; set; } = new List<string>();

        public void AddContact(string contact)
        {
            if (!Contacts.Contains(contact))
            {
                Contacts.Add(contact);
            }
        }

        public void RemoveContact(string contact)
        {
            Contacts.Remove(contact);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XamarinSample.Models;

namespace XamarinSample.Services
{
    public class ContactService
    {
        public List<Contact> ListContact { get; set; }

        public ContactService()
        {
            ListContact = new List<Contact>();
            AddContact(new Contact()
            {
                Nom = "Brian V.B",
                Gsm = "0497/31/84/36",
                Tel = "0497/31/84/36",
                Info = "Roi des pirates",
                Email = "van.bellinghen.brian@gmail.com"
            });
        }
        public List<Contact> GetAll() => ListContact;
        public void AddContact(Contact contact) => ListContact.Add(contact);
        public void RemoveContact(Contact contact) => ListContact.Remove(contact);
    }
}

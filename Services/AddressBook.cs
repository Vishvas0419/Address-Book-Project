using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Services
{
    internal class AddressBook
    {
        private List<Contact> contacts = new();
        private Contact contact;
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully");
        }

        public void PrintAll()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}

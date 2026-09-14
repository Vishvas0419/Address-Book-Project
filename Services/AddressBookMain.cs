using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace AddressBookApp.Services
{
    internal class AddressBookMain
    {
        private List<AddressBook> books = new();

        public void AddAddressBook(AddressBook addressBook)
        {
            books.Add(addressBook);
        }

        public int CountSingleBookContacts(AddressBook addressBook)
        {
            return addressBook.contacts.Count;
        }
        public int CountTotalContacts()
        {
            return books.Sum(book => book.contacts.Count);
        }

        public List<Contact> SearchContactByCity(string city)
        {
            return books
                .SelectMany(book => book.contacts)
                .Where(contact => contact.City.Equals(city,StringComparison.OrdinalIgnoreCase))
                .ToList();

        }

        public List<Contact> SearchContactByState(string state)
        {
            return books
                .SelectMany(b => b.contacts)
                .Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}

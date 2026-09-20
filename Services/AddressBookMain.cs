using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
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

        public void ViewByCityOrState()
        {
            var groupedCities = books.SelectMany(b => b.contacts).GroupBy(contact => contact.City); //GroupBy() creates groups based on City key.
            Console.WriteLine("--- By City ---");
            foreach (var cityGroup in groupedCities)
            {
                Console.WriteLine($"\n{cityGroup.Key}:");
                foreach (var contact in cityGroup)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }
            }
            Console.WriteLine();
            var groupedStates = books.SelectMany(b => b.contacts).GroupBy(contact => contact.State);
            Console.WriteLine("--- By State ---");
            foreach (var stateGroup in groupedStates)
            {
                Console.WriteLine($"\n{stateGroup.Key}");
                foreach (var contact in stateGroup)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }
            }
        }

        public void GetCountByCityOrState()
        {
            var allContacts = books
                .SelectMany(book => book.contacts);

            Console.WriteLine("\n--- Count by City ---");

            var cityCounts = allContacts
                .GroupBy(contact => contact.City)
                .Select(group => new
                {
                    City = group.Key,
                    Count = group.Count()
                });

            foreach (var city in cityCounts)
            {
                Console.WriteLine(
                    $"{city.City} : {city.Count}");
            }

            Console.WriteLine("\n--- Count by State ---");

            var stateCounts = allContacts
                .GroupBy(contact => contact.State)
                .Select(group => new
                {
                    State = group.Key,
                    Count = group.Count()
                });

            foreach (var state in stateCounts)
            {
                Console.WriteLine(
                    $"{state.State} : {state.Count}");
            }
        }

        // Show all contacts from all address books
        public void GetAllContacts()
        {
            foreach (var book in books)
            {
                book.PrintAll();
            }
        }

        public List<Contact> SortAllByName()
        {
            return books
                .SelectMany(book => book.contacts)
                .OrderBy(contact => contact.FirstName)
                .ToList();
        }

        public List<Contact> SortAllByCity()
        {
            return books
                .SelectMany(book => book.contacts)
                .OrderBy(contact => contact.City)
                .ToList();
        }

        public List<Contact> SortAllByState()
        {
            return books
                .SelectMany(book => book.contacts)
                .OrderBy(contact => contact.State)
                .ToList();
        }


        public List<Contact> SortAllByZip()
        {
            return books
                .SelectMany(book => book.contacts)
                .OrderBy(contact => contact.Zip)
                .ToList();
        }

    }
}

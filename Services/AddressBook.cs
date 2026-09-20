using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AddressBookApp.Services
{
    internal class AddressBook
    {
        public List<Contact> contacts = new();
        private Contact contact;
        public void AddContact(Contact contact)
        {
            bool exists = contacts.Any(c => c.FirstName == contact.FirstName && c.LastName==contact.LastName);
            if (exists)
            {
                Console.WriteLine($"Contact '{contact.FirstName} {contact.LastName}' already exists. Duplicate not added.");
                return;
            }
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

        public void EditContact(string firstName,string lastName)
        {
            Contact? contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if(contact==null)
            {
                Console.WriteLine("Contact Not Found!");
                return;
            }
            Console.WriteLine("Enter new first name : ");
            string? newFirstName = Console.ReadLine();
           if(!string.IsNullOrWhiteSpace(newFirstName))
           {
                if (ContactValidator.IsValidName(newFirstName))
                {
                    contact.FirstName = newFirstName;
                }
                else throw new InvalidContactException(" First name must start with a capital letter and be at least 3 characters.");
           }
            Console.WriteLine("Enter new last name : ");
            string? newLastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLastName))
            {
                if (ContactValidator.IsValidName(newLastName))
                {
                    contact.LastName = newLastName;
                }
                else
                {
                    throw new InvalidContactException("Error : last name must start with a capital letter and be at least 3 characters. ");
                }
            }

            Console.WriteLine("Enter new city to update : ");
            string? newCity = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCity))
            {
                if (ContactValidator.IsValidCity(newCity))
                {
                    contact.City = newCity;
                }
                else
                {
                    throw new InvalidContactException("Error : last name must start with a capital letter and be at least 3 characters. ");
                }
            }
            Console.WriteLine("Contact Updated successfully");
        }

        public void DeleteContact(string firstName,string lastName)
        {
            Contact? contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if(contact==null)
            {
                Console.WriteLine("Contact Not Found");
            }

            contacts.Remove(contact);

            Console.WriteLine("Contact Deleted");
        }

        
        public void GetCountByCityOrState()
        {
            var result = contacts.GroupBy(c => c.City).Select(g => new {City = g.Key, Count = g.Count()});
            Console.Write("By City : ");
            foreach (var group in result)
            {
                Console.Write($"{group.City} = {group.Count}"+", ");
            }
            Console.WriteLine();
            var stateResult = contacts.GroupBy(c => c.State).Select(g => new { State = g.Key, Count = g.Count() });
            Console.Write("By state : ");
            foreach (var group in stateResult)
            {
                Console.Write($"{group.State} = {group.Count}"+", ");

            }
        }

        //public void SortByName()
        //{
        //    contacts = contacts.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        //}


        //public void SortByCity()
        //{
        //    contacts = contacts.OrderBy(c => c.City).ToList(); //Order by converts arrganges the contacts into Alphabetical city order
        //}

        //public void SortByState()
        //{
        //    contacts = contacts.OrderBy(c => c.State).ToList();
        //}
        //public void SortByZip()
        //{
        //    contacts = contacts.OrderBy(c => c.Zip).ToList();
        //}
    }
}

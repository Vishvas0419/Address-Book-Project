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

    }
}

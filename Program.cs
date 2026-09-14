using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;
using System.Diagnostics.Contracts;
using System.Text;

namespace AddressBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
            //Contact contact2 = new Contact("john", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
            try
            {

                ContactValidator.Validate(contact1);
                Console.WriteLine(contact1);

                //ContactValidator.Validate(contact2);
                //Console.WriteLine(contact2);
            } 
            catch(InvalidContactException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return;
            }

            //UC-3 
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(contact1);
            //addressBook.AddContact(contact2);
            //addressBook.PrintAll();

            //UC 4 - edit Contact

            Console.WriteLine("Enter first name to edit");
            string? firstName = Console.ReadLine();
            Console.WriteLine("Enter last name to edit");
            string? lastName = Console.ReadLine();
            Console.WriteLine($"Editing : {firstName} {lastName}");
            addressBook.EditContact(firstName, lastName);

            addressBook.PrintAll();
        }
    }
}

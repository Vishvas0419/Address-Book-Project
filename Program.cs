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
            Contact contact2 = new Contact("Hello", "Jiw", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
            Contact contact3= new Contact("Vishvas", "Vaglay", "house no 2", "shivpuri - b", "Haryana", "135001", "9991377488", "vishvas@mail.com");
            Contact contact4 = new Contact("Vishvas", "Vaglay", "house no 20", "shivpuri - c", "Haryana", "135002", "7991377488", "vishvas@mail.com");
            Contact contact5 = new Contact("Bharosa", "Vaglay", "house no 221", "sundar nagar", "Punjab", "140401", "8991377488", "vishvas@mail.com");


            try
            {

                ContactValidator.Validate(contact1);
                Console.WriteLine(contact1);

                ContactValidator.Validate(contact2);
                Console.WriteLine(contact2);
            } 
            catch(InvalidContactException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return;
            }
            
            //UC-3 (Add contact) and UC-7 (check for duplicate contacts)
            AddressBook addressBook1 = new AddressBook();
            addressBook1.AddContact(contact1);
            addressBook1.AddContact(contact2);
            addressBook1.PrintAll();

            AddressBook addressBook2 = new AddressBook();
            addressBook2.AddContact(contact3);
            addressBook2.AddContact(contact4); //this will not be added since duplicate names
            addressBook2.AddContact(contact5);
            addressBook2.PrintAll();


            //UC 4 - edit Contact

            //Console.WriteLine("Enter first name to edit");
            //string? firstName = Console.ReadLine();
            //Console.WriteLine("Enter last name to edit");
            //string? lastName = Console.ReadLine();
            //Console.WriteLine($"Editing : {firstName} {lastName}");
            //addressBook.EditContact(firstName, lastName);

            //addressBook.PrintAll();


            //UC 5 - Delete a contact
            //Console.WriteLine("Enter first name to delete : ");
            //string? firstName = Console.ReadLine();
            //Console.WriteLine("Enter last name to delete: ");
            //string? lastName = Console.ReadLine();

            //addressBook.DeleteContact(firstName, lastName);
            //addressBook.PrintAll();



            AddressBookMain addressBookMain = new AddressBookMain();

            //UC6 - count contacts

            //int countAddressBook1 = addressBookMain.CountSingleBookContacts(addressBook1);
            //Console.WriteLine($"Total Contacts in AddressBook1 : {countAddressBook1}");
            //int countAddressBook2 = addressBookMain.CountSingleBookContacts(addressBook2);
            //Console.WriteLine($"Total Contacts in AddressBook2 : {countAddressBook2}");

            addressBookMain.AddAddressBook(addressBook1);
            addressBookMain.AddAddressBook(addressBook2);

            //int count = addressBookMain.CountTotalContacts();
            //Console.WriteLine($"Total contacts in all address books: {count}");

            //UC7 is done along with UC3 in AddContact method above

            //UC8 - Search Contact By City or State
            //Console.WriteLine("Enter city to search : ");
            //string? city = Console.ReadLine();
            //var results = addressBookMain.SearchContactByCity(city);
            //int countResult = results.Count();
            //Console.WriteLine($"Found {countResult} contact(s): ");
            //foreach(var contact in results)
            //{
            //    Console.WriteLine(contact);
            //}

            //Console.WriteLine("Enter state to search : ");
            //string? state = Console.ReadLine();
            //var stateResults = addressBookMain.SearchContactByState(state);
            //int countStateResults = stateResults.Count();
            //Console.WriteLine($"Found {countStateResults} contact(s): ");
            //foreach (var contact in stateResults)
            //{
            //    Console.WriteLine(contact);
            //}

            ////UC-9  (View Contacts by City or State)
            //addressBookMain.ViewByCityOrState();

            ////UC10 (Count by City or State)
            //addressBook2.GetCountByCityOrState();

            //UC11 (Sort Entries by Name)
            Console.WriteLine("Before Sorting:");
            addressBook2.PrintAll();

            addressBook2.SortByName();

            Console.WriteLine("\nAfter Sorting by Name:");
            addressBook2.PrintAll();
        }
    }
}

using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using System.Text;

namespace AddressBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
                Contact contact2 = new Contact("john", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");

                ContactValidator.Validate(contact1);
                Console.WriteLine(contact1);

                ContactValidator.Validate(contact2);
                Console.WriteLine(contact2);

            } 
            catch(InvalidContactException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}

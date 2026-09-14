using AddressBookApp.Models;
using System.Text;

namespace AddressBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
            Console.WriteLine(contact1.ToString());
            
        }
    }
}

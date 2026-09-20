using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

namespace AddressBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------
            // Create Address Books
            // -----------------------------

            AddressBook addressBook1 = new AddressBook();
            AddressBook addressBook2 = new AddressBook();

            AddressBookMain addressBookMain = new AddressBookMain();

            addressBookMain.AddAddressBook(addressBook1);
            addressBookMain.AddAddressBook(addressBook2);


            // -----------------------------
            // Final Menu
            // -----------------------------

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("===== ADDRESS BOOK MENU =====");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Show All Contacts");
                Console.WriteLine("5. Total Contact Count");
                Console.WriteLine("6. Search by City");
                Console.WriteLine("7. Search by State");
                Console.WriteLine("8. View by City/State");
                Console.WriteLine("9. Count by City/State");
                Console.WriteLine("10. Sort by Name");
                Console.WriteLine("11. Sort by City / State / Zip");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter your choice: ");
                string? choice = Console.ReadLine();


                // =========================================
                // UC1 / UC2 / UC3 / UC7
                // ADD CONTACT
                // =========================================

                if (choice == "1")
                {
                    Console.WriteLine("\nEnter Contact Details");

                    Console.Write("Enter First Name: ");
                    string? firstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string? lastName = Console.ReadLine();

                    Console.Write("Enter Address: ");
                    string? address = Console.ReadLine();

                    Console.Write("Enter City: ");
                    string? city = Console.ReadLine();

                    Console.Write("Enter State: ");
                    string? state = Console.ReadLine();

                    Console.Write("Enter Zip: ");
                    string? zip = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    string? phoneNumber = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    string? email = Console.ReadLine();

                    try
                    {
                        Contact newContact = new Contact(
                            firstName!,
                            lastName!,
                            address!,
                            city!,
                            state!,
                            zip!,
                            phoneNumber!,
                            email!
                        );

                        ContactValidator.Validate(newContact);

                        Console.WriteLine("\nContact is valid.");

                        Console.Write("Enter Address Book (1 or 2): ");
                        string? bookChoice = Console.ReadLine();

                        if (bookChoice == "1")
                        {
                            addressBook1.AddContact(newContact);
                        }
                        else if (bookChoice == "2")
                        {
                            addressBook2.AddContact(newContact);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Address Book choice.");
                        }
                    }
                    catch (InvalidContactException ex)
                    {
                        Console.WriteLine($"Error : {ex.Message}");
                    }
                }


                // =========================================
                // UC4
                // EDIT CONTACT
                // =========================================

                else if (choice == "2")
                {
                    Console.Write("Enter first name to edit: ");
                    string? firstName = Console.ReadLine();

                    Console.Write("Enter last name to edit: ");
                    string? lastName = Console.ReadLine();

                    Console.Write("Enter Address Book (1 or 2): ");
                    string? bookChoice = Console.ReadLine();

                    if (bookChoice == "1")
                    {
                        addressBook1.EditContact(firstName!, lastName!);
                    }
                    else if (bookChoice == "2")
                    {
                        addressBook2.EditContact(firstName!, lastName!);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Address Book choice.");
                    }
                }


                // =========================================
                // UC5
                // DELETE CONTACT
                // =========================================

                else if (choice == "3")
                {
                    Console.Write("Enter first name to delete: ");
                    string? firstName = Console.ReadLine();

                    Console.Write("Enter last name to delete: ");
                    string? lastName = Console.ReadLine();

                    Console.Write("Enter Address Book (1 or 2): ");
                    string? bookChoice = Console.ReadLine();

                    if (bookChoice == "1")
                    {
                        addressBook1.DeleteContact(firstName!, lastName!);
                    }
                    else if (bookChoice == "2")
                    {
                        addressBook2.DeleteContact(firstName!, lastName!);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Address Book choice.");
                    }
                }


                // =========================================
                // SHOW ALL CONTACTS
                // =========================================

                else if (choice == "4")
                {
                    Console.WriteLine("\n--- Address Book 1 ---");
                    addressBook1.PrintAll();

                    Console.WriteLine("\n--- Address Book 2 ---");
                    addressBook2.PrintAll();
                }


                // =========================================
                // UC6
                // TOTAL CONTACT COUNT
                // =========================================

                else if (choice == "5")
                {
                    int countAddressBook1 =
                        addressBookMain.CountSingleBookContacts(addressBook1);

                    int countAddressBook2 =
                        addressBookMain.CountSingleBookContacts(addressBook2);

                    int totalCount =
                        addressBookMain.CountTotalContacts();

                    Console.WriteLine(
                        $"Contacts in AddressBook1 : {countAddressBook1}"
                    );

                    Console.WriteLine(
                        $"Contacts in AddressBook2 : {countAddressBook2}"
                    );

                    Console.WriteLine(
                        $"Total contacts in all address books : {totalCount}"
                    );
                }


                // =========================================
                // UC8
                // SEARCH BY CITY
                // =========================================

                else if (choice == "6")
                {
                    Console.Write("Enter city to search: ");
                    string? city = Console.ReadLine();

                    var results =
                        addressBookMain.SearchContactByCity(city!);

                    if (results.Count == 0)
                    {
                        Console.WriteLine("No contacts found.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Found {results.Count} contact(s):"
                        );

                        foreach (var contact in results)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                }


                // =========================================
                // UC8
                // SEARCH BY STATE
                // =========================================

                else if (choice == "7")
                {
                    Console.Write("Enter state to search: ");
                    string? state = Console.ReadLine();

                    var results =
                        addressBookMain.SearchContactByState(state!);

                    if (results.Count == 0)
                    {
                        Console.WriteLine("No contacts found.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Found {results.Count} contact(s):"
                        );

                        foreach (var contact in results)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                }


                // =========================================
                // UC9
                // VIEW BY CITY / STATE
                // =========================================

                else if (choice == "8")
                {
                    addressBookMain.ViewByCityOrState();
                }


                // =========================================
                // UC10
                // COUNT BY CITY / STATE
                // =========================================

                else if (choice == "9")
                {
                    addressBookMain.GetCountByCityOrState();
                }


                // =========================================
                // UC11
                // SORT BY NAME
                // =========================================

                else if (choice == "10")
                {
                    Console.WriteLine("\nBefore Sorting:");

                    addressBookMain.GetAllContacts();

                    var sortedContacts = addressBookMain.SortAllByName();

                    Console.WriteLine("\nAfter Sorting by Name:");

                    foreach (var contact in sortedContacts)
                    {
                        Console.WriteLine(contact);
                    }
                }


                // =========================================
                // UC12
                // SORT BY CITY / STATE / ZIP
                // =========================================

                else if (choice == "11")
                {
                    Console.WriteLine("1. Sort by City");
                    Console.WriteLine("2. Sort by State");
                    Console.WriteLine("3. Sort by Zip");

                    Console.Write("Enter your choice: ");
                    string? sortChoice = Console.ReadLine();

                    List<Contact> sortedContacts;

                    if (sortChoice == "1")
                    {
                        sortedContacts = addressBookMain.SortAllByCity();
                    }
                    else if (sortChoice == "2")
                    {
                        sortedContacts = addressBookMain.SortAllByState();
                    }
                    else if (sortChoice == "3")
                    {
                        sortedContacts = addressBookMain.SortAllByZip();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                    Console.WriteLine("\nSorted Contacts:");

                    foreach (var contact in sortedContacts)
                    {
                        Console.WriteLine(contact);
                    }
                }


                // =========================================
                // EXIT
                // =========================================

                else if (choice == "0")
                {
                    running = false;

                    Console.WriteLine(
                        "Exiting Address Book..."
                    );
                }


                // =========================================
                // INVALID CHOICE
                // =========================================

                else
                {
                    Console.WriteLine(
                        "Invalid choice. Please enter a valid option."
                    );
                }
            }
        }
    }
}
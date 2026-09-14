using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AddressBookApp.Models
{
    internal class Contact
    {
        //first name, last name, address, city, state, zip, phone number, 
        //email, and a constructor that sets all of them
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }

        public string PhoneNumber {  get; set; }

        public string Email {  get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} | {Address}, " + $"{City}, {State} {Zip} | {PhoneNumber} | {Email}";
        }

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phonNumber,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City= city;
            State = state;
            Zip = zip;
            PhoneNumber = phonNumber;
            Email = email;
        }
    }
}

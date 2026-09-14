using AddressBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Validation
{
    internal class ContactValidator
    {
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Z][a-zA-Z]{2,}$");
        }

        public static bool IsValidAddress(string address)
        {
            return Regex.IsMatch(address, @"^.{4,}");
        }

        public static bool IsValidCity(string city)
        {
            return Regex.IsMatch(city, @"^.{4,}");
        }

        public static bool IsValidState(string state)
        {
            return Regex.IsMatch(state, @"^.{4,}");
        }

        public static bool IsValidZip(string zip)
        {
            return Regex.IsMatch(zip, @"[0-9]{6,}");
        }

        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"[0-9]{10,}");
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
        public static void Validate(Contact contact)
        {
            if (!IsValidName(contact.FirstName) || !IsValidName(contact.LastName)) throw new InvalidContactException("First name must start with a capital letter and be at least 3 characters. ");
            if (!IsValidAddress(contact.Address)) throw new InvalidContactException("Invalid Address : address should be atleast of 4 characters");
            if (!IsValidCity(contact.City)) throw new InvalidContactException("Invaid City name : city name should be atleast of 4 characters");
            if (!IsValidState(contact.State)) throw new InvalidContactException("Invaid State name : State name should be atleast of 4 characters");
            if (!IsValidZip(contact.Zip)) throw new InvalidContactException("Zip must contain exactly 6 digits.");
            if (!IsValidPhone(contact.PhoneNumber)) throw new InvalidContactException("Phone number must contain exactly 10 digits.");
            if (!IsValidEmail(contact.Email)) throw new InvalidContactException("Email format is invalid.");
        }
    }
}

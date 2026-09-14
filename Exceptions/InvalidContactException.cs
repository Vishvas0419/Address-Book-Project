using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Exceptions
{
    internal class InvalidContactException  : Exception
    {
        public InvalidContactException(string message) : base(message) { }
    }
}

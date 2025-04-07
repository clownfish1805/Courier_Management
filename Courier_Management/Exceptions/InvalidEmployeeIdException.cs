using System;

namespace Courier_Management.Exceptions
{
    public class InvalidEmployeeIdException : ApplicationException
    {
        public InvalidEmployeeIdException() : base("Invalid employee ID.") { }

        public InvalidEmployeeIdException(string message) : base(message) { }
    }
}

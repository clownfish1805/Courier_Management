using System;

namespace Courier_Management.Exceptions
{
    public class TrackingNumberNotFoundException : ApplicationException
    {
        public TrackingNumberNotFoundException() : base("Tracking number not found.") { }

        public TrackingNumberNotFoundException(string message) : base(message) { }
    }
}

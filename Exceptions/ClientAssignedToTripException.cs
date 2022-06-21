using System;

namespace Cwiczenia7.Exceptions
{
    public class ClientAssignedToTripException : Exception
    {
        public ClientAssignedToTripException() : base("Client already assigned to trip.") { }
    }
}

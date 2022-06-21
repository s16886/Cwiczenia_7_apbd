using System;

namespace Cwiczenia7.Exceptions
{
    public class ClientExistsException : Exception
    {
        public ClientExistsException() : base("Client alredy exists.") { }
    }
}

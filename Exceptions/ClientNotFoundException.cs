using System;

namespace Cwiczenia7.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() : base("Client not found.") { }
    }
}

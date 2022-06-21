using System;

namespace Cwiczenia7.Exceptions
{
    public class TripsAssignedException : Exception
    {
        public TripsAssignedException() : base("Client has assigned trips.") { }
    }
}

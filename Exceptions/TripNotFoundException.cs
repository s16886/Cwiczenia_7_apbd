using System;

namespace Cwiczenia7.Exceptions
{
    public class TripNotFoundException : Exception
    {
        public TripNotFoundException() : base("Trip doesn't exist.") { }
    }
}

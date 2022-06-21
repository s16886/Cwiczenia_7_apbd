using System;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia7.Models.DTO
{
    public class SomeSortOfClientTrip
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Pesel is required.")]
        public string Pesel { get; set; }
        [Required(ErrorMessage = "IdTrip is required.")]
        public int IdTrip { get; set; }
        public string TripName { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

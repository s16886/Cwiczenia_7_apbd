using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia7.Models.DTO
{
    public class SomeSortOfTrip
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Required(ErrorMessage = "MaxPeople is required.")]
        public int MaxPeople { get; set; }
        public IEnumerable<SomeSortOfCountry> Countries { get; set; }
        public IEnumerable<SomeSortOfClient> Clients { get; set; }
    }
}

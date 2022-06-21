using System.ComponentModel.DataAnnotations;

namespace Cwiczenia7.Models.DTO
{
    public class SomeSortOfCountry
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}

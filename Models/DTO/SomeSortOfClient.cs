using System.ComponentModel.DataAnnotations;

namespace Cwiczenia7.Models.DTO
{
    public class SomeSortOfClient
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
    }
}

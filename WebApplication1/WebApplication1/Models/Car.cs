using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1886, int.MaxValue, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }
    }
}

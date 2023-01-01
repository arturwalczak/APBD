using System.ComponentModel.DataAnnotations;

namespace Task04.Models
{
    public class Animal
    {
        [Required(ErrorMessage = "IdAnimal should not null")]
        public int IdAnimal { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Name should not null")]
        public string Name { get; set; }
        // Note: nullable 
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Category should not be null")]
        public string Category { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Area should not be null")]
        public string Area { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProyectDB.Data.Models
{
    public class Person
    {
        [Range(1, int.MaxValue, ErrorMessage = "La cedula debe ser como el carnet")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}

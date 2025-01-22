using System.ComponentModel.DataAnnotations;

namespace ProyectDB.Data.Models
{
    public class Customer : Person
    {

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

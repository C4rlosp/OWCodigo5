using System.ComponentModel.DataAnnotations;

namespace OWCodigo5.Models
{
    public class Teatro
    {
        [Key]
        [Required]
        public int IdTeatro { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public int Nombre { get; set; }

        [Required]
        public int Localidad { get; set; }
    }
}

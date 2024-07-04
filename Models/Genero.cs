using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWCodigo5.Models
{
    public class Genero
    {
        [Key]
        [Required]
        public int IdGenero { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Nombre { get; set; } = null!;

        // Relación uno a muchos
        public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
    }
}


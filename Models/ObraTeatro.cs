using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWCodigo5.Models
{
    public class ObraTeatro
    {
        [Key]
        [Required]
        public int IdObraTeatro { get; set; }

        [Required]
        public int IdObra { get; set; }

        [Required]
        public int IdTeatro { get; set; }

        // Propiedades de navegación
        [ForeignKey(nameof(IdObra))]
        public virtual Obra Obra { get; set; } = null!;

        [ForeignKey(nameof(IdTeatro))]
        public virtual Teatro Teatro { get; set; } = null!;

        // Relación de uno a muchos con Carrito
        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
    }
}

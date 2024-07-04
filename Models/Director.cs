using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWCodigo5.Models
{
    public class Director
    {
        [Key]
        [Required]
        public int IdDirector { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Nombre { get; set; } = null!;

        [Required]
        public int ObraId { get; set; }

        //Propiedades de navegacion
        [ForeignKey("IdObra")]
        public virtual Obra Obra { get; set; } = null!;
    }
}

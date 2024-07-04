using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWCodigo5.Models
{
    public class Actor
    {
        [Key]
        [Required]
        public int IdActor { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Direccion { get; set; }

        [Required]
        public string Nacionalidad { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public string Personaje { get; set; }

        [Required]
        public string RolEspecifico { get; set; }

        [Required]
        public int IdObra { get; set; }

        // Propiedad de navegación
        [ForeignKey("IdObra")]
        public virtual Obra Obra { get; set; }
    }
}

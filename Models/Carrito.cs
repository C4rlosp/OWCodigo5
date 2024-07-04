using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWCodigo5.Models
{
    public class Carrito
    {
        [Key]
        [Required]
        public int IdCarrito { get; set; }

        [Required]
        public int NumeroTicket { get; set; } // Nuevo campo para manejar el número de ticket

        [Required]
        public int IdObraTeatro { get; set; }

        [Required]
        public int IdAsiento { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int NumeroAsiento { get; set; }

        [Required]
        public char Fila { get; set; }

        // Propiedades de navegación
        [ForeignKey(nameof(IdObraTeatro))]
        public virtual ObraTeatro ObraTeatro { get; set; } = null!;

        [ForeignKey(nameof(IdAsiento))]
        public virtual Asiento Asiento { get; set; } = null!;

        [ForeignKey(nameof(IdUsuario))]
        public virtual Usuario Usuario { get; set; } = null!;

        // Propiedad calculada para la fecha de presentación obtenida de la obra
        [NotMapped] // No se mapea a la base de datos directamente
        public DateTime FechaPresentacion => ObraTeatro.Obra.FechaPresentacion;
    }
}

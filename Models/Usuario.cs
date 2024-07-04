using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OWCodigo5.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string NombreCompleto { get; set; } = null!;

        [Required]
        public int Cedula { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Direccion { get; set; } = null!;

        [Required]
        public string Telefono { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        public string Contrasena { get; set; } = null!;

        // Relación de uno a muchos con Carrito
        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
    }
}

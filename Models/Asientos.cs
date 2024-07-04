using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OWCodigo5.Models
{
    public class Asiento
    {
        [Key]
        [Required]
        public int IdAsiento { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoDeAsiento { get; set; }
        [Required]
        public int NumeroAsiento { get; set; }

        [Required]
        public char Fila { get; set; }

    }
}

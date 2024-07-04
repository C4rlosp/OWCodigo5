using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace OWCodigo5.Models
{
    public class Obra
    {
        [Key]
        [Required]
        public int IdObra { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Titulo { get; set; }

        [Required]
        public int IdGenero { get; set; }

        [Required]
        public DateTime FechaPresentacion { get; set; }

        // [NotMapped] // Ignorar esta propiedad en el contexto de diseño
        // public IFormFile ImagenFile { get; set; }

        // public string ImagenUrl { get; set; } // Propiedad para almacenar la URL de la imagen

        // Propiedades de navegación
        [ForeignKey(nameof(IdGenero))]
        public virtual Genero Genero { get; set; } = null!;

        public virtual ICollection<Actor> Actores { get; set; } = new List<Actor>();

        public virtual ICollection<ObraTeatro> ObraTeatros { get; set; } = new List<ObraTeatro>();

        public virtual ICollection<Director> Directores { get; set; } = new List<Director>();
    }
}
